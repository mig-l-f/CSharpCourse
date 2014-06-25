using System;

namespace GraphFunction.Model
{
    public class Function1 : Function
    {
        public override float calculate(float x)
        {
            return (float)(12 * Math.Sin(3 * x) / (1 + Math.Abs(x)));
        }
    }
}
