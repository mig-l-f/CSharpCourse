using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using FezStore.Model;


namespace FezStore.ViewModel
{
    public class StoreViewModel : WorkspaceViewModel
    {

        #region Fields

        BasketList _shopping_basket;
        FezItem _selected_fez_item;
        //public event Action OnAddToBasket;
        private RelayCommand _addToBasket; 
        #endregion

        #region Constructors
        //public StoreViewModel() 
        //{
        //    base.DisplayName = "Store";
        //    OnAddToBasket += AddToBasket;
        //}

        public StoreViewModel(BasketList shopping_basket)
        {
            base.DisplayName = "Store";
            _shopping_basket = shopping_basket;
            _selected_fez_item = new FezItem();
            //OnAddToBasket += AddToBasket;
        }
        public StoreViewModel(BasketList shopping_basket, FezItem fez_item)
        {
            base.DisplayName = "Store";
            _shopping_basket = shopping_basket;
            _selected_fez_item = fez_item;
            //OnAddToBasket += AddToBasket;
        }
        #endregion

        #region Properties

        public FezSize SelectedFezSize 
        {
            get 
            {
                if (_selected_fez_item != null)
                    return _selected_fez_item.fez_size_;
                return null;
            }
            set 
            {
                _selected_fez_item.fez_size_ = value;
                base.OnPropertyChanged("Price");
            }
        }

        public FezStyle SelectedFezStyle
        {
            get
            {
                return _selected_fez_item.fez_style_;                
            }
            set
            {
                _selected_fez_item.fez_style_ = value;
                base.OnPropertyChanged("LongDescription");
                base.OnPropertyChanged("Price");
            }
        }

        public double Price
        {
            get
            {
                return _selected_fez_item.Price;
            }
            set
            {
                _selected_fez_item.Price = value;
            }
        }

        public String LongDescription
        {
            get
            {
                if (SelectedFezStyle != null)
                    return SelectedFezStyle.longDescription;
                else
                    return "No Description";
            }
        }

        public RelayCommand AddToBasket
        {
            get
            {
                if (_addToBasket == null)
                    _addToBasket = new RelayCommand(param => this.AddCurrentFezItemToBasket());

                return _addToBasket;
            }
        }
        #endregion

        #region Helpers

        //public void AddToBasket(object sender, RoutedEventArgs e)
        //{
        //    AddCurrentFezItemToBasket();
        //}

        private void AddCurrentFezItemToBasket()
        {
            _shopping_basket.Add(SelectedFezSize, SelectedFezStyle);
            Console.WriteLine("Added new item");
        }

        #endregion
    }
}
