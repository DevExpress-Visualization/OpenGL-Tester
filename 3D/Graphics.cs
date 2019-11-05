using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using DevExpress.XtraCharts.GLGraphics;

namespace DevExpress.XtraCharts.Native {
    public enum GraphicsQuality { Lowest, Highest }


    [SuppressMessage("SpellChecker", "CRRSP01")]
    public class OpenGLGraphics : IDisposable {
		static OpenGLGraphics() {
			try {
				GL.Finish(); // This is a trick to raise hardware OpenGL driver
			}
			catch {
			}
		}
		public static void CalculateColorComponents(Color color, float[] result) {
			result[0] = color.R / 255.0f;
			result[1] = color.G / 255.0f;
			result[2] = color.B / 255.0f;
			if (result.Length > 3)
				result[3] = color.A / 255.0f;
		}
		public static void CalculateColorComponents(Color color, out float red, out float green, out float blue) {
			red = color.R / 255.0f;
			green = color.G / 255.0f;
			blue = color.B / 255.0f;
		}
		public static void CalculateColorComponents(Color color, out float red, out float green, out float blue, out float alpha) {
			CalculateColorComponents(color, out red, out green, out blue);
			alpha = color.A / 255.0f;
		}

        readonly Graphics graphics;
        int stencilBufferMaxValue;
        bool nativeDrawing;
        Bitmap bitmap;
		Graphics nativeGraphics;
        Rectangle bounds;
        IPlatformGraphics platformGraphics;
		
		public GraphicsQuality GraphicsQuality { get; set; }
		public bool Initialized { get { return platformGraphics != null && platformGraphics.Initialized; } }
		public Graphics NativeGraphics { get { return nativeGraphics; } }
        public Rectangle Bounds {
            get { return bounds; }
            set {
                if(bounds == value)
                    return;
                bounds = value;
                CreateNativeObjects(bounds.Size);
            }
        }
		public Size Size { 
			get { return bounds.Size; } 
            set {
                if(bounds.Size == value)
                    return;
                Bounds = new Rectangle(bounds.Location, value);
            } 
		}
		public bool NativeDrawing { get { return nativeDrawing; } }
        public int StencilBufferMaxValue { get { return stencilBufferMaxValue; } }

