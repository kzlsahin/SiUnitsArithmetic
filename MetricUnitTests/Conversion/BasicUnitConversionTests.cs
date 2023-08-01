using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricUnitTests.Conversion
{
    [TestClass]
    public class BasicUnitConversionTests
    {
        [TestMethod]
        public void TestLengthUnit()
        {
            UnitConfig.UnitPrecision = 6;

            var l1 = 1.m(2);
            var l2 = 100.dm(2);
            Assert.IsTrue(l1 == l2);

            l1 = 10.mm(2);
            l2 = 0.1.cm(2);
            Assert.IsTrue(l1 == l2);

            l1 = 1000.cm(2);
            l2 = 0.1.m(2);
            Assert.IsTrue(l1 == l2);

            l1 = 1.m(3);
            l2 = 1000.dm(3);
            Assert.IsTrue(l1 == l2);
        }
        [TestMethod]
        public void TestTimeUnit()
        {
            UnitConfig.UnitPrecision = 6;

            var l1 = 3600.second(2);
            var l2 = 1.minute(2);
            Assert.IsTrue(l1 == l2);

            l1 = 3600.minute(2);
            l2 = 1.hour(2);
            Assert.IsTrue(l1 == l2);

            l1 = 1.second(2);
            l2 = 1000000.milisecond(2);
            Assert.IsTrue(l1 == l2);

            l1 = 216000.second(3);
            l2 = 1.minute(3);
            Assert.IsTrue(l1 == l2);
        }
        [TestMethod]
        public void TestMasshUnit()
        {
            UnitConfig.UnitPrecision = 6;

            var l1 = 1.g(2);
            var l2 = 1000000.mg(2);
            Assert.IsTrue(l1 == l2);

            l1 = 100.mg(2);
            l2 = 0.0001.g(2);
            Assert.IsTrue(l1 == l2);

            l1 = 1000.g(2);
            l2 = 0.001.kg(2);
            Assert.IsTrue(l1 == l2);

            l1 = 1.kg(3);
            l2 = 1000000.MetricMass(SiMassUnits.decagram, degree:3);
            Assert.IsTrue(l1 == l2);
        }
    }
}
