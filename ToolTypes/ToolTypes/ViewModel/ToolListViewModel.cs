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
using System.Windows.Data;

namespace ToolTypes.ViewModel
{
    public class ToolListViewModel : INotifyPropertyChanged
    {
        private ToolList _toollist;
        private ToolService _toolservice;
        private CollectionViewSource _ToolListDataView;
        private string _sortColumn;
        private ListSortDirection _sortDirection;

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
                _ToolListDataView = new CollectionViewSource();
                _ToolListDataView.Source = _toollist.toollist;
                NotifyPropertyChanged("ToolListDataView");
            }
        }

        public ListCollectionView ToolListDataView
        {
            get
            {
                return (ListCollectionView)_ToolListDataView.View;
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
                return new RelayCommand(Sort);
            }
        }

        #endregion

        public ToolListViewModel(ToolList toollist, ToolService toolservice)
        {
            ToolList = toollist;
            _toolservice = toolservice;
        }

        public void Sort(object parameter)
        {
            string column = parameter as string;
            if (_sortColumn == column)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ?
                                                   ListSortDirection.Descending :
                                                   ListSortDirection.Ascending  );
            }
            else
            {
                _sortColumn = column;
                _sortDirection = ListSortDirection.Ascending;
            }
            _ToolListDataView.SortDescriptions.Clear();
            _ToolListDataView.SortDescriptions.Add(new SortDescription(_sortColumn, _sortDirection));
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
