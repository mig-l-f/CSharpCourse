using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FezStoreCS;

namespace FezStoreWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private BasketList shopping_basket;

        public App()
        {
            shopping_basket = new BasketList();
        }

        public App(BasketList shopping_basket)
        {
            this.shopping_basket = shopping_basket;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            FezSelection window = new FezSelection(shopping_basket);
            window.Show();
        }
    }
}
