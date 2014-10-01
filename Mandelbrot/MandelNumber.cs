using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mandelbrot
{
    class MandelNumber
    {
        public const int INVALID = -1;
        int maxLoop;

        public MandelNumber(int maxLoop)
        {
            this.maxLoop = maxLoop;
        }

        //transform a mandel point: f(a,b) = (a*a - b*b + x, 2*a*b + y)
        private static MandelPoint transform(MandelPoint basePoint, double x, double y)
        {
            return new MandelPoint(basePoint.a * basePoint.a - basePoint.b * basePoint.b + x, 2 * basePoint.a * basePoint.b + y);
        }

        //calculate the mandel number for a point 'pt'
        public int calculate(MandelPoint point)
        {
            MandelPoint basePoint = new MandelPoint(0, 0);
            for (int i = 0; i < maxLoop; i++)
            {
                basePoint = transform(basePoint, point.a, point.b);
                if (!basePoint.IsInBounds())
                    return i + 1;
            }
            return INVALID;
        }
    }
}
