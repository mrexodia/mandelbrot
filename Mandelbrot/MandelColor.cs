using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    class MandelColor
    {
        public static int min;
        public static int max;

        public static Color get(int n, int max)
        {
            if (n == -1) //tends to infinite
                return Color.Black;
            int a = 0;
            int r = 0;
            int g = 0;
            int b = 0;
            double mul = 255 / (max - 1);
            n = (int)(mul * n);
            return Color.FromArgb(255, r + n, g, b);
        }
    }
}
