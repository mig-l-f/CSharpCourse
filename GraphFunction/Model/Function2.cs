using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFunction.Model
{
    public class Function2 : Function
    {
        public override float calculate(float x)
        {
            x = Math.Abs(x);
            if (x < 0.001) return 20;
            return (float)Math.Abs(20 * Math.Cos(x) / (x + 1));
        }
    }
}
