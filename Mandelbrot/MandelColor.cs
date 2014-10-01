using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    //Abstract class that describes color in a Mandelbrot image
    public abstract class MandelColor
    {
        public abstract Color get(int n);
    }

    public class RandomColor : MandelColor
    {
        public override string ToString()
        {
            return "Pseudo-Random";
        }

        public override Color get(int n)
        {
            if (n == MandelNumber.INVALID)
                return Color.Black;
            Random ran = new Random(n);
            return Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
        }
    }

    public class BlueAlpha : MandelColor
    {
        public override string ToString()
        {
            return "Transparent Blue";
        }

        public override Color get(int n)
        {
            if (n == MandelNumber.INVALID)
                return Color.White;
            return Color.FromArgb(255 - n % 256, 0, 0, 50);
        }
    }

    public class RedGreenBlue : MandelColor
    {
        public override string ToString()
        {
            return "RGB";
        }

        public override Color get(int n)
        {
            if (n == MandelNumber.INVALID)
                return Color.Black;
            Color result = Color.Black;
            int rgb = (n % 16 + 1) * 16 - 1;
            switch (n % 3)
            {
                case 0: //red
                    result = Color.FromArgb(rgb, 0, 0);
                    break;
                case 1: //green
                    result = Color.FromArgb(0, rgb, 0);
                    break;
                case 2: //blue
                    result = Color.FromArgb(0, 0, rgb);
                    break;
            }
            return result;
        }
    }

    public class Fire : MandelColor
    {
        public override string ToString()
        {
            return "Fire";
        }

        public override Color get(int n)
        {
            if (n == MandelNumber.INVALID)
                return Color.OrangeRed;
            return Color.FromArgb(n % 256, 0, 0);
        }
    }

    public class Green : MandelColor
    {
        public override string ToString()
        {
            return "Green";
        }

        public override Color get(int n)
        {
            if (n == MandelNumber.INVALID)
                return Color.Black;
            List<Color> greens = new List<Color> { Color.DarkGreen, Color.DarkOliveGreen, Color.DarkSeaGreen, Color.ForestGreen, Color.Green, Color.GreenYellow, Color.LawnGreen, Color.LightGreen, Color.LightSeaGreen, Color.LimeGreen, Color.MediumSeaGreen, Color.PaleGreen, Color.SeaGreen, Color.SpringGreen, Color.YellowGreen };
            return greens[n % greens.Count];
        }
    }

    public class BlackWhite : MandelColor
    {
        public override string ToString()
        {
            return "Black & White";
        }

        public override Color get(int n)
        {
            if (n == MandelNumber.INVALID)
                return Color.Black;
            Random ran = new Random(n);
            int rgb = ran.Next(0, 255);
            return Color.FromArgb(rgb, rgb, rgb);
        }
    }
}
