using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DevExpress.XtraCharts.GLGraphics {
    public interface IPlatformGraphics : IDisposable {
        bool Initialized { get; }

        void FinishDrawing();
        void Lock();
        void Unlock();
        void ReleaseCurrent();
        bool MakeCurrent();
    }

    public static class PlatformUtils {
        public static bool IsWindows { get { return RuntimeInformation.IsOSPlatform (OSPlatform.Windows); } }
        public static bool IsMacOS { get { return RuntimeInformation.IsOSPlatform (OSPlatform.OSX); } }
        public static bool IsLinux { get { return RuntimeInformation.IsOSPlatform (OSPlatform.Linux); } }

        public static IPlatformGraphics CreatePlatformGraphics(Graphics graphics, Rectangle bounds, IntPtr windowDC) {
            if (IsWindows)
                return new WGLGraphics(graphics, windowDC);
            else if (IsLinux) {
                if (EGLGraphics.Available) {
                    EGLGraphics eglGraphics = new EGLGraphics(graphics, bounds);
                    if (eglGraphics.Initialized)
                        return eglGraphics;
                    eglGraphics.Dispose();
                }
                return new GLXGraphics(graphics, bounds);
            }
            return null;
        }
    }
}
