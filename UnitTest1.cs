using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimePeriodTime;
using TimeApp;
namespace TimeTest
{
    [TestClass]
    public class UnitTest1
    {

        private void AssertTime(Time p, byte expectedA, byte expectedB, byte expectedC)
        {
            Assert.AreEqual(expectedA, p.Hours);
            Assert.AreEqual(expectedB, p.Minutes);
            Assert.AreEqual(expectedC, p.Seconds);
        }
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(1, 2, 3,
                1, 2, 3)]
        [DataRow(2, 23, 3,
                2, 23,3)] // dla centymertów liczy siê tylko 1 miejsce po przecinku
        public void ConstructorForTime(byte a, byte b, byte c,
                                                     byte expectedA, byte expectedB, byte expectedC)
        {
            Time t = new Time(a,b,c);

            AssertTime(t, expectedA, expectedB, expectedC);
        }
    }
}
