using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphFunction.ViewModel;
using GraphFunction.Model;

namespace GraphFunction
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DrawGraphViewModel drawGraphViewModel = new DrawGraphViewModel();
            drawGraphViewModel.AvailableFunctions.Add(new Function1());
            drawGraphViewModel.AvailableFunctions.Add(new Function2());
            drawGraphViewModel.AvailableFunctions.Add(new Function3());            
            Application.Run(new Form1(drawGraphViewModel));
        }
    }
}