        public OpenGLGraphics(Graphics graphics, IntPtr hdc, Rectangle bounds) {
            GraphicsQuality = GraphicsQuality.Highest;
            lock (typeof(OpenGLGraphics)) {
			    CreateNativeObjects(bounds.Size);
			    this.graphics = graphics;
                this.bounds = bounds;
                platformGraphics = PlatformUtils.CreatePlatformGraphics(graphics, bounds, hdc);
            }
		}
		void FinishDrawing() {
			GL.Finish();

            platformGraphics.FinishDrawing();
            platformGraphics.ReleaseCurrent();
		}
		void Prepare() {
            platformGraphics.MakeCurrent();
			GL.MatrixMode(GL.PROJECTION);
			GL.PushMatrix();
			GL.LoadIdentity();
			GL.MatrixMode(GL.MODELVIEW);
			GL.PushMatrix();
			GL.LoadIdentity();            
		}
		void Restore() {
			GL.MatrixMode(GL.MODELVIEW);
			GL.PopMatrix();
			GL.MatrixMode(GL.PROJECTION);
			GL.PopMatrix();
            platformGraphics.ReleaseCurrent();
		}
		void DisposeNativeGraphics() {
			if (nativeGraphics != null) {
				nativeGraphics.Dispose();
				nativeGraphics = null;
			}
		}
		void DisposeBitmap() {
			if (bitmap != null) {
				bitmap.Dispose();
				bitmap = null;
			}
		}
		void CreateNativeObjects(Size size) {
			DisposeBitmap();
			DisposeNativeGraphics();
            if (size.Width == 0)
                size.Width = 1;
            if (size.Height == 0)
                size.Height = 1;
            bitmap = new Bitmap(size.Width, size.Height);
			nativeGraphics = Graphics.FromImage(bitmap);
		}
		void DrawBitmap() {
			if (bitmap == null)
				return;
			int[] maxTexSize = new int[1];
			GL.GetIntegerv(GL.MAX_TEXTURE_SIZE, maxTexSize);
			uint[] names = new uint[1];
			GL.GenTextures(1, names);
			GL.BindTexture(GL.TEXTURE_2D, names[0]);
			GL.PixelStorei(GL.UNPACK_ALIGNMENT, 1);
			GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, GL.REPEAT);
			GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, GL.REPEAT);
			GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER, GL.NEAREST);
			GL.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER, GL.NEAREST);
			GL.TexEnvf(GL.TEXTURE_ENV, GL.TEXTURE_ENV_MODE, GL.REPLACE);
			GL.Enable(GL.TEXTURE_2D);
			GL.MatrixMode(GL.MODELVIEW);
			GL.LoadIdentity();
			GL.MatrixMode(GL.PROJECTION);
			GL.LoadIdentity();
            GL.Ortho(0.0, bounds.Width, bounds.Height, 0.0, -1.0, 1.0);
			GL.Disable(GL.DEPTH_TEST);
			GL.Enable(GL.BLEND);
			GL.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);
			GL.Color4f(0.0f, 0.0f, 0.0f, 0.0f);

			BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			TextureInfo[] infos = TextureInfo.CalcTextureInfos(srcData, maxTexSize[0]);
			foreach (TextureInfo info in infos) {
				if (info.TexturePointer == IntPtr.Zero)
					GL.TexImage2D(GL.TEXTURE_2D, 0, GL.RGBA, info.Width, info.Height, 0, GL.BGRA_EXT, GL.UNSIGNED_BYTE, info.TextureArray);
				else
					GL.TexImage2D(GL.TEXTURE_2D, 0, GL.RGBA, info.Width, info.Height, 0, GL.BGRA_EXT, GL.UNSIGNED_BYTE, info.TexturePointer);
				GL.Begin(GL.QUADS);
				GL.TexCoord2d(0, 0);
				GL.Vertex3d(info.X, info.Y, 0.0);
				GL.TexCoord2d(0, 1);
				GL.Vertex3d(info.X, info.Y + info.Height, 0.0);
				GL.TexCoord2d(1, 1);
				GL.Vertex3d(info.X + info.Width, info.Y + info.Height, 0.0);
				GL.TexCoord2d(1, 0);
				GL.Vertex3d(info.X + info.Width, info.Y, 0.0);
				GL.End();
			}
			bitmap.UnlockBits(srcData);
			
			GL.Disable(GL.TEXTURE_2D);
			GL.DeleteTextures(1, names);
		}
		void DrawTrinagle() {
            GL.Begin(GL.TRIANGLES);
			GL.Color4f(1, 0, 0, 1);
			GL.Vertex3d(0, 0, 0);
			GL.Color4f(0, 1, 0, 1);
			GL.Vertex3d(bounds.Width, 0, 0);
			GL.Color4f(0, 0, 1, 1);
			GL.Vertex3d(bounds.Width / 2, bounds.Height, 0);
            GL.End();
		}
		public void SetDrawingType(bool nativeDrawing) {
			if (nativeDrawing != this.nativeDrawing)
				this.nativeDrawing = nativeDrawing;
			if (nativeDrawing)
				nativeGraphics.Clear(Color.Transparent);
		}
		public void Execute() {
			if (Initialized)
				lock (this) {
                    if (!platformGraphics.MakeCurrent())
                        return;
                    try {
                        platformGraphics.Lock();
                        GL.Viewport(Bounds.X, bounds.Y, Bounds.Width, Bounds.Height);
						Color backColor = Color.Black;
                        float red, green, blue, alpha;
                        CalculateColorComponents(backColor, out red, out green, out blue, out alpha);
                        GL.ClearColor(red, green, blue, alpha);
                        GL.Clear(GL.DEPTH_BUFFER_BIT | GL.STENCIL_BUFFER_BIT | GL.COLOR_BUFFER_BIT);
                        GL.Enable(GL.BLEND);
                        GL.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);
                        GL.ShadeModel(GL.SMOOTH);
                        GL.MatrixMode(GL.MODELVIEW);
                        GL.LoadIdentity();
                        GL.MatrixMode(GL.PROJECTION);
                        GL.LoadIdentity();
                        GL.Ortho(0.0, Bounds.Width, Bounds.Height, 0.0, -1.0, 1.0);
                        int[] bufferSize = new int[1];
                        GL.GetIntegerv(GL.STENCIL_BITS, bufferSize);
                        stencilBufferMaxValue = (int)Math.Pow(2, bufferSize[0]) - 1;
                        nativeDrawing = false;
						DrawTrinagle();
                        DrawBitmap();
                    }
                    catch (ThreadAbortException) {
                        platformGraphics.ReleaseCurrent();
                        throw;
                    }
					finally {
                        platformGraphics.Unlock();
                        FinishDrawing();
                        nativeDrawing = false;
                    }
                }
		}
        public void Dispose() {
            if (platformGraphics != null) {
                platformGraphics.Dispose();
                platformGraphics = null;
            }
			DisposeBitmap();
			DisposeNativeGraphics();
		}
	}
}
