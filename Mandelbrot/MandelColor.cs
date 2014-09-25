using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    //Class that describes color in a Mandelbrot image
    public abstract class MandelColor
    {
        public abstract string ToString();

        public abstract Color get(int n, int max);
    }

    public class BlueAlpha : MandelColor
    {
        public override string ToString()
        {
            return "Transparent Blue";
        }

        public override Color get(int n, int max)
        {
            if (n == MandelNumber.INVALID)
                return Color.Red;
            Random ran = new Random(n);
            int rgb = ran.Next(0, 255);
            return Color.FromArgb(rgb, rgb, rgb);
        }
    }

    public class RandomColor : MandelColor
    {
        public override string ToString()
        {
            return "Pseudo-Random";
        }

        public override Color get(int n, int max)
        {
            if (n == MandelNumber.INVALID)
                return Color.Black;
            Random ran = new Random(n);
            return Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
        }
    }
}
