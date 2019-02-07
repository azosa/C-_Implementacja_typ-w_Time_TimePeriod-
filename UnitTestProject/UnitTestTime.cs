using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie_TIME;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestTime
    {

        [TestMethod]
        public void konstruktorJednoargumentowy()
        {
            Time t1 = new Time(2);
            Time t2 = new Time("02:00:00");
            
            Assert.AreEqual(t1, t2);
            
        }
        [TestMethod]
        public void konstruktorDwuargumentowy()
        {
            Time t1 = new Time(4,32);
            Time t2 = new Time("04:32:00");

            Assert.AreEqual(t1, t2);

        }
        [TestMethod]
        public void konstruktorTrzyargumentowy()
        {
            Time t1 = new Time(4, 32,54);
            Time t2 = new Time("04:32:54");

            Assert.AreEqual(t1, t2);

        }
        [TestMethod]
        public void metodaRownosci()
        {
            Time t1 = new Time(2, 40, 00);
            Time t2 = new Time("02:40:00");
            Time t3 = new Time("22:40:00");
            Assert.AreEqual(t1,t2);
            Assert.AreNotEqual(t1, t3);
        }

        [TestMethod]
        public void metodaNierownosci()
        {
            Time t1 = new Time(2, 40, 00);
            Time t2 = new Time("02:40:00");
            Time t3 = new Time("22:40:00");
            Assert.IsTrue(t1>=t2);
            Assert.IsTrue(t1<t3);
        }

        [TestMethod]
        public void metodyPlusMinus()
        {
            var t1 = new Time(1, 20, 30);
            var t2 = new Time(10,20,30);
            var t3 = new Time(11, 41);
            var t4 = new Time(9, 0, 0);
            var t5 = new TimePeriod(7200);
            var t6 = new Time("13:41:00");

            Assert.IsTrue(t1 + t2 == t3);
            Assert.IsTrue(t1 - t2 == t4);
            Assert.IsTrue(t3 + t5 == t6);
        }

    }
}
