using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FezStore.Model
{
    public class FezStyle
    {
        [XmlAttribute("ShortDescription")]
        public String shortDescription { get; set; }
        [XmlAttribute("LongDescription")]
        public String longDescription { get; set; }
        [XmlAttribute("BasePrice")]
        public Decimal basePrice { get; set; }
        [XmlAttribute("SupportsTassels")]
        public Boolean supportsTassels { get; set; }

        public FezStyle() { }

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
