using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageProcessing
{
    // 3x3 convolution matrix container
    public class ConvMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;

        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight =
            MidLeft = Pixel = MidRight =
            BottomLeft = BottomMid = BottomRight = nVal;
        }
    }

    public static class BitmapFilter
    {
        /// <summary>
        /// Applies a 3x3 convolution to the source image and returns a new Bitmap result (does not mutate the source).
        /// Uses PixelFormat.Format24bppRgb internally for consistent byte layout (B,G,R).
        /// </summary>
        public static Bitmap Conv3x3(Bitmap source, ConvMatrix m)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (m.Factor == 0) m.Factor = 1; // avoid div0

            int width = source.Width;
            int height = source.Height;

            // create 24bpp copies (ensures consistent stride and BGR ordering)
            Bitmap src = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(src))
                g.DrawImage(source, 0, 0, width, height);

            Bitmap dest = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData bdSrc = src.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bdDst = dest.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int stride = bdSrc.Stride;
            int bytes = stride * height;
            byte[] srcBuffer = new byte[bytes];
            byte[] dstBuffer = new byte[bytes];

            Marshal.Copy(bdSrc.Scan0, srcBuffer, 0, bytes);
            // initialize dst with source so borders that we skip remain intact
            Array.Copy(srcBuffer, dstBuffer, bytes);

            // iterate inner pixels (skip 0 and width-1 borders)
            for (int y = 1; y < height - 1; y++)
            {
                int row = y * stride;
                int rowUp = (y - 1) * stride;
                int rowDown = (y + 1) * stride;

                for (int x = 1; x < width - 1; x++)
                {
                    int baseIndex = row + x * 3;

                    for (int channel = 0; channel < 3; channel++) // 0=B,1=G,2=R
                    {
                        int topLeft = srcBuffer[rowUp + (x - 1) * 3 + channel];
                        int topMid = srcBuffer[rowUp + x * 3 + channel];
                        int topRight = srcBuffer[rowUp + (x + 1) * 3 + channel];

                        int midLeft = srcBuffer[row + (x - 1) * 3 + channel];
                        int mid = srcBuffer[row + x * 3 + channel];
                        int midRight = srcBuffer[row + (x + 1) * 3 + channel];

                        int bottomLeft = srcBuffer[rowDown + (x - 1) * 3 + channel];
                        int bottomMid = srcBuffer[rowDown + x * 3 + channel];
                        int bottomRight = srcBuffer[rowDown + (x + 1) * 3 + channel];

                        int sum = (topLeft * m.TopLeft) + (topMid * m.TopMid) + (topRight * m.TopRight)
                                + (midLeft * m.MidLeft) + (mid * m.Pixel) + (midRight * m.MidRight)
                                + (bottomLeft * m.BottomLeft) + (bottomMid * m.BottomMid) + (bottomRight * m.BottomRight);

                        int val = sum / m.Factor + m.Offset;
                        if (val < 0) val = 0;
                        else if (val > 255) val = 255;

                        dstBuffer[baseIndex + channel] = (byte)val;
                    }
                }
            }

            // copy back
            Marshal.Copy(dstBuffer, 0, bdDst.Scan0, bytes);
            src.UnlockBits(bdSrc);
            dest.UnlockBits(bdDst);
            src.Dispose();

            return dest;
        }

        // ---- Common filter wrappers ----
        public static Bitmap Smooth(Bitmap srcImage, int nWeight = 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;
            m.Offset = 0;
            return Conv3x3(srcImage, m);
        }

        public static Bitmap GaussianBlur(Bitmap srcImage) // classic 3x3 gaussian (1 2 1 / 2 4 2 / 1 2 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = 1; m.TopMid = 2; m.TopRight = 1;
            m.MidLeft = 2; m.Pixel = 4; m.MidRight = 2;
            m.BottomLeft = 1; m.BottomMid = 2; m.BottomRight = 1;
            m.Factor = 16;
            m.Offset = 0;
            return Conv3x3(srcImage, m);
        }

        public static Bitmap Sharpen(Bitmap srcImage) // example center 11, others -2 -> factor 3
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = 0; m.TopMid = -2; m.TopRight = 0;
            m.MidLeft = -2; m.Pixel = 11; m.MidRight = -2;
            m.BottomLeft = 0; m.BottomMid = -2; m.BottomRight = 0;
            m.Factor = 3;
            m.Offset = 0;
            return Conv3x3(srcImage, m);
        }

        public static Bitmap MeanRemoval(Bitmap srcImage) // sharpen alternative
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = -1; m.TopMid = -1; m.TopRight = -1;
            m.MidLeft = -1; m.Pixel = 9; m.MidRight = -1;
            m.BottomLeft = -1; m.BottomMid = -1; m.BottomRight = -1;
            m.Factor = 1;
            m.Offset = 0;
            return Conv3x3(srcImage, m);
        }

        public static Bitmap Emboss(Bitmap srcImage) // laplacian emboss with +127 offset
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = -1; m.TopMid = 0; m.TopRight = -1;
            m.MidLeft = 0; m.Pixel = 4; m.MidRight = 0;
            m.BottomLeft = -1; m.BottomMid = 0; m.BottomRight = -1;
            m.Factor = 1;
            m.Offset = 127;
            return Conv3x3(srcImage, m);
        }

        public static Bitmap EmbossHorzVert(Bitmap srcImage) // Horizontal + Vertical emboss
        {
            ConvMatrix m = new ConvMatrix();
            m.TopLeft = 0; m.TopMid = -1; m.TopRight = 0;
            m.MidLeft = -1; m.Pixel = 4; m.MidRight = -1;
            m.BottomLeft = 0; m.BottomMid = -1; m.BottomRight = 0;
            m.Factor = 1; m.Offset = 127;
            return Conv3x3(srcImage, m); 
        }
        
        public static Bitmap EmbossAll(Bitmap srcImage) // All directions emboss
        { 
            ConvMatrix m = new ConvMatrix(); 
            m.TopLeft = -1; m.TopMid = -1; m.TopRight = -1; 
            m.MidLeft = -1; m.Pixel = 8; m.MidRight = -1; 
            m.BottomLeft = -1; m.BottomMid = -1; m.BottomRight = -1; 
            m.Factor = 1; m.Offset = 127; 
            return Conv3x3(srcImage, m); 
        }

        public static Bitmap EmbossLossy(Bitmap srcImage) // Lossy emboss
        { 
            ConvMatrix m = new ConvMatrix(); 
            m.TopLeft = 1; m.TopMid = -2; m.TopRight = 1; 
            m.MidLeft = -2; m.Pixel = 4; m.MidRight = -2; 
            m.BottomLeft = -2; m.BottomMid = 1; m.BottomRight = -2; 
            m.Factor = 1; m.Offset = 127; 
            return Conv3x3(srcImage, m); 
        }

        public static Bitmap EmbossHorizontal(Bitmap srcImage) // Horizontal only emboss
        { 
            ConvMatrix m = new ConvMatrix(); 
            m.TopLeft = 0; m.TopMid = 0; m.TopRight = 0; 
            m.MidLeft = -1; m.Pixel = 2; m.MidRight = -1; 
            m.BottomLeft = 0; m.BottomMid = 0; m.BottomRight = 0; 
            m.Factor = 1; m.Offset = 127; 
            return Conv3x3(srcImage, m); 
        }

        public static Bitmap EmbossVertical(Bitmap srcImage) // Vertical only emboss
        { 
            ConvMatrix m = new ConvMatrix(); 
            m.TopLeft = 0; m.TopMid = -1; m.TopRight = 0; 
            m.MidLeft = 0; m.Pixel = 0; m.MidRight = 0; 
            m.BottomLeft = 0; m.BottomMid = 1; m.BottomRight = 0; 
            m.Factor = 1; m.Offset = 127; 
            return Conv3x3(srcImage, m); 
        }
        // You can add more wrappers / custom filter creator here...

        // Simple blur (box blur)
        public static Bitmap Blur(Bitmap srcImage) 
        { 
            ConvMatrix m = new ConvMatrix(); 
            m.TopLeft = 1; m.TopMid = 1; m.TopRight = 1; 
            m.MidLeft = 1; m.Pixel = 1; m.MidRight = 1; 
            m.BottomLeft = 1; m.BottomMid = 1; m.BottomRight = 1; 
            m.Factor = 9; m.Offset = 0; 
            return Conv3x3(srcImage, m); 
        }

        // Edge Enhance (sharpen edges slightly)
        public static Bitmap EdgeEnhance(Bitmap srcImage) 
        { 
            ConvMatrix m = new ConvMatrix(); 
            m.TopLeft = 0; m.TopMid = -1; m.TopRight = 0; 
            m.MidLeft = -1; m.Pixel = 5; m.MidRight = -1; 
            m.BottomLeft = 0; m.BottomMid = -1; m.BottomRight = 0; 
            m.Factor = 1; m.Offset = 0; 
            return Conv3x3(srcImage, m); 
        }
    }
}
