using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SrtFixer;

namespace SrtFixerTest
{

    [TestFixture]
    public class MyTimeTest
    {
        //private MyDate date;

        //[SetUp]
        //public void createDate()
        //{
        //    this.date = new MyDate(0,0,1);
        //}

        [Test]
        public void testAddingTwoSeconds()
        {
            MyTime time = new MyTime(0, 0, 1);
            time.AddSeconds(2);
            Assert.True(time == new MyTime(0,0,3));
        }

        [Test]
        public void testAddingSecondWhenSecondsOverlapsMinutes()
        {
            MyTime time = new MyTime(0, 0, 59);
            time.AddSeconds(1);
            Assert.True(time == new MyTime(0, 1, 0));
            time.AddSeconds(10);
            Assert.True(time == new MyTime(0, 1, 10));
        }

        [Test]
        public void testAddingSecondWhenMinutesOverlapsHours()
        {
            MyTime time = new MyTime(0, 59, 58);
            time.AddSeconds(2);
            Assert.True(time == new MyTime(1, 0, 0));
        }

        [Test]
        public void testAddingSecondsWhenHoursOverlapsDays()
        {
            MyTime time = new MyTime(23, 59, 59);
            time.AddSeconds(3);
            Assert.True(time == new MyTime(0, 0, 2));
        }

        [Test]
        public void testDateToStringIsCorrect()
        {
            MyTime time = new MyTime(12, 45, 2);
            Assert.True(String.Compare("12:45:02", time.ToString()) == 0);
        }
    }

    [TestFixture]
    public class SrtFixerTest
    {
        [Test]
        public void nothing()
        {
            Assert.True(true);
        }

        [TestCase("03:16:45", 3, Result="03:16:48")]
        [TestCase("01:59:59", 3, Result="02:00:02")]
        [TestCase("11:38:90", 3, Result="11:39:33")]
        public string testProgramIncrementTimeDoesItCorrectly(string time, int additionalSeconds)
        {
            string output = Program.incrementTime(time, additionalSeconds);
            return output;
        }

    }
}
