using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimePeriodTime;
using TimeApp;
using System;

namespace TimeTest
{

    [TestClass]
    public class UnitTest1
    {
        #region Constructors ===========================================
      /*  [TestMethod]
        private void AssertTime(Time t, byte expectedA, byte expectedB, byte expectedC)
        {
            Assert.AreEqual(expectedA, t.Hours);
            Assert.AreEqual(expectedB, t.Minutes);
            Assert.AreEqual(expectedC, t.Seconds);
        }*/
        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTime_3params()
        {
            Time t = new Time(10, 12, 10);
            Time t2 = new Time(22, 22,23);
            Time t3 = new Time(1, 1, 23);

            Assert.AreEqual(t2.Hours, 22); Assert.AreEqual(t2.Minutes, 22); Assert.AreEqual(t2.Seconds, 23);
            Assert.AreEqual(t.Hours, 10); Assert.AreEqual(t.Minutes, 12); Assert.AreEqual(t.Seconds, 10);
            Assert.AreEqual(t3.Hours, 1); Assert.AreEqual(t3.Minutes, 1); Assert.AreEqual(t3.Seconds, 23);
        }
        /*[TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
       
            [DataRow(1, 1, 1,1,0)]
            [DataRow(12,23,12,23,0)]
            [DataRow(10, 10, 10, 10, 0)]
        public void ConstructorTime_2params(byte a, byte b, byte expectedA, byte expectedB, byte expectedC)
        {
            Time t2 = new Time(a, b);
          

            AssertTime(t2,expectedA,expectedB,expectedC);
            
        }*/
        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTime_2params()
        {
            Time t = new Time(10, 12);
            Time t2 = new Time(22, 22);
            Time t3 = new Time(1, 1);


            Assert.AreEqual(t.Hours, 10); Assert.AreEqual(t.Minutes, 12); Assert.AreEqual(t.Seconds, 0);
            Assert.AreEqual(t2.Hours, 22); Assert.AreEqual(t2.Minutes, 22); Assert.AreEqual(t2.Seconds, 0);
            Assert.AreEqual(t3.Hours, 1); Assert.AreEqual(t3.Minutes, 1); Assert.AreEqual(t3.Seconds, 0);
        }
        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTime_1param()
        {
            Time t = new Time(10);
            Time t2 = new Time(22);
            Time t3 = new Time(11);


            Assert.AreEqual(t.Hours, 10); Assert.AreEqual(t.Minutes, 0); Assert.AreEqual(t.Seconds, 0);
            Assert.AreEqual(t2.Hours, 22); Assert.AreEqual(t2.Minutes, 0); Assert.AreEqual(t2.Seconds, 0);
            Assert.AreEqual(t3.Hours, 11); Assert.AreEqual(t3.Minutes, 0); Assert.AreEqual(t3.Seconds, 0);
        }

        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTime_String()
        {
            Time t = new Time("10:22:22");
            Time t2 = new Time("22:22:22");
            Time t3 = new Time("11:0:0");


            Assert.AreEqual(t.Hours, 10); Assert.AreEqual(t.Minutes, 22); Assert.AreEqual(t.Seconds, 22);
            Assert.AreEqual(t2.Hours, 22); Assert.AreEqual(t2.Minutes, 22); Assert.AreEqual(t2.Seconds, 22);
            Assert.AreEqual(t3.Hours, 11); Assert.AreEqual(t3.Minutes, 0); Assert.AreEqual(t3.Seconds, 0);
        }

        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTimePeriod_3params()
        {
            TimePeriod t = new TimePeriod(10,22,34);
            TimePeriod t2 = new TimePeriod(10, 222, 80);
            TimePeriod t3 = new TimePeriod(10,-23,20);

            Assert.AreEqual(t.Hours, 10); Assert.AreEqual(t.Minutes, 22); Assert.AreEqual(t.Seconds, 34);
            Assert.AreEqual(t2.Hours, 13); Assert.AreEqual(t2.Minutes, 43); Assert.AreEqual(t2.Seconds, 20);
            Assert.AreEqual(t3.Hours, 10); Assert.AreEqual(t3.Minutes, 0); Assert.AreEqual(t3.Seconds, 20);
        }
        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTimePeriod_2params()
        {
            TimePeriod t = new TimePeriod(10, 22);
            TimePeriod t2 = new TimePeriod(10, 222);
            TimePeriod t3 = new TimePeriod();

            Assert.AreEqual(t.Hours, 10); Assert.AreEqual(t.Minutes, 22); Assert.AreEqual(t.Seconds, 0);
            Assert.AreEqual(t2.Hours, 13); Assert.AreEqual(t2.Minutes, 42); Assert.AreEqual(t2.Seconds, 0);
            Assert.AreEqual(t3.Hours, 0); Assert.AreEqual(t3.Minutes, 0); Assert.AreEqual(t3.Seconds, 0);
        }
        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTimePeriod_String()
        {
            TimePeriod t = new TimePeriod("22:22:22");
            TimePeriod t2 = new TimePeriod("22:10:22");
            TimePeriod t3 = new TimePeriod("22:0:34");

            Assert.AreEqual(t.DlugoscOdcinka, 80542);
            Assert.AreEqual(t2.DlugoscOdcinka, 79822);
            Assert.AreEqual(t3.DlugoscOdcinka, 79234);
        }

