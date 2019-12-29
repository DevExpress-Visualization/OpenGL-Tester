using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security;
using DevExpress.XtraCharts.GLGraphics.Platform;

namespace DevExpress.XtraCharts.GLGraphics.Platform {
    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class GLXImport {
        const string LibX11 = "libX11.so.6";
        const string LibGL= "libGL.so.1";

        [DllImport(LibX11, EntryPoint = "XInitThreads")]
        public extern static int XInitThreads();
        [DllImport(LibX11, EntryPoint = "XLockDisplay")]
        public extern static void XLockDisplay(IntPtr display);
        [DllImport(LibX11, EntryPoint = "XUnlockDisplay")]
        public extern static void XUnlockDisplay(IntPtr display);
        [DllImport(LibX11, EntryPoint = "XOpenDisplay")]
        public extern static IntPtr XOpenDisplay(IntPtr display);
        [DllImport(LibX11, EntryPoint = "XCloseDisplay")]
        public extern static int XCloseDisplay(IntPtr display);
        [DllImport(LibX11, EntryPoint = "XDefaultScreen")]
        public extern static int XDefaultScreen(IntPtr display);
        [DllImport(LibX11, EntryPoint = "XRootWindow")]
        public extern static IntPtr XRootWindow(IntPtr display, int screen);
        [DllImport(LibX11, EntryPoint = "XCreateSimpleWindow")]
        public extern static IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent,
            int x, int y, int width, int height, int border_width, long border, long background);
        [DllImport(LibX11, EntryPoint = "XDestroyWindow")]
        public extern static int XDestroyWindow(IntPtr display, IntPtr window);
        [DllImport(LibX11, EntryPoint = "XMapWindow")]
        public extern static int XMapWindow(IntPtr display, IntPtr window);
        [DllImport(LibGL, EntryPoint = "glXChooseVisual")]
        public static extern IntPtr ChooseVisual(IntPtr display, int screen, int[] attribList);
        [DllImport(LibGL, EntryPoint = "glXSwapBuffers")]
        public static extern void SwapBuffers(IntPtr display, IntPtr drawable);
        [DllImport(LibGL, EntryPoint = "glXCreateContext")]
        public static extern IntPtr CreateContext(IntPtr display, IntPtr visualInfo, IntPtr shareList, bool direct);
        [DllImport(LibGL, EntryPoint = "glXCreateNewContext")]
        public static extern IntPtr CreateNewContext(IntPtr display, IntPtr fbConfig, int renderType, IntPtr shareList, bool direct);
        [DllImport(LibGL, EntryPoint = "glXDestroyContext")]
        public static extern void DestroyContext(IntPtr display, IntPtr context);
        [DllImport(LibGL, EntryPoint = "glXMakeCurrent")]
        public static extern bool MakeCurrent(IntPtr display, IntPtr drawable, IntPtr context);
        [DllImport(LibGL, EntryPoint = "glXChooseFBConfig")]
        public extern static IntPtr ChooseFBConfig(IntPtr display, int screen, int[] attribList, out int fbCount);
        [DllImport(LibGL, EntryPoint = "glXCreatePbuffer")]
        public extern static IntPtr CreatePbuffer(IntPtr display, IntPtr fbconfig, int[] attribList);
        [DllImport(LibGL, EntryPoint = "glXDestroyPbuffer")]
        public extern static void DestroyPbuffer(IntPtr display, IntPtr pbuffer);
    }

    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class GLX {
        public static int XInitThreads() {
            return GLXImport.XInitThreads();
        }
        public static void XLockDisplay(IntPtr display) {
            GLXImport.XLockDisplay(display);
        }
        public static void XUnlockDisplay(IntPtr display) {
            GLXImport.XUnlockDisplay(display);
        }
        public static int XDefaultScreen(IntPtr display) {
            return GLXImport.XDefaultScreen(display);
        }
        public static IntPtr XOpenDisplay() {
            return GLXImport.XOpenDisplay(IntPtr.Zero);
        }
        public static int XCloseDisplay(IntPtr display) {
            return GLXImport.XCloseDisplay(display);
        }
        public static IntPtr XRootWindow(IntPtr display, int screen) {
            return GLXImport.XRootWindow(display, screen);
        }
        public static IntPtr XCreateSimpleWindow(IntPtr display, IntPtr parent,
            int x, int y, int width, int height, int border_width, long border, long background) {
            return GLXImport.XCreateSimpleWindow(display, parent, x, y, width, height, border_width, border, background);
        }
        public static int XDestroyWindow(IntPtr display, IntPtr window) {
            return GLXImport.XDestroyWindow(display, window);
        }
        public static int XMapWindow(IntPtr display, IntPtr window) {
            return GLXImport.XMapWindow(display, window);
        }
        public static IntPtr ChooseVisual(IntPtr display, int screen, int[] attributes) {
            return GLXImport.ChooseVisual(display, screen, attributes);
        }
        public static IntPtr CreateContext(IntPtr display, IntPtr visualInfo, IntPtr shareList, bool direct) {
            return GLXImport.CreateContext(display, visualInfo, shareList, direct);
        }
        public static IntPtr CreateNewContext(IntPtr display, IntPtr fbConfig, int renderType, IntPtr shareList, bool direct) {
            return GLXImport.CreateNewContext(display, fbConfig, renderType, shareList, direct);
        }
        public static void DestroyContext(IntPtr display, IntPtr context) {
            GLXImport.DestroyContext(display, context);
        }
        public static bool MakeCurrent(IntPtr display, IntPtr drawable, IntPtr context) {
            return GLXImport.MakeCurrent(display, drawable, context);
        }
        public static void SwapBuffers(IntPtr display, IntPtr drawable) {
            GLXImport.SwapBuffers(display, drawable);
        }
        public static IntPtr ChooseFBConfig(IntPtr display, int screen, int[] attribList) {
            int count;
            IntPtr configsPtr = GLXImport.ChooseFBConfig(display, screen, attribList, out count);
            if (count > 0) {
                IntPtr[] configs = new IntPtr[count];
                Marshal.Copy(configsPtr, configs, 0, count);
                return configs[0];
            }
            return IntPtr.Zero;
        }
        public static IntPtr CreatePbuffer(IntPtr display, IntPtr fbconfig, int[] attribList) {
            return GLXImport.CreatePbuffer(display, fbconfig, attribList);
        }
        public static void DestroyPbuffer(IntPtr display, IntPtr pbuffer) {
            GLXImport.DestroyPbuffer(display, pbuffer);
        }
    }

    public enum GLXAttribute {
        WINDOW_BIT = 0x00000001,
        PIXMAP_BIT = 0x00000002,
        PBUFFER_BIT = 0x00000004,
        RGBA_BIT = 0x0001,
        TRANSPARENT_BLUE_VALUE_EXT = 0x27,
        GRAY_SCALE = 0x8006,
        RGBA_TYPE = 0x8014,
        TRANSPARENT_RGB_EXT = 0x8008,
        ACCUM_BLUE_SIZE = 16,
        SHARE_CONTEXT_EXT = 0x800A,
        STEREO = 6,
        ALPHA_SIZE = 11,
        FLOAT_COMPONENTS_NV = 0x20B0,
        NONE = 0x8000,
        DEPTH_SIZE = 12,
        TRANSPARENT_INDEX_VALUE_EXT = 0x24,
        MAX_PBUFFER_WIDTH_SGIX = 0x8016,
        GREEN_SIZE = 9,
        X_RENDERABLE_SGIX = 0x8012,
        LARGEST_PBUFFER = 0x801C,
        DONT_CARE = unchecked((int)0xFFFFFFFF),
        TRANSPARENT_ALPHA_VALUE_EXT = 0x28,
        PSEUDO_COLOR_EXT = 0x8004,
        USE_GL = 1,
        SAMPLE_BUFFERS_SGIS = 100000,
        TRANSPARENT_GREEN_VALUE_EXT = 0x26,
        HYPERPIPE_ID_SGIX = 0x8030,
        COLOR_INDEX_TYPE_SGIX = 0x8015,
        SLOW_CONFIG = 0x8001,
        PRESERVED_CONTENTS = 0x801B,
        ACCUM_RED_SIZE = 14,
        EVENT_MASK = 0x801F,
        VISUAL_ID_EXT = 0x800B,
        EVENT_MASK_SGIX = 0x801F,
        SLOW_VISUAL_EXT = 0x8001,
        TRANSPARENT_GREEN_VALUE = 0x26,
        MAX_PBUFFER_WIDTH = 0x8016,
        DIRECT_COLOR_EXT = 0x8003,
        VISUAL_ID = 0x800B,
        ACCUM_GREEN_SIZE = 15,
        DRAWABLE_TYPE_SGIX = 0x8010,
        SCREEN_EXT = 0x800C,
        SAMPLES = 100001,
        HEIGHT = 0x801E,
        TRANSPARENT_INDEX_VALUE = 0x24,
        SAMPLE_BUFFERS_ARB = 100000,
        PBUFFER = 0x8023,
        RGBA_TYPE_SGIX = 0x8014,
        MAX_PBUFFER_HEIGHT = 0x8017,
        FBCONFIG_ID_SGIX = 0x8013,
        DRAWABLE_TYPE = 0x8010,
        SCREEN = 0x800C,
        RED_SIZE = 8,
        VISUAL_SELECT_GROUP_SGIX = 0x8028,
        VISUAL_CAVEAT_EXT = 0x20,
        PSEUDO_COLOR = 0x8004,
        PBUFFER_HEIGHT = 0x8040,
        STATIC_GRAY = 0x8007,
        PRESERVED_CONTENTS_SGIX = 0x801B,
        RGBA_FLOAT_TYPE_ARB = 0x20B9,
        TRANSPARENT_RED_VALUE = 0x25,
        TRANSPARENT_ALPHA_VALUE = 0x28,
        WINDOW = 0x8022,
        X_RENDERABLE = 0x8012,
        STENCIL_SIZE = 13,
        TRANSPARENT_RGB = 0x8008,
        LARGEST_PBUFFER_SGIX = 0x801C,
        STATIC_GRAY_EXT = 0x8007,
        TRANSPARENT_BLUE_VALUE = 0x27,
        DIGITAL_MEDIA_PBUFFER_SGIX = 0x8024,
        BLENDED_RGBA_SGIS = 0x8025,
        NON_CONFORMANT_VISUAL_EXT = 0x800D,
        COLOR_INDEX_TYPE = 0x8015,
        TRANSPARENT_RED_VALUE_EXT = 0x25,
        GRAY_SCALE_EXT = 0x8006,
        WINDOW_SGIX = 0x8022,
        X_VISUAL_TYPE = 0x22,
        MAX_PBUFFER_HEIGHT_SGIX = 0x8017,
        DOUBLEBUFFER = 5,
        OPTIMAL_PBUFFER_WIDTH_SGIX = 0x8019,
        X_VISUAL_TYPE_EXT = 0x22,
        WIDTH_SGIX = 0x801D,
        STATIC_COLOR_EXT = 0x8005,
        BUFFER_SIZE = 2,
        DIRECT_COLOR = 0x8003,
        MAX_PBUFFER_PIXELS = 0x8018,
        NONE_EXT = 0x8000,
        HEIGHT_SGIX = 0x801E,
        RENDER_TYPE = 0x8011,
        FBCONFIG_ID = 0x8013,
        TRANSPARENT_INDEX_EXT = 0x8009,
        TRANSPARENT_INDEX = 0x8009,
        TRANSPARENT_TYPE_EXT = 0x23,
        ACCUM_ALPHA_SIZE = 17,
        PBUFFER_SGIX = 0x8023,
        MAX_PBUFFER_PIXELS_SGIX = 0x8018,
        OPTIMAL_PBUFFER_HEIGHT_SGIX = 0x801A,
        DAMAGED = 0x8020,
        SAVED_SGIX = 0x8021,
        TRANSPARENT_TYPE = 0x23,
        MULTISAMPLE_SUB_RECT_WIDTH_SGIS = 0x8026,
        NON_CONFORMANT_CONFIG = 0x800D,
        BLUE_SIZE = 10,
        TRUE_COLOR_EXT = 0x8002,
        SAMPLES_SGIS = 100001,
        SAMPLES_ARB = 100001,
        TRUE_COLOR = 0x8002,
        RGBA = 4,
        AUX_BUFFERS = 7,
        SAMPLE_BUFFERS = 100000,
        SAVED = 0x8021,
        MULTISAMPLE_SUB_RECT_HEIGHT_SGIS = 0x8027,
        DAMAGED_SGIX = 0x8020,
        STATIC_COLOR = 0x8005,
        PBUFFER_WIDTH = 0x8041,
        WIDTH = 0x801D,
        LEVEL = 3,
        CONFIG_CAVEAT = 0x20,
        RENDER_TYPE_SGIX = 0x8011,
        SWAP_INTERVAL_EXT = 0x20F1,
        MAX_SWAP_INTERVAL_EXT = 0x20F2,
    }
}

