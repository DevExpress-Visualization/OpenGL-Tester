using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using DevExpress.XtraCharts.GLGraphics.Platform;

namespace DevExpress.XtraCharts.GLGraphics.Platform {
    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class WGLImport {
        const string Gdi32 = "gdi32.dll";
        const string OpenGL32 = "opengl32.dll";

        [DllImport(Gdi32)]
        public static extern int DescribePixelFormat(IntPtr hdc, int iPixelFormat, int nBytes, [In, Out] WGL.PIXELFORMATDESCRIPTOR ppfd);
        [DllImport(Gdi32)]
        public static extern int ChoosePixelFormat(IntPtr hdc, [In] WGL.PIXELFORMATDESCRIPTOR ppfd);
        [DllImport(Gdi32)]
        public static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat, WGL.PIXELFORMATDESCRIPTOR ppfd);
        [DllImport(Gdi32)]
        public static extern bool SwapBuffers(IntPtr hdc);
        [DllImport(OpenGL32, EntryPoint = "wglCreateContext")]
        public static extern IntPtr CreateContext(IntPtr hdc);
        [DllImport(OpenGL32, EntryPoint = "wglDeleteContext")]
        public static extern bool DeleteContext(IntPtr hglrc);
        [DllImport(OpenGL32, EntryPoint = "wglMakeCurrent")]
        public static extern bool MakeCurrent(IntPtr hdc, IntPtr hglrc);
    }

    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class WGL {
        public const uint PFD_DOUBLEBUFFER = 0x00000001;
        public const uint PFD_STEREO = 0x00000002;
        public const uint PFD_DRAW_TO_WINDOW = 0x00000004;
        public const uint PFD_DRAW_TO_BITMAP = 0x00000008;
        public const uint PFD_SUPPORT_GDI = 0x00000010;
        public const uint PFD_SUPPORT_OPENGL = 0x00000020;
        public const uint PFD_GENERIC_FORMAT = 0x00000040;
        public const uint PFD_NEED_PALETTE = 0x00000080;
        public const uint PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        public const uint PFD_SWAP_EXCHANGE = 0x00000200;
        public const uint PFD_SWAP_COPY = 0x00000400;
        public const uint PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        public const uint PFD_GENERIC_ACCELERATED = 0x00001000;
        public const uint PFD_SUPPORT_DIRECTDRAW = 0x00002000;
        public const uint PFD_DIRECT3D_ACCELERATED = 0x00004000;
        public const uint PFD_SUPPORT_COMPOSITION = 0x00008000;
        public const uint PFD_DEPTH_DONTCARE = 0x20000000;
        public const uint PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
        public const uint PFD_STEREO_DONTCARE = 0x80000000;
        public const byte PFD_TYPE_RGBA = 0;
        public const byte PFD_TYPE_COLORINDEX = 1;
        public const byte PFD_MAIN_PLANE = 0;
        public const byte PFD_OVERLAY_PLANE = 1;
        public const byte PFD_UNDERLAY_PLANE = 255;

        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("SpellChecker", "CRRSP01")]
        public class PIXELFORMATDESCRIPTOR {
            public short nSize;
            public short nVersion;
            public uint dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerType;
            public byte bReserved;
            public int dwLayerMask;
            public int dwVisibleMask;
            public int dwDamageMask;
            public PIXELFORMATDESCRIPTOR() {
                nSize = (short)Marshal.SizeOf(this);
                nVersion = 1;
                iPixelType = WGL.PFD_TYPE_RGBA;
                cColorBits = 24;
                cDepthBits = 32;
                iLayerType = WGL.PFD_MAIN_PLANE;
            }
        }

        [SecuritySafeCritical]
        public static int DescribePixelFormat(IntPtr hdc, int iPixelFormat, int nBytes, PIXELFORMATDESCRIPTOR ppfd) {
            return WGLImport.DescribePixelFormat(hdc, iPixelFormat, nBytes, ppfd);
        }
        [SecuritySafeCritical]
        public static int ChoosePixelFormat(IntPtr hdc, PIXELFORMATDESCRIPTOR ppfd) {
            return WGLImport.ChoosePixelFormat(hdc, ppfd);
        }
        [SecuritySafeCritical]
        public static bool SetPixelFormat(IntPtr hdc, int iPixelFormat, PIXELFORMATDESCRIPTOR ppfd) {
            return WGLImport.SetPixelFormat(hdc, iPixelFormat, ppfd);
        }
        [SecuritySafeCritical]
        public static bool SwapBuffers(IntPtr hdc) {
            return WGLImport.SwapBuffers(hdc);
        }
        [SecuritySafeCritical]
        public static IntPtr CreateContext(IntPtr hdc) {
            return WGLImport.CreateContext(hdc);
        }
        [SecuritySafeCritical]
        public static bool DeleteContext(IntPtr hglrc) {
            bool result;
            try {
                result = WGLImport.DeleteContext(hglrc);
            }
            catch (AccessViolationException) {
                result = false;
            }
            return result;
        }
        [SecuritySafeCritical]
        public static bool MakeCurrent(IntPtr hdc, IntPtr hglrc) {
            return WGLImport.MakeCurrent(hdc, hglrc);
        }
    }
}

