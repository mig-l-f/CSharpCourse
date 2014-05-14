using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace FezStoreCS
{
    [TestFixture]
    public class FezTest
    {

        private FezItem fez_item;
        [SetUp]
        public void Init()
        {
            FezSize fez_size = new FezSize("Test Fez Size", 1.3);
            FezStyle fez_style = new FezStyle("Long Description", "Short", 15.0m, true);
            fez_item = new FezItem(fez_size, fez_style);
        }
        
        [Test]
        public void nothing()
        {
            Assert.True(true);
        }

        [Test]
        public void calculateFezItemPrice()
        {
            Assert.True(fez_item.getPrice() == (15.0 * 1.3));
        }


    }

    [TestFixture]
    public class BasketListTest
    {
        private BasketList myBasket;
        [SetUp]
        public void init()
        {
            myBasket = new BasketList();
        }

        [Test]
        public void addFezItemToList()
        {
            FezSize fez_size = new FezSize("Test Fez Size", 1.3);
            FezStyle fez_style = new FezStyle("Long Description", "Short", 15.0m, true);
            //FezItem fez_item = new FezItem(fez_size, fez_style);
            myBasket.Add(fez_size, fez_style);
            Assert.True(myBasket.Count() == 1);
        }

    

    }

}
