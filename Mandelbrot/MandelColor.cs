using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    public abstract class MandelColor
    {
        public abstract Color get(int n, int max);
    }

    public class BlueAlpha : MandelColor
    {
        public override Color get(int n, int max)
        {
            if (n == -1) //tends to infinite
                return Color.Black;
            //scale n to 255
            double mul = 255 / (max - 1);
            n = (int)(mul * n);

            //calculate ARGB value
            int a = 255 - n;
            int r = 0;
            int g = 0;
            int b = 128;
            return Color.FromArgb(a, r, g, b);
        }
    }
}
