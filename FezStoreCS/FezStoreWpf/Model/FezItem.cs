using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FezStore.Model
{
    public class FezItem
    {
        [XmlElement("FezSize")]
        public FezSize fez_size_ { get; set; }
        [XmlElement("FezStyle")]
        public FezStyle fez_style_ { get; set; }
        [XmlElement("Price")]
        public double price { get; set; }

        public FezItem() { }

        public FezItem(FezSize fez_size, FezStyle fez_style)
        {
            fez_size_ = fez_size;
            fez_style_ = fez_style;
            price = Convert.ToDouble(fez_style_.basePrice) * Convert.ToDouble(fez_size_.priceModifier);
        }

        public double getPrice()
        {
            return price;
        }

        public override string ToString()
        {
            StringBuilder fezItemText = new StringBuilder();
            fezItemText.Append(fez_style_.shortDescription);
            fezItemText.Append(" (in ");
            fezItemText.Append(fez_size_.label);
            fezItemText.Append(")\n");
            return fezItemText.ToString();
        }

        public string shortDescription()
        {
            return fez_style_.ToString();
        }
        public string label()
        {
            return fez_size_.ToString();
        }
    }
}
