using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security;
using DevExpress.XtraCharts.GLGraphics.Platform;

namespace DevExpress.XtraCharts.GLGraphics.Platform {
    [SuppressMessage("SpellChecker", "CRRSP01")]
    public static class EGLImport {
        const string libEGL = "libEGL.so.1";

        [DllImportAttribute(libEGL, EntryPoint = "eglGetCurrentContext")]
        public static extern IntPtr GetCurrentContext();
        [DllImportAttribute(libEGL, EntryPoint = "eglGetError")]
        public static extern int GetError();
        [DllImport(libEGL, EntryPoint = "eglGetDisplay")]
        public static extern IntPtr GetDisplay(IntPtr displayId);
        [DllImport(libEGL, EntryPoint = "eglInitialize")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool Initialize(IntPtr display, out int major, out int minor);
        [DllImport(libEGL, EntryPoint = "eglChooseConfig")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ChooseConfig(IntPtr display, int[] attributes, out IntPtr config, int configSize, out int configsCount);
        [DllImport(libEGL, EntryPoint = "eglCreatePbufferSurface")]
#if DEBUGTEST                       //DEMO_REMOVE
        [FxCopSpellCheckingIgnore]  //DEMO_REMOVE
#endif                              //DEMO_REMOVE
        public static extern IntPtr CreatePbufferSurface(IntPtr display, IntPtr config, int[] attributes);
        [DllImportAttribute(libEGL, EntryPoint = "eglDestroySurface")]
        [return: MarshalAsAttribute(UnmanagedType.I1)]
        public static extern bool DestroySurface(IntPtr display, IntPtr surface);
        [DllImport(libEGL, EntryPoint = "eglBindAPI")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool BindAPI(int api);
        [DllImport(libEGL, EntryPoint = "eglCreateContext")]
        public static extern IntPtr CreateContext(IntPtr display, IntPtr config, IntPtr sharedContext, int[] attributes);
        [DllImportAttribute(libEGL, EntryPoint = "eglDestroyContext")]
        [return: MarshalAsAttribute(UnmanagedType.I1)]
        public static extern bool DestroyContext(IntPtr display, IntPtr context);
        [DllImport(libEGL, EntryPoint = "eglMakeCurrent")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool MakeCurrent(IntPtr display, IntPtr draw, IntPtr read, IntPtr context);
        [DllImport(libEGL, EntryPoint = "eglTerminate")]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool Terminate(IntPtr display);
    }

    [SuppressMessage("SpellChecker", "CRRSP01")]
    public static class EGL {
        public enum Errors {
            EGL_NO_SURFACE = 0,
            EGL_BAD_DISPLAY = 0x3008,
            EGL_NOT_INITIALIZED = 0x3001,
            EGL_BAD_CONFIG = 0x3005,
            EGL_BAD_ATTRIBUTE = 0x3004,
            EGL_BAD_ALLOC = 0x3003,
            EGL_BAD_MATCH = 0x3009,
            EGL_SUCCESS = 0x3000
        }

        public const int SURFACE_TYPE = 0x3033;
        public const int PBUFFER_BIT = 0x0001;
        public const int ALPHA_SIZE = 0x3021;
        public const int BLUE_SIZE = 0x3022;
        public const int GREEN_SIZE = 0x3023;
        public const int RED_SIZE = 0x3024;
        public const int DEPTH_SIZE = 0x3025;
        public const int STENCIL_SIZE = 0x3026;
        public const int RENDERABLE_TYPE = 0x3040;
        public const int OPENGL_BIT = 0x0008;
        public const int NONE = 0x3038;
        public const int WIDTH = 0x3057;
        public const int HEIGHT = 0x3056;
        public const int OPENGL_API = 0x30A2;

        public static bool Available {
            get {
                try {
                    PlatformUtils.ConsoleWrite("EGLImport.GetCurrentContext()...");
                    EGLImport.GetCurrentContext();
                    PlatformUtils.ConsoleOk();
                }
                catch (Exception ex) {
                    PlatformUtils.ConsoleError(ex.Message);
                    return false;
                }
                return true;
            }
        }

        public static Errors GetError() {
            return (Errors)EGLImport.GetError();
        }
        public static IntPtr GetDisplay() {
            return EGLImport.GetDisplay(IntPtr.Zero);
        }
        public static bool Initialize(IntPtr display, out int major, out int minor) {
            return EGLImport.Initialize(display, out major, out minor);
        }
        public static bool ChooseConfig(IntPtr display, int[] attributes, out IntPtr config, int configSize, out int configsCount) {
            return EGLImport.ChooseConfig(display, attributes, out config, configSize, out configsCount);
        }
#if DEBUGTEST                       //DEMO_REMOVE
        [FxCopSpellCheckingIgnore]  //DEMO_REMOVE
#endif                              //DEMO_REMOVE
        public static IntPtr CreatePbufferSurface(IntPtr display, IntPtr config, int[] attributes) {
            return EGLImport.CreatePbufferSurface(display, config, attributes);
        }
        public static bool BindAPI(int api) {
            return EGLImport.BindAPI(api);
        }
        public static IntPtr CreateContext(IntPtr display, IntPtr config, IntPtr sharedContext, int[] attributes) {
            return EGLImport.CreateContext(display, config, sharedContext, attributes);
        }
        public static bool MakeCurrent(IntPtr display, IntPtr draw, IntPtr read, IntPtr context) {
            return EGLImport.MakeCurrent(display, draw, read, context);
        }
        public static bool Terminate(IntPtr display) {
            return EGLImport.Terminate(display);
        }
        public static bool DestroySurface(IntPtr display, IntPtr surface) {
            return EGLImport.DestroySurface(display, surface);
        }
        public static bool DestroyContext(IntPtr display, IntPtr context) {
            return EGLImport.DestroyContext(display, context);
        }
    }
}

namespace DevExpress.XtraCharts.GLGraphics {
    public class EGLGraphics : IPlatformGraphics {
        static void WriteEGLErrorToConsole() {
            EGL.Errors errors = EGL.GetError();
            PlatformUtils.ConsoleWriteLine("EGL Error: " + errors.ToString());
        }

        public static bool Available { get { return EGL.Available; } }

        readonly Graphics graphics;
        readonly Rectangle bounds;
        IntPtr display;
        IntPtr pBuffer;
        IntPtr context;

        bool HasPBuffer { get { return pBuffer != IntPtr.Zero; } }
        public bool Initialized { get { return display != IntPtr.Zero && HasPBuffer && context != IntPtr.Zero; } }

        public EGLGraphics(Graphics graphics, Rectangle bounds) {
            PlatformUtils.ConsoleWriteLine("Create EGLGraphics...");
            this.graphics = graphics;
            this.bounds = bounds;
            PlatformUtils.ConsoleWrite("EGL.GetDisplay()...");
            display = EGL.GetDisplay();
            PlatformUtils.ConsoleWriteLine(display.ToString());
            WriteEGLErrorToConsole();
            int major, minor;
            PlatformUtils.ConsoleWrite("EGL.Initialize()...");
            bool initialized = EGL.Initialize(display, out major, out minor);
            PlatformUtils.ConsoleWriteLine(initialized.ToString(), initialized ? ConsoleColor.Green : ConsoleColor.Red);
            bool isValidVersion = major >= 1 && minor >= 4;
            PlatformUtils.ConsoleWriteLine(string.Format("Version: {0}.{1}", major, minor), isValidVersion ? ConsoleColor.Green : ConsoleColor.Red);
            WriteEGLErrorToConsole();
            if (initialized && isValidVersion) {
                int[] attributes = new int[] {
                    EGL.SURFACE_TYPE, EGL.PBUFFER_BIT,
                    EGL.RED_SIZE, 8,
                    EGL.GREEN_SIZE, 8,
                    EGL.BLUE_SIZE, 8,
                    EGL.ALPHA_SIZE, 8,
                    EGL.DEPTH_SIZE, 16,
                    EGL.STENCIL_SIZE, 8,
                    EGL.RENDERABLE_TYPE, EGL.OPENGL_BIT,
                    EGL.NONE
                };
                int configsCount;
                IntPtr config;
                PlatformUtils.ConsoleWrite("EGL.Initialize()...");
                bool hasConfig = EGL.ChooseConfig(display, attributes, out config, 1, out configsCount);
                PlatformUtils.ConsoleWriteLine(hasConfig.ToString(), hasConfig ? ConsoleColor.Green : ConsoleColor.Red);
                PlatformUtils.ConsoleWriteLine(string.Format("{0} configs, configs pointer: {1}", configsCount, config.ToString()));
                WriteEGLErrorToConsole();
                if (hasConfig) {
                    int[] pBufferAttributes = new int[] {
                        EGL.WIDTH, bounds.Width,
                        EGL.HEIGHT, bounds.Height,
                        EGL.NONE
                    };
                    PlatformUtils.ConsoleWrite("EGL.CreatePbufferSurface()...");
                    pBuffer = EGL.CreatePbufferSurface(display, config, pBufferAttributes);
                    PlatformUtils.ConsoleWriteLine(pBuffer.ToString(), HasPBuffer ? ConsoleColor.Green : ConsoleColor.Red);
                    WriteEGLErrorToConsole();
                    PlatformUtils.ConsoleWrite("EGL.BindAPI()...");
                    bool hasAPI = EGL.BindAPI(EGL.OPENGL_API);
                    PlatformUtils.ConsoleWriteLine(hasAPI.ToString(), hasAPI ? ConsoleColor.Green : ConsoleColor.Red);
                    WriteEGLErrorToConsole();
                    if (HasPBuffer && hasAPI){
                        PlatformUtils.ConsoleWrite("EGL.CreateContext()...");
                        context = EGL.CreateContext(display, config, IntPtr.Zero, null);
                        PlatformUtils.ConsoleWriteLine(context.ToString(), Initialized ? ConsoleColor.Green : ConsoleColor.Red);
                        WriteEGLErrorToConsole();
                    }
                }
            }
        }
        public void FinishDrawing() {
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
                BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                GL.ReadBuffer(GL.BACK);
                GL.ReadPixels(0, 0, bitmap.Width, bitmap.Height, GL.BGR_EXT, GL.UNSIGNED_BYTE, srcData.Scan0);
                bitmap.UnlockBits(srcData);
                graphics.DrawImageUnscaled(bitmap, Point.Empty);
            }
        }
        public void Lock() {
        }
        public void Unlock() {
        }
        public void ReleaseCurrent() {
            EGL.MakeCurrent(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }
        public bool MakeCurrent() {
            return EGL.MakeCurrent(display, pBuffer, pBuffer, context);
        }
        public void Dispose() {
            if (pBuffer != IntPtr.Zero) {
                EGL.DestroySurface(display, pBuffer);
                pBuffer = IntPtr.Zero;
            }
            if (context != IntPtr.Zero) {
                EGL.DestroyContext(display, context);
                context = IntPtr.Zero;
            }
            if (display != IntPtr.Zero) {
                EGL.Terminate(display);
                display = IntPtr.Zero;
            }
        }
    }
}
