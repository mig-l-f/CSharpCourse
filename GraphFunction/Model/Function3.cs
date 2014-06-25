using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFunction.Model
{
    public class Function3 : Function
    {
        public override float calculate(float x)
        {
            const float A = -0.0003f;
            const float B = -0.0024f;
            const float C = 0.02f;
            const float D = 0.09f;
            const float E = -0.5f;
            const float F = 0.3f;
            const float G = 3f;
            return (((((A * x + B) * x + C) * x + D) * x + E) * x + F) * x + G;
        }
        public override string ToString()
        {
            return @"Ax^6 + Bx^5 + Cx^4 + Dx^3 + Ex^2 + Fx + G";
        }
    }
}
