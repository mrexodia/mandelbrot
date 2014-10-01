using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    class MandelState
    {
        // the state of the mandelimage with 3 variables
        public MandelState(MandelPoint middle, double scale, int maxLoop)
        {
            this.middle = middle;
            this.scale = scale;
            this.maxLoop = maxLoop;
        }

        public MandelPoint middle;
        public double scale;
        public int maxLoop;
    }
}
