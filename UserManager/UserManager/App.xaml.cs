using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserManager.Model.Users;
using UserManager.Model.Encryption;
using UserManager.ViewModel;

namespace UserManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();

            User user = new User();
            UserRepository repo = new UserRepository();            
            PasswordHasher hasher = new HmacSha512Hasher();
            var viewModel = new UserManagerViewModel(user, repo, hasher);

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
