using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FezStoreCS
{
    public partial class ReceiptView : Form
    {
        private BasketList shopping_basket;

        public ReceiptView(BasketList basket)
        {
            shopping_basket = basket;
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
        }
        public void UpdateList(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
