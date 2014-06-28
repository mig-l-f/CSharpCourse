using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using FezStore.Model;

namespace FezStore.ViewModel
{
    public class ShoppingBasketViewModel : WorkspaceViewModel
    {
        #region Fields
        BasketList _shopping_basket;
        #endregion

        public ShoppingBasketViewModel(BasketList shopping_basket)
        {
            base.DisplayName = "Basket";
            _shopping_basket = shopping_basket;
        }

        #region Properties

        public ObservableCollection<FezItem> ShoppingItems
        {
            get
            {
                return _shopping_basket.shopping_basket;
            }
        }

        public double TotalAmount
        {
            get
            {
                return _shopping_basket.GetTotalAmount();
            }
        }

        #endregion
    }
}
