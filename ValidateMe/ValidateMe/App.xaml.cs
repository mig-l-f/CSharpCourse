using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ValidateMe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Contact contact = new Contact();
            ContactViewModel contactViewModel = new ContactViewModel(contact);

            MainWindow window = new MainWindow();
            window.DataContext = contactViewModel;
            window.Show();
        }
    }
}
