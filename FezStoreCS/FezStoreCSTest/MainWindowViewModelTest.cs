using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
//using System.Text;
//using System.Threading.Tasks;
using NUnit.Framework;
using FezStore.ViewModel;
using FezStore.Properties;

namespace FezStoreCSTest
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void TestStoreView()
        {
            MainWindowViewModel target = new MainWindowViewModel();
            CommandViewModel commandVM = target.Commands.First(cvm => cvm.DisplayName == Strings.MainWindowViewModel_Command_Store);
            commandVM.Command.Execute(null);

            var collectionView = CollectionViewSource.GetDefaultView(target.Workspaces);
            Assert.IsTrue(collectionView.CurrentItem is StoreViewModel, "Invalid current item");
        }

        [Test]
        public void TestShoppingBasketView()
        {
            MainWindowViewModel target = new MainWindowViewModel();
            CommandViewModel commandVM = target.Commands.First(cvm => cvm.DisplayName == Strings.MainWindowViewModel_Command_ShoppingBasket);
            commandVM.Command.Execute(null);

            var collectionView = CollectionViewSource.GetDefaultView(target.Workspaces);
            Assert.IsTrue(collectionView.CurrentItem is ShoppingBasketViewModel, "Invalid current view");
        }

        [Test]
        public void TestCannotViewShoppingBasketTwice()
        {
            MainWindowViewModel target = new MainWindowViewModel();
            CommandViewModel commandVM = target.Commands.First(cvm => cvm.DisplayName == Strings.MainWindowViewModel_Command_ShoppingBasket);
            commandVM.Command.Execute(null);
            commandVM.Command.Execute(null);

            var collectionView = CollectionViewSource.GetDefaultView(target.Workspaces);
            Assert.IsTrue(collectionView.CurrentItem is ShoppingBasketViewModel, "Invalid current view");
            Assert.IsTrue(target.Workspaces.Count == 1, "Invalid number of view models");
        }

        [Test]
        public void TestCloseViewShoppingBasketView()
        {
            MainWindowViewModel target = new MainWindowViewModel();
            Assert.AreEqual(0, target.Workspaces.Count, "Workspace isnt empty");

            CommandViewModel commandVM = target.Commands.First(cvm => cvm.DisplayName == Strings.MainWindowViewModel_Command_ShoppingBasket);
            commandVM.Command.Execute(null);
            Assert.AreEqual(1, target.Workspaces.Count, "Did not create view model");

            var shoppingBasketVM = target.Workspaces[0] as ShoppingBasketViewModel;
            Assert.IsNotNull(shoppingBasketVM, "wrong view model created");

            shoppingBasketVM.CloseCommand.Execute(null);
            Assert.AreEqual(0, target.Workspaces.Count, "workspace was not closed");
        }         
    }
}
