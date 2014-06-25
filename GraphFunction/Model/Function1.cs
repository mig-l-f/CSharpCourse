using System;

namespace GraphFunction.Model
{
    public class Function1 : Function
    {
        public override float calculate(float x)
        {
            return (float)(12 * Math.Sin(3 * x) / (1 + Math.Abs(x)));
        }
        public override string ToString()
        {
            return @"12 * Sin(3 * x) / (1 + |x|)";
        }
    }
}
