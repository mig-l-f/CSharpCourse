using System;
using NUnit.Framework;
using FezStore.Model;
using FezStore.ViewModel;

namespace FezStore.Test
{
    [TestFixture]
    public class StoreViewModelTest
    {
        BasketList basket;        
        
        [SetUp]
        public void setup()
        {
            basket = new BasketList();
            //FezSize fez_size = new FezSize("Test Fez Size", 1.2);
            //FezStyle fez_style = new FezStyle("Long Description", "Short", 15.0m, true);
            //fez_item = new FezItem(fez_size, fez_style);
        }

        [Test]
        public void TestPriceIsUpdatedWhenFezSizeChanges()
        {
            
            StoreViewModel target = new StoreViewModel(basket);
            target.SelectedFezSize = new FezSize("Test Fez Size", 1.2);
            target.SelectedFezStyle = new FezStyle("Long Description", "Short", 15.0m, true);
            Assert.AreEqual((15.0 * 1.2), target.Price, "Target price is wrong");

            //target.PropertyChanged += (sender, e) =>
            //{
                
            //};
            target.SelectedFezSize = new FezSize("Test Fez Size", 1.2);
            target.SelectedFezStyle = new FezStyle("FezStyle", "FS", 20.0m, true);
            Assert.AreEqual((20.0 * 1.2), target.Price, "modified price is wrong");
        }

        [Test]
        public void TestAddNewFezItemToShoppingBasket()
        {
            StoreViewModel target = new StoreViewModel(basket);
            target.SelectedFezSize = new FezSize("Test Fez Size", 1.2);
            target.SelectedFezStyle = new FezStyle("Long Description", "Short", 15.0m, true);
            Assert.AreEqual(0, basket.shopping_basket.Count, "shopping basket contains elements");

            target.SelectedFezStyle = new FezStyle("FezStyle", "FS", 23.0m, true);

            target.AddToBasket.Execute(null);

            Assert.AreEqual(1, basket.shopping_basket.Count, "shopping basket does not contain elements");
            Assert.AreEqual((23.0 * 1.2), basket.shopping_basket[0].getPrice());
        }        
    }
}
