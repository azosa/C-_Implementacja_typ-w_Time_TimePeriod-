using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie_TIME;

namespace UnitTestProject
{
  
    [TestClass]
    public class UnitTestTimePeriod

    {
        [TestMethod]
        public void konstruktorJednoargumentowy()
        {
            TimePeriod t1 = new TimePeriod(7200);
            TimePeriod t2 = new TimePeriod("02:00:00");

            Assert.AreEqual(t1, t2);

        }
        [TestMethod]
        public void konstruktorDwuargumentowy()
        {
            TimePeriod t1 = new TimePeriod(4, 32);
            TimePeriod t2 = new TimePeriod("00:04:32");

            Assert.AreEqual(t1, t2);

        }
        [TestMethod]
        public void konstruktorTrzyargumentowy()
        {
            TimePeriod t1 = new TimePeriod(4, 32, 54);
            TimePeriod t2 = new TimePeriod("04:32:54");

            Assert.AreEqual(t1, t2);

        }
        [TestMethod]
        public void metodaRownosci()
        {
            TimePeriod t1 = new TimePeriod(9600);
            TimePeriod t2 = new TimePeriod("02:40:00");
            TimePeriod t3 = new TimePeriod("22:40:00");
            Assert.AreEqual(t1, t2);
            Assert.AreNotEqual(t1, t3);
        }

        [TestMethod]
        public void metodaNierownosci()
        {
            TimePeriod t1 = new TimePeriod(3200);
            TimePeriod t2 = new TimePeriod(11322);
            TimePeriod t3 = new TimePeriod(25555);
            Assert.IsTrue(t1< t2);
            Assert.IsTrue(t3 > t1);
        }

        [TestMethod]
        public void metodyPlusMinus()
        {
          
            var t3 = new TimePeriod(11, 41,0);
            var t4 = new TimePeriod(9, 41, 0);
            var t5 = new TimePeriod(7200);
            var t6 = new TimePeriod("13:41:00");

            Assert.IsTrue(t3 - t5 == t4);
            Assert.IsTrue(t3 + t5 == t6);
        }
    }
}
