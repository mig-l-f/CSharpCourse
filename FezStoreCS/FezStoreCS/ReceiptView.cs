using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace FezStoreCS
{
    public partial class ReceiptView : Form
    {
        private BasketList shopping_basket;

        public ReceiptView(BasketList basket)
        {
            shopping_basket = basket;
            shopping_basket.shopping_basket.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(this.UpdateList);
            InitializeComponent();
            UpdateList();
        }

        private void UpdateList()
        {
            itemListTextBox.Clear();
            StringBuilder receiptText = new StringBuilder();
            for (int x = 0; x < shopping_basket.Count(); x++)
            {
                receiptText.Append(shopping_basket[x]);
            }
            itemListTextBox.Text = receiptText.ToString();

            totalAmountTextBox.Text = String.Format("{0,2:C}", shopping_basket.GetTotalAmount());
        }
        public void UpdateList(object sender, EventArgs e)
        {
            UpdateList();
        }

        
    }
}
