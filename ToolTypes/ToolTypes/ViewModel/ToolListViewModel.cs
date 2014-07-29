using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using ToolTypes.Model;
using ToolTypes.Model.Tools;
using ToolTypes.Model.Service;
using System.ComponentModel;
using System.Windows.Input;

namespace ToolTypes.ViewModel
{
    public class ToolListViewModel : INotifyPropertyChanged
    {
        private ToolList _toollist;
        private ToolService _toolservice;

        #region Properties

        public ToolList ToolList
        {
            get
            {
                return _toollist;
            }
            set
            {
                _toollist = value;
                NotifyPropertyChanged("ToolList");
            }
        }

        public ICommand GetToolList
        {
            get
            {
                return new RelayCommand(async (param) => this.ToolList = await _toolservice.GetToolList(Convert.ToInt32(param)));
            }
        }

        public ICommand SortToolList
        {
            get
            {
                return new RelayCommand(
                    (param) => { 
                        this.ToolList.toollist.Sort(); 
                    });
            }
        }

        #endregion

        public ToolListViewModel(ToolList toollist, ToolService toolservice)
        {
            _toollist = toollist;
            _toolservice = toolservice;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
