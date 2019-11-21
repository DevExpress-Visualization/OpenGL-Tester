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

        public static void ConsoleWriteLine(string text, ConsoleColor? color = null) {
            if(color.HasValue)
                Console.ForegroundColor = color.Value;
            Console.WriteLine(text);
            if(color.HasValue)
                Console.ResetColor();
        }
        public static void ConsoleWrite(string text, ConsoleColor? color = null) {
            if(color.HasValue)
                Console.ForegroundColor = color.Value;
            Console.Write(text);
            if(color.HasValue)
                Console.ResetColor();
        }
        public static void ConsoleOk() {
            ConsoleWriteLine("OK", ConsoleColor.Green);
        }
        public static void ConsoleError(string error) {
            ConsoleWriteLine(error, ConsoleColor.Red);
        }
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
                try {
                    PlatformUtils.ConsoleWriteLine("\r\nCreate GLXGraphics...");
                    return new GLXGraphics(graphics, bounds);
                }
                catch (Exception exception) {
                    PlatformUtils.ConsoleWriteLine(exception.Message, ConsoleColor.Red);
                    PlatformUtils.ConsoleWriteLine("\r\nCreate OSMesaGraphics...");
                    try {
                        return new OSMesaGraphics(graphics, bounds);
                    }
                    catch (Exception exception2) {
                        PlatformUtils.ConsoleWriteLine(exception2.Message, ConsoleColor.Red);
                    }
                }
            }
            return null;
        }
    }
}
