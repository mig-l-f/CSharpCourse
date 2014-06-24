using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FezStore.ViewModel;

namespace FezStore.Test
{
    [TestFixture]
    public class ViewModelBaseTest
    {
        [Test]
        public void nothing()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void TestPropertyChangedIsRaisedCorrectly()
        {
            TestViewModel target = new TestViewModel();
            bool eventWasRaised = false;
            target.PropertyChanged += (sender, e) => eventWasRaised = e.PropertyName == "GoodProperty";
            target.GoodProperty = "Some new value...";
            Assert.IsTrue(eventWasRaised, "PropertyChanged event was not raised correctly.");
        }
       [Test]
        public void TestExceptionIsThrownOnInvalidPropertyName()
        {
            TestViewModel target = new TestViewModel();
            try
            {
                target.BadProperty = "New value...";
                Assert.Fail("Exception not thrown!");
            }
            catch (Exception exp)
            {
                Assert.True(true, exp.ToString());
            }
        }
       [Test]
       public void TestDisposeIsCalled()
       {
           TestViewModel target = new TestViewModel();
           target.Dispose();
           Assert.True(target.disposed);
       }
    }

    class TestViewModel : ViewModelBase
    {
        //protected override bool ThrowOnInvalidPropertyName
        //{
        //    get { return true; }
        //}

        public string GoodProperty
        {
            get { return null; }
            set
            {
                base.OnPropertyChanged("GoodProperty");
            }
        }

        public string BadProperty
        {
            get { return null; }
            set
            {
                base.OnPropertyChanged("ThisIsAnInvalidPropertyName!");
            }
        }

        #region Disposable

        public bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) { }

            disposed = true;
            base.Dispose(disposing);
        }

        #endregion
    }

}
