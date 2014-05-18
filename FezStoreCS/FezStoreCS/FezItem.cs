using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FezStoreCS
{
    public class FezItem
    {

        private FezSize fez_size_;
        private FezStyle fez_style_;

        public FezItem(FezSize fez_size, FezStyle fez_style)
        {
            fez_size_ = fez_size;
            fez_style_ = fez_style;
        }

        public double getPrice()
        {
            return Convert.ToDouble(fez_style_.basePrice) * Convert.ToDouble(fez_size_.priceModifier);
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
