using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace FezStoreCS
{
    public class BasketList
    {

        public event System.EventHandler AddedItem = delegate { };

        private ObservableCollection<FezItem> shopping_basket;

        public BasketList()
        {
            shopping_basket = new ObservableCollection<FezItem>();
        }

        public void Add(FezSize size, FezStyle style)
        {
            shopping_basket.Add(new FezItem(size, style));
            AddedItem(this, new EventArgs());
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
        public void ExportToCSV(String filename)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false);

            foreach (FezItem item in shopping_basket)
            {
                streamWriter.WriteLine(
                    String.Format("{0},{1},{2,2:C}",
                    item.shortDescription(),
                    item.label(),
                    item.getPrice()));
            }

            streamWriter.Close();
        }
    }
}
