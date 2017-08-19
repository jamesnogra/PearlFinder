using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PearlFinder
{
    public partial class Form1 : Form
    {
        byte thresholdNum = 16;
        Bitmap source, pattern;

        public Form1()
        {
            InitializeComponent();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int sad, sadThreshold = 10000;
            int totalPattern;
            List<Point> allMatches = new List<Point>();
            Bitmap testOutput = new Bitmap(pattern.Width, pattern.Height);
            float pctComplete = 0;

            //for the source image
            BitmapData sourceData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int sourceStride = sourceData.Stride;
            System.IntPtr sourceScan = sourceData.Scan0;
            //for the pattern image
            BitmapData patternData = pattern.LockBits(new Rectangle(0, 0, pattern.Width, pattern.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int patternStride = patternData.Stride;
            System.IntPtr patternScan = patternData.Scan0;

            progressBar.Visible = true;

            unsafe
            {
                byte* s = (byte*)(void*)sourceScan;
                int sourceOffset = sourceStride - source.Width * 3;
                byte* p;
                int patternOffset = patternStride - pattern.Width * 3;

                for (int y = 0; y < source.Height - pattern.Height; ++y)
                {
                    for (int x = 0; x < source.Width; ++x)
                    {
                        //s[0], s[1], and s[2] for the source image
                        //p[0], p[1], and p[2] for the pattern image
                        sad = 0;
                        totalPattern = 0;
                        p = (byte*)(void*)patternScan;

                        //for the moving scan image
                        BitmapData scanData = testOutput.LockBits(new Rectangle(0, 0, testOutput.Width, testOutput.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                        int scanStride = scanData.Stride;
                        System.IntPtr scanScan = scanData.Scan0;
                        byte* sc = (byte*)(void*)scanScan;
                        int scanOffset = scanStride - testOutput.Width * 3;

                        for (int i=0; i < pattern.Height; ++i)
                        {
                            for (int j=0; j < pattern.Width; ++j)
                            {
                                sad += Math.Abs(p[0] - s[0]);
                                sc[0] = sc[1] = sc[2] = s[0]; //this is for the moving scanning image
                                p += 3;
                                s += 3;
                                sc += 3;
                                totalPattern += 3;
                            }
                            sc += scanOffset;
                            p += patternOffset;
                            s += source.Width * 3 + sourceOffset - pattern.Width * 3;
                            totalPattern += source.Width * 3 + sourceOffset - pattern.Width * 3;
                        }

                        //display the moving scanning image
                        testOutput.UnlockBits(scanData);
                        testOutputPicBox.Image = testOutput;
                        pctComplete = (y)*100 / (source.Height - pattern.Height);
                        progressBar.Value = (int)pctComplete + 1;
                        Application.DoEvents();

                        if (sad < sadThreshold)
                        {
                            allMatches.Add(new Point(x, y));
                            drawRectangleAt(x, y);
                        }
                        s += 3 - totalPattern;
                    }
                    s += sourceOffset;
                }
            }

            source.UnlockBits(sourceData);
            pattern.UnlockBits(patternData);
            MessageBox.Show("Done scanning image! Found "+allMatches.Count+" matches.");
            progressBar.Visible = false;
        }

        private void drawRectangleAt(int x, int y)
        {
            int sizeFactorX = allPearlsPicbox.Width / source.Width;
            int sizeFactorY = allPearlsPicbox.Height / source.Height;
            Graphics g = allPearlsPicbox.CreateGraphics();
            Pen blackPen = new Pen(ColorTranslator.FromHtml("#33CC33"), 3);
            g.DrawRectangle(blackPen, x * sizeFactorX, y * sizeFactorY, pattern.Width * sizeFactorX, pattern.Height * sizeFactorY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            allPearlsPicbox.Image = Image.FromFile(@"AllPearls.png");
            allPearlsPicbox.SizeMode = PictureBoxSizeMode.StretchImage;
            patternPicbox.Image = Image.FromFile(@"PearlPattern.png");
            patternPicbox.SizeMode = PictureBoxSizeMode.StretchImage;
            source = new Bitmap(allPearlsPicbox.Image);
            pattern = new Bitmap(patternPicbox.Image);
            Threshold(source, thresholdNum);
            testOutputPicBox.Image = pattern;
            patternPicbox.Image = Image.FromFile(@"PearlPattern.png");
            Threshold(pattern, thresholdNum);
            progressBar.Visible = false;
        }

        public bool Threshold(Bitmap b, byte threshold)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int nOffset = stride - b.Width * 3;
                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];
                        if ((.333 * red + .333 * green + .334 * blue) > (255 - threshold))
                        {
                            p[0] = p[1] = p[2] = 255;
                        }
                        else
                        {
                            p[0] = p[1] = p[2] = 0;
                        }
                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }
    }
}
