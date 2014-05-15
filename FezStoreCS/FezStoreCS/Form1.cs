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
    public partial class Form1 : Form
    {

        private BasketList myBasket;

        public Form1(BasketList basket)
        {
            myBasket = basket;

            InitializeComponent();

            cbFezStyle.Items.Add(new FezStyle("This is classy.\nLined in PVC.",
                "The Imperial", 30.45m, true));
            cbFezStyle.Items.Add(new FezStyle("This is really classy.\nLined in mink.",
                "The Royale", 45.27m, true));
            cbFezStyle.Items.Add(new FezStyle("This is so damn classy.\nLined in gold plated mink.",
                "The Continental", 77.09m, true));
            cbFezStyle.SelectedIndex = 0;

            cbFezSize.Items.Add(new FezSize("Baby (-10%)", 0.90));
            cbFezSize.Items.Add(new FezSize("S", 1.00));
            cbFezSize.Items.Add(new FezSize("M", 1.00));
            cbFezSize.Items.Add(new FezSize("L", 1.00));
            cbFezSize.Items.Add(new FezSize("XL (+20%)", 1.20));
            cbFezSize.SelectedIndex = 2;
        }

        private void cbFezStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbLongDesc.Text = ((FezStyle)((ComboBox)sender).SelectedItem).longDescription;
            calculatePrice();
        }

        private void calculatePrice()
        {
            try
            {
                lblPrice.Text = "£" + (Convert.ToDouble(((FezStyle)(cbFezStyle.SelectedItem)).basePrice)
                    * ((FezSize)(cbFezSize.SelectedItem)).priceModifier).ToString();
            }
            catch (NullReferenceException e)
            { 
                // Triggered upon start up when comboBoxes are not fully set up.
                // Shouldn't happen after that.
            }
               
        }

        private void cbFezSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            myBasket.Add((FezSize)(cbFezSize.SelectedItem),(FezStyle)(cbFezStyle.SelectedItem));
        }

        private void viewReceiptButton_Click(object sender, EventArgs e)
        {
            ReceiptView rv = new ReceiptView(myBasket);
            rv.Show();
        }
    }
}
