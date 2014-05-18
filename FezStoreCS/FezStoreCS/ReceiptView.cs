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
            shopping_basket.AddedItem += new System.EventHandler(this.UpdateList);
            InitializeComponent();
            receiptList.View = View.Details;
            receiptList.Columns.Add("Style", -2, HorizontalAlignment.Left);
            receiptList.Columns.Add("Size", -2, HorizontalAlignment.Right);
            // TODO: Add a price column
            // receiptList.Columns.Add("Price", -2, HorizontalAlignment.Left);
            UpdateList();
        }

        private void UpdateList()
        {

            // TODO: Is there a neater way to do this, where we keep
            // directly in sync with the internal List of items
            // purchased?
            receiptList.BeginUpdate();
            receiptList.Items.Clear();
            for (int x = 0; x < shopping_basket.Count(); x++)
            {
                receiptList.Items.Add(
                    new ListViewItem(
                        new String[] { shopping_basket[x].shortDescription(), shopping_basket[x].label() }
                    )
                );
            }

            // This set of statements tries two types of auto-resizing- one
            // based on the width of the column header text, and one based
            // on the longest content row.
            // By testing which results in the widest column (and reverting
            // if that ColumnHeaderAutoResizeStyle is narrower), we can make
            // sure nothing ends up hidden.
            // This would cause visible flickering if not for the BeginUpdate()
            // and EndUpdate() calls surrounding this method.
            receiptList.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.ColumnContent);
            int width = receiptList.Columns[0].Width;
            receiptList.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.HeaderSize);
            if (receiptList.Columns[0].Width < width)
                receiptList.AutoResizeColumn(0,
                ColumnHeaderAutoResizeStyle.ColumnContent);

            receiptList.AutoResizeColumn(1,
                ColumnHeaderAutoResizeStyle.ColumnContent);
            width = receiptList.Columns[1].Width;
            receiptList.AutoResizeColumn(1,
                ColumnHeaderAutoResizeStyle.HeaderSize);
            if (receiptList.Columns[1].Width < width)
                receiptList.AutoResizeColumn(1,
                ColumnHeaderAutoResizeStyle.ColumnContent);

            receiptList.EndUpdate();
            
            // Update total value
            totalAmountTextBox.Text = String.Format("{0,2:C}", shopping_basket.GetTotalAmount());
        }
        public void UpdateList(object sender, EventArgs e)
        {
            UpdateList();
        }

        
    }
}
