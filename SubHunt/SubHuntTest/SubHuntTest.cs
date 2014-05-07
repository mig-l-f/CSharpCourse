using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SubHuntCS
{
    public class SubGridTest
    {
        [Test]
        public void testThereIsOneSubmarine()
        {
            SubGrid grid = new SubGrid(2, 2);
            int counter = 0;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (grid.hasSubmarineInPosition(i,j))
                        counter++;

             Assert.True(counter == 1);
        }
        [Test]
        public void testGetUpperBound()
        {
            SubGrid grid = new SubGrid(5, 2);
            Assert.True(grid.GetUpperBound(0) == 4);
            Assert.True(grid.GetUpperBound(1) == 1);
        }

        [Test]
        public void testGetLowerBound()
        {
            SubGrid grid = new SubGrid(2, 3);
            Assert.True(grid.GetLowerBound(0) == 0);
            Assert.True(grid.GetLowerBound(1) == 0);
        }
        [Test]
        public void testFireUponPosition()
        {
            SubGrid grid = new SubGrid(2, 2);
            grid.hasSubmarineInPosition(0, 0);
            Assert.True(grid.hasPositionBeenFiredUpon(0, 0));
        }

    }
    
    public class SubHuntTest
    {
       [Test]
        public void nothing()
        {
            Assert.True(true);
        }
    }
}
