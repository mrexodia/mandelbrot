using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    struct MandelState
    {
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
