using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Security.Cryptography;
using System.IO;


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
            myBasket.AddedItem += (o, e) => { }; // Subscribing to event
        }

        [Test]
        public void addFezItemToList()
        {
            FezSize fez_size = new FezSize("Test Fez Size", 1.3);
            FezStyle fez_style = new FezStyle("Long Description", "Short", 15.0m, true);
            myBasket.Add(fez_size, fez_style);
            Assert.True(myBasket.Count() == 1);
        }

        [Test]
        public void testRetrievingObjectFromBasket()
        {
            FezSize fez_size = new FezSize("Test Fez Size", 1.3);
            FezStyle fez_style = new FezStyle("Long Description", "Short", 15.0m, true);
            myBasket.Add(fez_size, fez_style);
            FezItem item = myBasket[0];
            
        }

        [Test]
        public void testSumOfShoppingBasket()
        {
            FezSize fez_size = new FezSize("Test Fez Size", 1.3);
            FezStyle fez_style = new FezStyle("Long Description", "Short", 15.0m, true);
            myBasket.Add(fez_size, fez_style);
            myBasket.Add(fez_size, fez_style);
            Assert.AreEqual(myBasket.GetTotalAmount(), (double)(2 * 1.3 * 15.0));
        }

        [Test]
        public void testExportBasketToCSV()
        {
            FezSize fez_size = new FezSize("M", 1.00);
            FezStyle fez_style = new FezStyle("This is classy.\nLined in PVC.", "The Imperial", 30.45m, true);
            myBasket.Add(fez_size, fez_style);
            String filename = @"csvExport.txt";
            String referenceFile = @"../../refCsvExport.csv";
            myBasket.ExportToCSV(filename);
            Assert.True(compare2FilesByHash(filename, referenceFile));
            File.Delete(filename);
        }

        private bool compare2FilesByString(String file1, String file2)
        {
            StreamReader stream1 = new StreamReader(file1);
            StreamReader stream2 = new StreamReader(file2);

            String file1Text = stream1.ReadToEnd();
            String file2Text = stream2.ReadToEnd();

            stream1.Close();
            stream2.Close();

            return String.Compare(file1Text, file2Text) == 0;

        }

        private bool compare2FilesByHash(String file1, String file2){
            // Source: http://www.c-sharpcorner.com/uploadfile/kirtan007/compare-two-files-with-hash-algorithm/
            HashAlgorithm ha = HashAlgorithm.Create();
            FileStream f1 = new FileStream(file1, FileMode.Open);
            FileStream f2 = new FileStream(file2, FileMode.Open);
            /* Calculate Hash */
            byte[] hash1 = ha.ComputeHash(f1);
            byte[] hash2 = ha.ComputeHash(f2);
            f1.Close();
            f2.Close();
            return String.Compare(BitConverter.ToString(hash1), BitConverter.ToString(hash2)) == 0;
        }

    }

}
