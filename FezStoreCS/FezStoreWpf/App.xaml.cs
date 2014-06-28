using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FezStore.Model;
using FezStore.View;
using FezStore.ViewModel;

namespace FezStore
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

            BasketList shopping_basket = new BasketList();
            //FezSelection window = new FezSelection(shopping_basket);
            MainWindowView window = new MainWindowView();
            var viewModel = new MainWindowViewModel(shopping_basket);
            window.DataContext = viewModel;
            window.Show();
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            BasketList basket = new BasketList();
            App myApp = new App(basket);
            myApp.Run();
        }
    }

}
