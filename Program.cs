using System;
using System.Drawing;
using System.Drawing.Imaging;
using DevExpress.XtraCharts.Native;

namespace OpenGLTester {
    class Program {
        static void Main(string[] args) {
            Size size = new Size(128, 128);
            using(Bitmap bmp = new Bitmap(size.Width, size.Height)) {
                using(Graphics gr = Graphics.FromImage(bmp)) {
                    using(OpenGLGraphics glGraphics = new OpenGLGraphics(gr, IntPtr.Zero, new Rectangle(Point.Empty, size))) {
                        if(glGraphics.Initialized) {
                            glGraphics.Execute();
                        }
                        else {
                            
                        }
                    }
                    bmp.Save("Test.png", ImageFormat.Png);
                }
            }
        }
    }
}
