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
        public const int OSMESA_COLOR_INDEX	             = GL.COLOR_INDEX;
        public const int OSMESA_RGBA		             = GL.RGBA;
        public const int OSMESA_BGRA		             = 0x1;
        public const int OSMESA_ARGB		             = 0x2;
        public const int OSMESA_RGB		                 = GL.RGB;
        public const int OSMESA_BGR		                 = 0x4;
        public const int OSMESA_RGB_565		             = 0x5;
        public const int OSMESA_ROW_LENGTH	             = 0x10;
        public const int OSMESA_Y_UP		             = 0x11;
        public const int OSMESA_WIDTH		             = 0x20;
        public const int OSMESA_HEIGHT	 	             = 0x21;
        public const int OSMESA_FORMAT		             = 0x22;
        public const int OSMESA_TYPE		             = 0x23;
        public const int OSMESA_MAX_WIDTH	             = 0x24;
        public const int OSMESA_MAX_HEIGHT	             = 0x25;
        public const int OSMESA_DEPTH_BITS              = 0x30;
        public const int OSMESA_STENCIL_BITS            = 0x31;
        public const int OSMESA_ACCUM_BITS              = 0x32;
        public const int OSMESA_PROFILE                 = 0x33;
        public const int OSMESA_CORE_PROFILE            = 0x34;
        public const int OSMESA_COMPAT_PROFILE          = 0x35;
        public const int OSMESA_CONTEXT_MAJOR_VERSION   = 0x36;
        public const int OSMESA_CONTEXT_MINOR_VERSION   = 0x37;
        
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
        byte[] buffer;

        int BufferSize { get { return bounds.Width * bounds.Height * 4; } }
        public bool Initialized { get { return context != IntPtr.Zero; } }

        public OSMesaGraphics(Graphics graphics, Rectangle bounds) {
            PlatformUtils.ConsoleWriteLine("Create OSMesaGraphics...");
            this.graphics = graphics;
            this.bounds = bounds;

            buffer = new byte[BufferSize];
            bufferPtr = Marshal.AllocHGlobal(BufferSize);
            Marshal.Copy(buffer, 0, bufferPtr, buffer.Length);

            PlatformUtils.ConsoleWrite("OSMesa.OSMesaCreateContext()...");
            context = OSMesa.OSMesaCreateContextExt(OSMesa.OSMESA_RGBA, 16, 8, 8, IntPtr.Zero);
            PlatformUtils.ConsoleWriteLine(context.ToString());
            WriteGLErrorToConsole();
        }
        public void FinishDrawing() {
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height)) {
                Marshal.Copy(bufferPtr, buffer, 0, buffer.Length);
                BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                srcData.Scan0 = bufferPtr;
                bitmap.UnlockBits(srcData);
                graphics.DrawImageUnscaled(bitmap, Point.Empty);
            }
        }
        public void Lock() {
        }
        public void Unlock() {
        }
        public void ReleaseCurrent() {
            OSMesa.OSMesaMakeCurrent(IntPtr.Zero, IntPtr.Zero, OSMesa.OSMESA_RGBA, 0, 0);
        }
        public bool MakeCurrent() {
            return OSMesa.OSMesaMakeCurrent(context, bufferPtr, OSMesa.OSMESA_RGBA, bounds.Width, bounds.Height);
        }
        public void Dispose() {
            if (context != IntPtr.Zero) {
                OSMesa.OSMesaDestroyContext(context);
                context = IntPtr.Zero;
            }
        }
    }
}