namespace DevExpress.XtraCharts.GLGraphics {
    public class WGLGraphics : IPlatformGraphics {
        readonly Graphics graphics;
        bool isWindowDC;
        bool isDoubleBuffered;
        IntPtr hdc;
        IntPtr hglrc;

        public bool Initialized { get { return hdc != IntPtr.Zero && hglrc != IntPtr.Zero; } }

        public WGLGraphics(Graphics graphics, IntPtr windowDC) {
            this.graphics = graphics;
            if (windowDC == IntPtr.Zero) {
                isWindowDC = false;
                hdc = graphics.GetHdc();
            }
            else {
                isWindowDC = true;
                hdc = windowDC;
            }
            CreateWGLContext();
        }
        void CreateWGLContext() {
            WGL.PIXELFORMATDESCRIPTOR pfd = new WGL.PIXELFORMATDESCRIPTOR();
            pfd.dwFlags = WGL.PFD_SUPPORT_OPENGL | WGL.PFD_GENERIC_ACCELERATED | WGL.PFD_STEREO_DONTCARE;
            if (isWindowDC)
                pfd.dwFlags |= WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_GENERIC_ACCELERATED | WGL.PFD_DOUBLEBUFFER;
            else
                pfd.dwFlags |= WGL.PFD_DRAW_TO_BITMAP;
            pfd.cAccumBits = 64;
            pfd.cStencilBits = 32;
            int pixelFormat = WGL.ChoosePixelFormat(hdc, pfd);
            int count = WGL.DescribePixelFormat(hdc, pixelFormat, Marshal.SizeOf(pfd), pfd);
            if (count == 0)
                return;
            if (pixelFormat != 0 && CreateWGLContext(hdc, pixelFormat, pfd))
                return;
            for (int i = 1; i <= count; i++) {
                if (WGL.DescribePixelFormat(hdc, i, Marshal.SizeOf(pfd), pfd) == 0 ||
                    pfd.iPixelType != WGL.PFD_TYPE_RGBA || pfd.cStencilBits < 8 ||
                    pfd.cAccumBits < 32 ||
                    (pfd.dwFlags & WGL.PFD_SUPPORT_OPENGL) != WGL.PFD_SUPPORT_OPENGL)
                    continue;
                if (isWindowDC) {
                    if ((pfd.dwFlags & (WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_DOUBLEBUFFER)) != (WGL.PFD_DRAW_TO_WINDOW | WGL.PFD_DOUBLEBUFFER))
                        continue;
                }
                else if ((pfd.dwFlags & WGL.PFD_DRAW_TO_BITMAP) != WGL.PFD_DRAW_TO_BITMAP)
                    continue;
                if (CreateWGLContext(hdc, i, pfd))
                    return;
            }
        }
        [SuppressMessage("SpellChecker", "CRRSP01")]
        bool CreateWGLContext(IntPtr drawable, int pixelFormat, WGL.PIXELFORMATDESCRIPTOR pfd) {
            if (!WGL.SetPixelFormat(drawable, pixelFormat, pfd))
                return false;
            hglrc = WGL.CreateContext(drawable);
            if (hglrc == IntPtr.Zero)
                return false;
            isDoubleBuffered = (pfd.dwFlags & WGL.PFD_DOUBLEBUFFER) == WGL.PFD_DOUBLEBUFFER;
            return true;
        }
        public void FinishDrawing() {
            if (isDoubleBuffered)
                WGL.SwapBuffers(hdc);
        }
        public void Lock() {
        }
        public void Unlock() {
        }
        public void ReleaseCurrent() {
            WGL.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
        }
        public void Dispose() {
            if (!isWindowDC && hdc != IntPtr.Zero) {
                graphics.ReleaseHdcInternal(hdc);
                hdc = IntPtr.Zero;
            }
            if (hglrc != IntPtr.Zero) {
                WGL.DeleteContext(hglrc);
                hglrc = IntPtr.Zero;
            }
        }
        public bool MakeCurrent() {
            return WGL.MakeCurrent(hdc, hglrc);
        }
    }
}
