using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FezStoreCS
{
    public class BasketList
    {
        List<FezItem> shopping_basket;

        public BasketList()
        {
            shopping_basket = new List<FezItem>();
        }

        public void Add(FezSize size, FezStyle style)
        {
            shopping_basket.Add(new FezItem(size, style));
        }

        public int Count()
        {
            return shopping_basket.Count;
        }
    }
}
