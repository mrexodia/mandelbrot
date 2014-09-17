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
        public double limit;

        public MandelPoint(double limit = 2.0, double a = 0, double b = 0)
        {
            this.a = a;
            this.b = b;
            this.limit = limit;
        }

        public bool IsInBounds()
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) <= limit;
        }
    }

    class MandelNumber
    {
        int recurseCount;

        public MandelNumber(int recurseCount)
        {
            this.recurseCount = recurseCount;
        }

        //transform a manel point
        private static MandelPoint transform(MandelPoint pt, double x, double y)
        {
            return new MandelPoint(pt.limit, pt.a * pt.a - pt.b * pt.b + x, 2 * pt.a * pt.b + y);
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
