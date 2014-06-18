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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ValidateMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string namePattern = @"^[A-Za-z][A-Za-z ]*[A-Za-z]$";
        private const string phonePattern = @"0\d{3}-\d{7}";
        private const string emailPattern = @"";

        private SolidColorBrush error = new SolidColorBrush(Color.FromRgb(255,225,225));
        private SolidColorBrush ok = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tbName.Text, namePattern))
            {
                tbName.Background = ok;
            }
            else
            {
                tbName.Background = error;
            }
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tbPhone.Text, phonePattern))
            {
                tbPhone.Background = ok;
            }
            else
            {
                tbPhone.Background = error;
            }
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(tbEmail.Text, emailPattern))
            {
                tbEmail.Background = ok;
            }
            else
            {
                tbEmail.Background = error;
            }
        }
    }
}
