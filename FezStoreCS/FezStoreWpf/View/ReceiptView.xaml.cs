using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FezStoreCS;

namespace FezStoreWpf
{
    /// <summary>
    /// Interaction logic for ReceiptView.xaml
    /// </summary>
    public partial class ReceiptView : Window
    {
        private BasketList shopping_basket;

        public ReceiptView(BasketList shopping_basket)
        {
            this.shopping_basket = shopping_basket;
            InitializeComponent();
            shopping_basket.AddedItem += new System.EventHandler(this.UpdateTotalPrice);
            UpdateTotalPrice(null, null);
        }

        private void receiptViewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = shopping_basket.shopping_basket;
        }
        private void UpdateTotalPrice(object sender, EventArgs e)
        {
            totalAmountTextBox.Text = String.Format("{0,2:C}", shopping_basket.GetTotalAmount());
        }

        private void TextBlock_Unloaded(object sender, RoutedEventArgs e)
        {
            shopping_basket.AddedItem -= this.UpdateTotalPrice;
        }
    }
}