namespace DevExpress.XtraCharts.GLGraphics {
    public class GLXGraphics : IPlatformGraphics {
        static void WriteGLErrorToConsole() {
            int error = GL.GetError();
            PlatformUtils.ConsoleWriteLine("GL Error: " + error.ToString(), error != 0 ? ConsoleColor.Red : ConsoleColor.Green);
        }

        readonly Graphics graphics;
        readonly Rectangle bounds;
        readonly bool isMultiThread;
        IntPtr display;
        IntPtr pBuffer;
        IntPtr xWindow;
        IntPtr context;

        IntPtr Drawable { get { return pBuffer != IntPtr.Zero ? pBuffer : xWindow; } }
        public bool Initialized { get { return display != IntPtr.Zero && Drawable != IntPtr.Zero && context != IntPtr.Zero; } }

        public GLXGraphics(Graphics graphics, Rectangle bounds) {
            PlatformUtils.ConsoleWriteLine("Create GLXGraphics...");

            this.graphics = graphics;
            this.bounds = bounds;

            PlatformUtils.ConsoleWrite("GLX.XInitThreads()>0...");
            isMultiThread = GLX.XInitThreads() > 0;
            PlatformUtils.ConsoleWriteLine(isMultiThread.ToString(), isMultiThread ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            PlatformUtils.ConsoleWrite("GLX.XOpenDisplay()...");
            display = GLX.XOpenDisplay();
            PlatformUtils.ConsoleWriteLine(display.ToString(), display != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            if (display != IntPtr.Zero) {
                PlatformUtils.ConsoleWrite("GLX.XDefaultScreen()...");
                int screen = GLX.XDefaultScreen(display);
                PlatformUtils.ConsoleWriteLine(screen.ToString());
                WriteGLErrorToConsole();

                Lock();
                if (!CreateGLXOffscreenContext(screen))
                    CreateGLXWindowContext(screen, false);
                Unlock();
            }
        }
        void CreateGLXWindowContext(int screen, bool showWindow) {
            int[] attributes = new int[] {
                 (int)GLXAttribute.RGBA,
                 (int)GLXAttribute.RED_SIZE, 8,
                 (int)GLXAttribute.GREEN_SIZE, 8,
                 (int)GLXAttribute.BLUE_SIZE, 8,
                 (int)GLXAttribute.DEPTH_SIZE, 16,
                 (int)GLXAttribute.STENCIL_SIZE, 8,
                 (int)GLXAttribute.DOUBLEBUFFER,
                 0, 0
            };

            PlatformUtils.ConsoleWrite("GLX.XRootWindow()...");
            IntPtr rootWindow = GLX.XRootWindow(display, screen);
            PlatformUtils.ConsoleWriteLine(rootWindow.ToString(), rootWindow != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            PlatformUtils.ConsoleWrite("GLX.ChooseVisual()...");
            IntPtr visualInfoPtr = GLX.ChooseVisual(display, screen, attributes);
            PlatformUtils.ConsoleWriteLine(visualInfoPtr.ToString(), visualInfoPtr != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            PlatformUtils.ConsoleWrite("GLX.CreateContext()...");
            context = GLX.CreateContext(display, visualInfoPtr, IntPtr.Zero, true);
            PlatformUtils.ConsoleWriteLine(context.ToString(), context != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            if (context == IntPtr.Zero) {
                PlatformUtils.ConsoleWrite("GLX.CreateContext()...");
                context = GLX.CreateContext(display, visualInfoPtr, IntPtr.Zero, false);
                PlatformUtils.ConsoleWriteLine(context.ToString(), context != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
                WriteGLErrorToConsole();
            }

            PlatformUtils.ConsoleWrite("GLX.XCreateSimpleWindow()...");
            xWindow = GLX.XCreateSimpleWindow(display, rootWindow, 0, 0, bounds.Width, bounds.Height, 0, 0, Color.White.ToArgb());
            PlatformUtils.ConsoleWriteLine(xWindow.ToString(), xWindow != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            if (showWindow)
                GLX.XMapWindow(display, xWindow);
        }
        bool CreateGLXOffscreenContext(int screen) {
            int[] attributes = new int[] {
                (int)GLXAttribute.DRAWABLE_TYPE, (int)GLXAttribute.PBUFFER_BIT,
                (int)GLXAttribute.RENDER_TYPE, (int)GLXAttribute.RGBA_BIT,
                (int)GLXAttribute.RED_SIZE, 8,
                (int)GLXAttribute.GREEN_SIZE, 8,
                (int)GLXAttribute.BLUE_SIZE, 8,
                (int)GLXAttribute.ALPHA_SIZE, 8,
                (int)GLXAttribute.DEPTH_SIZE, 16,
                (int)GLXAttribute.STENCIL_SIZE, 8,
                0
            };

            int[] pBufferAttributes = new int[] {
                (int)GLXAttribute.PBUFFER_WIDTH, bounds.Width,
                (int)GLXAttribute.PBUFFER_HEIGHT, bounds.Width,
                (int)GLXAttribute.PRESERVED_CONTENTS, 1,
                (int)GLXAttribute.LARGEST_PBUFFER, 0,
                0, 0
            };

            PlatformUtils.ConsoleWrite("GLX.ChooseFBConfig()...");
            IntPtr fbConfig = GLX.ChooseFBConfig(display, screen, attributes);
            PlatformUtils.ConsoleWriteLine(fbConfig.ToString(), fbConfig != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
            WriteGLErrorToConsole();

            if (fbConfig != IntPtr.Zero) {
                try {
                    PlatformUtils.ConsoleWrite("GLX.CreatePbuffer()...");
                    pBuffer = GLX.CreatePbuffer(display, fbConfig, pBufferAttributes);
                    PlatformUtils.ConsoleWriteLine(pBuffer.ToString(), pBuffer != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
                    WriteGLErrorToConsole();

                    PlatformUtils.ConsoleWrite("GLX.CreateNewContext()...");
                    context = GLX.CreateNewContext(display, fbConfig, (int)GLXAttribute.RGBA_TYPE, IntPtr.Zero, true);
                    PlatformUtils.ConsoleWriteLine(context.ToString(), context != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
                    WriteGLErrorToConsole();

                    if (context == IntPtr.Zero) {
                        PlatformUtils.ConsoleWrite("GLX.CreateNewContext()...");
                        context = GLX.CreateNewContext(display, fbConfig, (int)GLXAttribute.RGBA_TYPE, IntPtr.Zero, false);
                        PlatformUtils.ConsoleWriteLine(context.ToString(), context != IntPtr.Zero ? ConsoleColor.Green : ConsoleColor.Red);
                        WriteGLErrorToConsole();
                    }
                }
                catch {
                    if (pBuffer != IntPtr.Zero)
                        GLX.DestroyPbuffer(display, pBuffer);
                }
            }
            return context != IntPtr.Zero;
        }
        void CopyPixels(int format, PixelFormat pixelFormat) {
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
                BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, pixelFormat);
                GL.ReadBuffer(GL.BACK);
                GL.ReadPixels(0, 0, bitmap.Width, bitmap.Height, format, GL.UNSIGNED_BYTE, srcData.Scan0);
                bitmap.UnlockBits(srcData);
                graphics.DrawImageUnscaled(bitmap, Point.Empty);
            }
        }
        public void FinishDrawing() {
            if (xWindow != IntPtr.Zero)
                CopyPixels(GL.BGRA_EXT, PixelFormat.Format32bppArgb);
            else
                CopyPixels(GL.BGR_EXT, PixelFormat.Format24bppRgb);
        }
        public void Lock() {
            if (isMultiThread) {
                PlatformUtils.ConsoleWriteLine("GLX.XOpenDisplay()");
                GLX.XLockDisplay(display);
                WriteGLErrorToConsole();
            }
        }
        public void Unlock() {
            if (isMultiThread) {
                PlatformUtils.ConsoleWriteLine("GLX.XUnlockDisplay()");
                GLX.XUnlockDisplay(display);
                WriteGLErrorToConsole();
            }
        }
        public void ReleaseCurrent() {
            GLX.MakeCurrent(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }
        public void Dispose() {
            if (xWindow != IntPtr.Zero) {
                GLX.XDestroyWindow(display, xWindow);
                xWindow = IntPtr.Zero;
            }
            if (pBuffer != IntPtr.Zero) {
                GLX.DestroyPbuffer(display, pBuffer);
                pBuffer = IntPtr.Zero;
            }
            if (context != IntPtr.Zero) {
                GLX.DestroyContext(display, context);
                context = IntPtr.Zero;
            }
            if (display != IntPtr.Zero) {
                GLX.XCloseDisplay(display);
                display = IntPtr.Zero;
            }
        }
        public bool MakeCurrent() {
            return GLX.MakeCurrent(display, Drawable, context);
        }
    }
}