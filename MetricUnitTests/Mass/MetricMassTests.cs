using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIUnits;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace SIUnits.Tests
{
    [TestClass]
    public class MetricMassTests
    {
        [TestMethod]
        public void UnitMassTest()
        {
            var m1 = 5.kg() + 2.kg();
            var m2 = 5.kg() * 2.kg();
            var m3 = 2.kg() * 3;
            var m4 = 5.kg() / 1.kg();
            var m5 = 3.kg(2) / 1.kg();
            var m6 = 2.kg() / 1.kg(2);
            var m7 = 4.kg() / 2;
            var m8 = 4.kg() / 200.g();
            var m9 = 4.kg() * 2.tonne();
            Assert.AreEqual(7.kg() == m1, true);
            Assert.AreEqual(10.kg(2) == m2, true);
            Assert.AreEqual(6.kg() == m3, true);
            Assert.AreEqual(5.kg(0) == m4, true);
            Assert.AreEqual(3.kg() == m5, true);
            Assert.AreEqual(2.kg(-1) == m6, true);
            Assert.AreEqual(2.kg() == m7, true);
            Assert.AreEqual(20.kg(0) == m8, true);
            Assert.AreEqual(8000.kg(2) == m9, true);
        }
        [TestMethod]
        public void UnitLengthTest()
        {
            var l1 = 5.m() + 2.m();
            var l2 = 5.m() * 2.m();
            var l3 = 2.m() * 3;
            var l4 = 5.m() / 1.m();
            var l5 = 3.m(2) / 1.m();
            var l6 = 2.m() / 1.m(2);
            var l7 = 4.m() / 2;
            var l8 = 4.m() / 200.cm();
            var l9 = 4.m() * 2.km();
            Assert.AreEqual(7.m() == l1, true);
            Assert.AreEqual(10.m(2) == l2, true);
            Assert.AreEqual(6.m() == l3, true);
            Assert.AreEqual(5.m(0) == l4, true);
            Assert.AreEqual(3.m() == l5, true);
            Assert.AreEqual(2.m(-1) == l6, true);
            Assert.AreEqual(2.m() == l7, true);
            Assert.AreEqual(20.m(0) == l8, true);
            Assert.AreEqual(8000.m(2) == l9, true);
        }
    }
}