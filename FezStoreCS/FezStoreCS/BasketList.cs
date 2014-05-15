﻿using System;
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

        public FezItem this[int index]{
            get
            {
                return shopping_basket[index];
            }
            set { }
        }
        public double GetTotalAmount()
        {
            double total_amount = 0.0;
            foreach(FezItem item in shopping_basket){
                total_amount += item.getPrice();
            }
            return total_amount;
        }

    }
}
