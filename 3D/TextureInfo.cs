using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace DevExpress.XtraCharts.GLGraphics {
    public class TextureInfo {
        readonly byte[] pixels;
        readonly IntPtr texture;
        readonly int x, y, width, height, texWidth, texHeight;
        public TextureInfo(IntPtr texture, byte[] pixels, int x, int y, int width, int height, int texWidth, int texHeight) {
            this.texture = texture;
            this.pixels = pixels;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.texWidth = texWidth;
            this.texHeight = texHeight;
        }
        static int CalcTexSize(int texSize, int maxTexSize) {
            if (texSize <= maxTexSize || maxTexSize <= 0)
                return texSize;
            while (texSize > maxTexSize)
                texSize /= 2;
            return texSize;
        }
        [System.Security.SecuritySafeCritical]
        static TextureInfo[] CalcTextureInfos(BitmapData data, int frameWidth, int frameHeight) {
            ArrayList list = new ArrayList();
            for (int y = 0; y < data.Height; y += frameHeight) {
                for (int x = 0; x < data.Width; x += frameWidth) {
                    byte[] pixels = new byte[frameWidth * frameHeight * 4];
                    for (int frameLine = 0; frameLine < frameHeight; frameLine++) {
                        int offset = y * data.Width * 4 + x * 4 + frameLine * data.Width * 4;
                        long ptr = IntPtr.Size == 4 ? data.Scan0.ToInt32() : data.Scan0.ToInt64();
                        System.Runtime.InteropServices.Marshal.Copy(
                            (IntPtr)(ptr + offset),
                            pixels,
                            frameLine * frameWidth * 4,
                            frameWidth * 4);
                    }
                    list.Add(new TextureInfo(IntPtr.Zero, pixels, x, y, frameWidth, frameHeight, data.Width, data.Height));
                }
            }
            return (TextureInfo[])list.ToArray(typeof(TextureInfo));
        }
        static TextureInfo[] CalcTextureInfos(byte[] texPixels, int frameWidth, int frameHeight, int texWidth, int texHeight) {
            ArrayList list = new ArrayList();
            for (int y = 0; y < texHeight; y += frameHeight) {
                for (int x = 0; x < texWidth; x += frameWidth) {
                    byte[] pixels = new byte[frameWidth * frameHeight * 4];
                    for (int frameLine = 0; frameLine < frameHeight; frameLine++) {
                        int offset = y * texWidth * 4 + x * 4 + frameLine * texWidth * 4;
                        Array.Copy(texPixels, offset, pixels, frameLine * frameWidth * 4, frameWidth * 4);
                    }
                    list.Add(new TextureInfo(IntPtr.Zero, pixels, x, y, frameWidth, frameHeight, texWidth, texHeight));
                }
            }
            return (TextureInfo[])list.ToArray(typeof(TextureInfo));
        }
        public static TextureInfo[] CalcTextureInfos(BitmapData data, int maxTexSize) {
            int frameWidth = CalcTexSize(data.Width, maxTexSize);
            int frameHeight = CalcTexSize(data.Height, maxTexSize);
            if (frameWidth == data.Width && frameHeight == data.Height)
                return new TextureInfo[] { new TextureInfo(data.Scan0, null, 0, 0, frameWidth, frameHeight, data.Width, data.Height) };
            return CalcTextureInfos(data, frameWidth, frameHeight);
        }
        public static TextureInfo[] CalcTextureInfos(System.Drawing.Image image, int maxTexSize, Size bounds) {
            int width = image.Width > bounds.Width ? bounds.Width : image.Width;
            int height = image.Height > bounds.Height ? bounds.Height : image.Height;
            int texWidth = width;
            int texHeight = height;
            byte[] pixels = new byte[texWidth * texHeight * 4];
            using (Bitmap bitmap = new Bitmap(image)) {
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                GLU.ScaleImage(GL.BGRA_EXT, bitmap.Width, bitmap.Height, GL.UNSIGNED_BYTE, data.Scan0, texWidth, texHeight, GL.UNSIGNED_BYTE, pixels);
                bitmap.UnlockBits(data);
            }
            int frameWidth = CalcTexSize(texWidth, maxTexSize);
            int frameHeight = CalcTexSize(texHeight, maxTexSize);
            return CalcTextureInfos(pixels, frameWidth, frameHeight, texWidth, texHeight);
        }
        public int Height { get { return height; } }
        public int TexHeight { get { return texHeight; } }
        public byte[] TextureArray { get { return pixels; } }
        public IntPtr TexturePointer { get { return texture; } }
        public int TexWidth { get { return texWidth; } }
        public int Width { get { return width; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
    }
}
