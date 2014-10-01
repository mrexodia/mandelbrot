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
        int width; //bitmap width
        int height; //bitmap height
        MandelPoint middle; //mandel image middle
        double scale; //pixel -> mandel point scale
        int maxLoop; //number of times to try calculating the mandel number

        public MandelImage(int width, int height, MandelPoint middle, double scale, int maxLoop = 100)
        {
            // properties of the image
            this.width = width;
            this.height = height;
            this.middle = middle;
            this.scale = scale;
            this.maxLoop = maxLoop;
        }

        //convert (x,y) in bitmap to (x,y) in mandelbrot image
        public MandelPoint pixelToMandelPoint(int x, int y)
        {
            return new MandelPoint((x - width / 2) * scale + middle.a, (y - height / 2) * scale + middle.b);
        }

        //get the mandel number for a specified point in the mandelbrot image
        public int mandelPointToNumber(MandelPoint point)
        {
            MandelNumber mandelNumber = new MandelNumber(maxLoop);
            return mandelNumber.calculate(point);
        }

        public Bitmap create(MandelColor color)
        {
            //declare some required variables
            Bitmap mandelBitmap = new Bitmap(width, height);

            //go over every pixel in the bitmap
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int n = mandelPointToNumber(pixelToMandelPoint(x, y));
                    mandelBitmap.SetPixel(x, y, color.get(n, maxLoop));
                }
            }

            //return the created bitmap
            return mandelBitmap;
        }
    }
}
