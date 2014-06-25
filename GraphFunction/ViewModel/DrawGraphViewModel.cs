using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using GraphFunction.Model;

namespace GraphFunction.ViewModel
{
    public class DrawGraphViewModel
    {
        private List<Function> availableFunctions = new List<Function>();

        public List<Function> AvailableFunctions 
        { 
            get 
            {
                return availableFunctions;
            }
            set 
            {
                availableFunctions = value;
            } 
        }

    }
}
