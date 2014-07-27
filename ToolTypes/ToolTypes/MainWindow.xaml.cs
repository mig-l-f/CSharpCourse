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
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Net.Http;
using ToolTypes.Model.Tools;

namespace ToolTypes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        CancellationTokenSource cts;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void time_Click(object sender, RoutedEventArgs e)
        {

            if (cts != null)
            {
                cts.Cancel();
            }
            // In this basic example, we pull over pre-formated text, and simply
            // assign it to the box.
            string url = "http://pmb.neongrit.net/aj/time.php";
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            tbOutput.Text = new StreamReader(ws.GetResponseStream()).ReadToEnd();
        }

        private void types_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
            // In this section, the root of the JSON is an object, which
            // we then need to map to or store in an instance of a
            // class we have created.
            String url = "http://pmb.neongrit.net/aj/selectJSON.php?type=1";
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            ToolList myTools = JsonConvert.DeserializeObject<ToolList>(new StreamReader(ws.GetResponseStream()).ReadToEnd());
            tbOutput.Text = String.Format("ID {0} is a {1}", myTools.toollist.First().toolID, myTools.toollist.First().toolLabel);
        }

        private void types_a_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
            // However, in our scenerio, this is an unnecessary step, since
            // the logical root is actually the array of tool items. By this
            // I mean that there's only one property in the root JSON object,
            // and that it's an array.
            // No point reinventing the wheel, let's store it in a List.
            // Note that this means I need to have the JSON array as the root
            // element, so I've edited the PHP script that generates the JSON.
            String url = "http://pmb.neongrit.net/aj/selectJSONarray.php?type=1";
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            List<Tool> tools = JsonConvert.DeserializeObject<List<Tool>>(new StreamReader(ws.GetResponseStream()).ReadToEnd());
            tbOutput.Text = String.Format("ID {0} is a {1}", tools.Last().toolID, tools.Last().toolLabel);
        }

        private void types_d_Click(object sender, RoutedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
            // What about when there's a delay? Perhaps the network is slow,
            // or the server busy.
            // This script, otherwise identical to the previous one,
            // simulates that with an artificial delay before it sends the data.
            // Try interacting with the app after triggering this.
            // No fun, is it?
            String url = "http://pmb.neongrit.net/aj/selectJSONarrayDelay.php?type=2";
            WebRequest request = WebRequest.Create(url);
            WebResponse ws = request.GetResponse();
            List<Tool> tools = JsonConvert.DeserializeObject<List<Tool>>(new StreamReader(ws.GetResponseStream()).ReadToEnd());
            tbOutput.Text = String.Format("ID {0} is a {1}", tools.Last().toolID, tools.Last().toolLabel); ;
        }

        private async void types_sa_Click(object sender, RoutedEventArgs e)
        {

            if (cts != null) 
            {
                cts.Cancel();
            }
                
            cts = new CancellationTokenSource();

            String url = "http://pmb.neongrit.net/aj/selectJSONarrayDelay.php?type=2";
            
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url, cts.Token);

                List<Tool> tools = JsonConvert.DeserializeObject<List<Tool>>(await response.Content.ReadAsStringAsync());
                tbOutput.Text = String.Format("ID {0} is a {1}", tools.First().toolID, tools.First().toolLabel);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Download canceled.");
            }
            catch (Exception)
            {
                Console.WriteLine("Download failed.");
            }
            finally
            {
                cts = null;
            }
            
        }        
    }
}
