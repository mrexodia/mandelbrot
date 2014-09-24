using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    //point dedicated to mandel numbers
    class MandelPoint
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

    class MandelNumber
    {
        int recurseCount;

        public MandelNumber(int recurseCount)
        {
            this.recurseCount = recurseCount;
        }

        //transform a mandel point: f(a,b) = (a*a-b*b+x, 2*a*b+y)
        private static MandelPoint transform(MandelPoint pt, double x, double y)
        {
            return new MandelPoint(pt.a * pt.a - pt.b * pt.b + x, 2 * pt.a * pt.b + y);
        }

        //recursively calculate the mandel number
        public int calculate(MandelPoint pt, double x, double y, int n = 1)
        {
            if (n == recurseCount) //max recurse count
                return -1;
            pt = transform(pt, x, y);
            if (!pt.IsInBounds())
                return n;
            return calculate(pt, x, y, n + 1);
        }
    }
}
