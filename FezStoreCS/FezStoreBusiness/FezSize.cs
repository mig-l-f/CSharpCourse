using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FezStoreCS
{
    public class FezSize
    {
        public String label { get; set; }
        public Double priceModifier { get; set; }

        public FezSize(String label, Double priceModifier)
        {
            this.label = label;
            this.priceModifier = priceModifier;
        }
        public override String ToString()
        {
            return this.label;
        }
    }
}
