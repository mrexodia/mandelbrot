using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    public class MandelImage
    {
        int w;
        int h;
        Point m;
        double scale;
        int recurseCount;
        double maxDistance;

        public MandelImage(int w, int h, Point m, double scale, int recurseCount = 600, double maxDistance = 2)
        {
            this.w = w;
            this.h = h;
            this.m = m;
            this.scale = scale;
            this.recurseCount = recurseCount;
            this.maxDistance = maxDistance;
        }

        public int getPixelMandel(double x, double y)
        {
            MandelNumber mNumber = new MandelNumber(recurseCount);
            x -= m.X;
            y -= m.Y;
            return mNumber.calculate(new MandelPoint(maxDistance), x * scale, y * scale);
        }

        public Bitmap create(MandelColor color)
        {
            //declare some required variables
            Bitmap mandelBitmap = new Bitmap(w, h);

            //go over every pixel in the bitmap
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int n = getPixelMandel(i, j);
                    mandelBitmap.SetPixel(i, j, color.get(n, recurseCount));
                }
            }

            //return the created bitmap
            return mandelBitmap;
        }
    }
}
