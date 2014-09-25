using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    //point dedicated to mandel numbers
    public class MandelPoint
    {
        public double a;
        public double b;

        public MandelPoint(double a = 0, double b = 0)
        {
            this.a = a;
            this.b = b;
        }

        //check if the distance to (0,0) <= 2
        public bool IsInBounds()
        {
            return a * a + b * b <= 4;
        }
    }
}
