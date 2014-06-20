using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FezStoreCS
{
    public class FezSize
    {
        [XmlAttribute("Label")]
        public String label { get; set; }
        [XmlAttribute("PriceModifier")]
        public Double priceModifier { get; set; }

        public FezSize() { }

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
