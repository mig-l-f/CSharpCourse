using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FezStoreCS
{
    public class FezStyle
    {
        public String longDescription { get; set; }
        public String shortDescription { get; set; }
        public Decimal basePrice { get; set; }
        public Boolean supportsTassels { get; set; }

        public FezStyle(String longDescription, String shortDescription, Decimal basePrice, Boolean supportsTassels)
        {
            this.longDescription = longDescription;
            this.shortDescription = shortDescription;
            this.basePrice = basePrice;
            this.supportsTassels = supportsTassels;
        }

        public override String ToString()
        {
            return this.shortDescription;
        }
    }
}
