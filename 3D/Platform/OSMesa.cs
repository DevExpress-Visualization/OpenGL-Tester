using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security;
using DevExpress.XtraCharts.GLGraphics;
using DevExpress.XtraCharts.GLGraphics.Platform;

namespace DevExpress.XtraCharts.GLGraphics.Platform {
    public static class OSMesaImport {
        const string libOSMesa = "libOSMesa.so.8";

        [DllImportAttribute(libOSMesa, EntryPoint = "OSMesaCreateContext")]
        public static extern IntPtr OSMesaCreateContext(uint format, IntPtr shareList);
        [DllImportAttribute(libOSMesa, EntryPoint = "OSMesaCreateContextExt")]
        public static extern IntPtr OSMesaCreateContextExt(uint format, int depthBits, int stencilBits, int accumBits, IntPtr shareList);
        [DllImportAttribute(libOSMesa, EntryPoint = "OSMesaDestroyContext")]
        public static extern void OSMesaDestroyContext(IntPtr context);
        [DllImportAttribute(libOSMesa, EntryPoint = "OSMesaMakeCurrent")]
        public static extern bool OSMesaMakeCurrent(IntPtr context, IntPtr buffer, uint type, int width, int height );
    }

    public static class OSMesa {
        public const uint OSMESA_COLOR_INDEX	             = GL.COLOR_INDEX;
        public const uint OSMESA_RGBA		             = GL.RGBA;
        public const uint OSMESA_BGRA		             = 0x1;
        public const uint OSMESA_ARGB		             = 0x2;
        public const uint OSMESA_RGB		                 = GL.RGB;
        public const uint OSMESA_BGR		                 = 0x4;
        public const uint OSMESA_RGB_565		             = 0x5;
        public const uint OSMESA_ROW_LENGTH	             = 0x10;
        public const uint OSMESA_Y_UP		             = 0x11;
        public const uint OSMESA_WIDTH		             = 0x20;
        public const uint OSMESA_HEIGHT	 	             = 0x21;
        public const uint OSMESA_FORMAT		             = 0x22;
        public const uint OSMESA_TYPE		             = 0x23;
        public const uint OSMESA_MAX_WIDTH	             = 0x24;
        public const uint OSMESA_MAX_HEIGHT	             = 0x25;
        public const uint OSMESA_DEPTH_BITS              = 0x30;
        public const uint OSMESA_STENCIL_BITS            = 0x31;
        public const uint OSMESA_ACCUM_BITS              = 0x32;
        public const uint OSMESA_PROFILE                 = 0x33;
        public const uint OSMESA_CORE_PROFILE            = 0x34;
        public const uint OSMESA_COMPAT_PROFILE          = 0x35;
        public const uint OSMESA_CONTEXT_MAJOR_VERSION   = 0x36;
        public const uint OSMESA_CONTEXT_MINOR_VERSION   = 0x37;
        
        public static IntPtr OSMesaCreateContext(uint format, IntPtr shareList) {
            return OSMesaImport.OSMesaCreateContext(format, shareList);
        }
        public static IntPtr OSMesaCreateContextExt(uint format, int depthBits, int stencilBits, int accumBits, IntPtr shareList) {
            return OSMesaImport.OSMesaCreateContextExt(format, depthBits, stencilBits, accumBits, shareList);
        }
        public static void OSMesaDestroyContext(IntPtr context) {
            OSMesaImport.OSMesaDestroyContext(context);
        }
        public static bool OSMesaMakeCurrent(IntPtr context, IntPtr buffer, uint type, int width, int height ) {
            return OSMesaImport.OSMesaMakeCurrent(context, buffer, type, width, height);
        }
    }
}

namespace DevExpress.XtraCharts.GLGraphics {
    public class OSMesaGraphics : IPlatformGraphics {
        static void WriteGLErrorToConsole() {
            int error = GL.GetError();
            PlatformUtils.ConsoleWriteLine("GL Error: " + error.ToString(), error != 0 ? ConsoleColor.Red : ConsoleColor.Green);
        }

        readonly Graphics graphics;
        readonly Rectangle bounds;
        IntPtr bufferPtr;
        IntPtr context;

        int BufferSize { get { return bounds.Width * bounds.Height * 4; } }
        public bool Initialized { get { return context != IntPtr.Zero; } }

        public OSMesaGraphics(Graphics graphics, Rectangle bounds) {
            PlatformUtils.ConsoleWriteLine("Create OSMesaGraphics...");
            this.graphics = graphics;
            this.bounds = bounds;

            bufferPtr = Marshal.AllocHGlobal(BufferSize);

            PlatformUtils.ConsoleWrite("OSMesa.OSMesaCreateContext()...");
            context = OSMesa.OSMesaCreateContext(OSMesa.OSMESA_RGBA, IntPtr.Zero);
            PlatformUtils.ConsoleWriteLine(context.ToString());
            WriteGLErrorToConsole();
        }
        public void FinishDrawing() {
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
                BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                GL.ReadPixels(0, 0, bitmap.Width, bitmap.Height, GL.BGRA_EXT, GL.UNSIGNED_BYTE, srcData.Scan0);
                bitmap.UnlockBits(srcData);
                graphics.DrawImageUnscaled(bitmap, Point.Empty);
            }
        }
        public void Lock() {
        }
        public void Unlock() {
        }
        public void ReleaseCurrent() {
        }
        public bool MakeCurrent() {
            return OSMesa.OSMesaMakeCurrent(context, bufferPtr, GL.UNSIGNED_BYTE, bounds.Width, bounds.Height);
        }
        public void Dispose() {
            if (context != IntPtr.Zero) {
                OSMesa.OSMesaDestroyContext(context);
                context = IntPtr.Zero;
            }
            if (bufferPtr != IntPtr.Zero) {
                Marshal.FreeHGlobal(bufferPtr);
                bufferPtr = IntPtr.Zero;
            }
        }
    }
}
