﻿using System;
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

            Assert.IsTrue(eventWasRaised, "Event for toollist change should have been raised");
        }

        [Test]
        public void sortListByToolIDUsingCommand()
        {
            ToolList list = new ToolList();
            list.toollist.Add(new Tool() { toolID = 10, toolLabel = "aaaa"});
            list.toollist.Add(new Tool() { toolID = 4, toolLabel = "vvvv"});

            ToolListViewModel target = new ToolListViewModel(list, null);

            bool eventWasRaised = false;
            target.PropertyChanged += (sender, e) => eventWasRaised = e.PropertyName == "ToolList";
            target.SortToolList.Execute("toolID");

            Assert.AreEqual(4, target.ToolList.toollist[0].toolID, "Tool list should have been sorted by toolID");
            Assert.IsTrue(eventWasRaised, "Event for toollist change should have been raised");
        }

        [Test]
        public void sortListByToolLabelUsingCommand()
        {
            ToolList list = new ToolList();
            list.toollist.Add(new Tool() { toolID = 10, toolLabel = "zzzz" });
            list.toollist.Add(new Tool() { toolID = 5, toolLabel = "jjjj" });
            list.toollist.Add(new Tool() { toolID = 4, toolLabel = "vvvv" });

            ToolListViewModel target = new ToolListViewModel(list, null);

            target.SortToolList.Execute("toolLabel");
            Assert.AreEqual("jjjj", target.ToolList.toollist[0].toolLabel, "Tool list should be sorted by Label");
            Assert.AreEqual("vvvv", target.ToolList.toollist[1].toolLabel, "Tool list should be sorted by Label");
            Assert.AreEqual("zzzz", target.ToolList.toollist[2].toolLabel, "Tool list should be sorted by Label");

        }
    }
}
