using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ToolTypes.Model.Tools;
using ToolTypes.Model.Service;
using ToolTypes.ViewModel;

namespace ToolTypesTest
{
    [TestFixture]
    public class ToolListViewModelTest
    {
        [Test]
        public void getTypesCommandReturnsToolListCorrectly()
        {
            string output = @"{""toollist"":[{""toolID"":10,""toolLabel"":""this is a label""}]}";
            var toolProviderMock = Substitute.For<IToolServiceProvider>();
            toolProviderMock.GetToolListAsync(1).Returns(Task.FromResult(output));

            ToolService toolservice = new ToolService(toolProviderMock);
            ToolList toollist = new ToolList();
            ToolListViewModel target = new ToolListViewModel(toollist, toolservice);

            target.GetToolList.Execute(1);
            Assert.AreEqual(1, target.ToolList.toollist.Count, "Toollist should have 1 element");
            Assert.AreEqual(10, target.ToolList.toollist[0].toolID, "ToolID should be 10");
        }

        [Test]
        public void verifyNotificationOfToolListChangeOccurs()
        {
            string output = @"{""toollist"":[{""toolID"":10,""toolLabel"":""this is a label""}]}";
            var toolProviderMock = Substitute.For<IToolServiceProvider>();
            toolProviderMock.GetToolListAsync(1).Returns(Task.FromResult(output));

            ToolService toolservice = new ToolService(toolProviderMock);
            ToolList toollist = new ToolList();
            ToolListViewModel target = new ToolListViewModel(toollist, toolservice);

            bool eventWasRaised = false;
            target.PropertyChanged += (sender, e) => eventWasRaised = e.PropertyName == "ToolList";
            target.GetToolList.Execute(1);

            Assert.IsTrue(eventWasRaised, "Event for username change should have been raised");
        }
    }
}