        [TestMethod]
        [DataTestMethod, TestCategory("Constructors")]
        public void ConstructorTimePeriod_Time_Params()
        {
            Time t1 = new Time(10, 10, 20);
            Time t2 = new Time(20, 20, 0);
            TimePeriod t = new TimePeriod(t2,t1);
           

            Assert.AreEqual(t.Hours,10);
            Assert.AreEqual(t.Minutes, 9);
            Assert.AreEqual(t.Seconds, 40);
          
        }

        [DataTestMethod, TestCategory("Constructors")]
       
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Time_ArgumentOutOfRangeException()
        {
            Time p = new Time(10,220,2);
            Time p1 = new Time(100, 2, 20);
        }


        #endregion

        #region String representation====

        [TestMethod, TestCategory("String representation")]
        public void ToString_Default_Culture_EN()
        {
            var p = new Time(20, 9,2);
            string expectedStringEN = "20:09:02";
            var p1 = new Time(1, 23, 22);
            string expectedStringEN2 = "01:23:22";

            var t = new TimePeriod(1,23,22);
            string expectedStringEN3 = "1:23:22";
            var t2 = new TimePeriod(1, 232, 22);
            string expectedStringEN4 = "4:52:22";
            var t3 = new TimePeriod(122,53,22);
            string expectedStringEN5 = "122:53:22";

            Assert.AreEqual(expectedStringEN, p.ToString());
            Assert.AreEqual(expectedStringEN2, p1.ToString());
            Assert.AreEqual(expectedStringEN4, t2.ToString());
            Assert.AreEqual(expectedStringEN3, t.ToString());
            Assert.AreEqual(expectedStringEN5, t3.ToString());
        }

        [DataTestMethod, TestCategory("Constructors")]

        [ExpectedException(typeof(FormatException))]
        public void Constructor_Time_FormatException()
        {
            Time p = new Time("10,220,2");
            Time p1 = new Time("100:2,20");
            TimePeriod p3 = new TimePeriod("100:2,20");
            TimePeriod p4 = new TimePeriod("10  2 ,20");
        }
        #endregion
        #region operatory =================

        [DataTestMethod, TestCategory("Operators")]
        public void Equality_Time()
        {
            //AAA

            var t = new Time(1,20,2);
            var t1 = new Time(1, 20, 2);
            var t2 = new Time(2, 3, 9);
            var t3 = new Time(1, 20, 34);
            

            Assert.IsTrue(t == t1);
            Assert.IsTrue(t != t2);
            Assert.IsTrue(t >= t1);
            Assert.IsTrue(t <= t1);
            Assert.IsTrue(t != t2);
            Assert.IsTrue(t <= t3);
            Assert.IsTrue(t < t3);
            Assert.IsTrue(t2 > t3);

        }


        [DataTestMethod, TestCategory("Operators")]
        public void Equality_TimePeriod()
        {
            //AAA

            var t = new TimePeriod(1, 20, 2);
            var t1 = new TimePeriod(0, 80, 2);
            var t2 = new TimePeriod(2, 3, 9);
            var t3 = new TimePeriod(1, 20, 34);


            Assert.IsTrue(t == t1);
            Assert.IsTrue(t != t2);
            Assert.IsTrue(t >= t1);
            Assert.IsTrue(t <= t1);
            Assert.IsTrue(t != t2);
            Assert.IsTrue(t <= t3);
            Assert.IsTrue(t < t3);
            Assert.IsTrue(t2 > t3);

        }

        #endregion
    }
}
