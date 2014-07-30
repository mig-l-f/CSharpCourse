using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows;
using ToolTypes.Model.Service;
using ToolTypes.Model.Tools;
using ToolTypes.ViewModel;
using ToolTypes.View;
using System.Net.Http;


namespace ToolTypes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ToolListView view = new ToolListView();

            ToolList toolList = new ToolList();

            HttpClient httpClient = new HttpClient();
            ToolServiceProvider serviceProvider = new ToolServiceProvider(httpClient);
            ToolService toolService = new ToolService(serviceProvider);
            ToolListViewModel viewModel = new ToolListViewModel(toolList, toolService);

            view.DataContext = viewModel;
            view.Show();
        }
    }

    
}
