using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIUnits;

namespace MetricUnitTests.ArithmeticTests
{
    [TestClass]
    public class DerivedUnitTests
    {
        [TestMethod]
        public void MultiplyDivideDerivedUnits()
        {
            UnitConfig.UnitPrecision = 6;
            var der1 = 1.m() / 1.second(2);
            Assert.AreEqual(DerivedUnit.New(1.m(), 1.second(-2), 1.kg(0)), der1);

            der1 = (2.5.second() * 100.mm()) / 1.second();
            Assert.IsTrue(der1 == 25.cm());

            der1 = 2.5.second() * (100.mm() / 1.second());
            Assert.IsTrue(der1 == 25.cm());

            der1 = 4 * 1.m() / 1.second();
            Assert.IsTrue(der1 == 4.m() / 1.second());

            der1 = 0.5 * 1.m() / 1.second();
            Assert.IsTrue(der1 == 1.8.km() / 1.hour());

            der1 = (0.001 * 5.kg()) / 1.m(3);
            Assert.IsTrue(der1 == 5.g() / 1.m(3));

            der1 = 0.001 * (5.kg() / 1.m(3));
            Assert.IsTrue(der1 == 5.g() / 1.m(3));

            der1 = 10.second() * (2.5.m() / 1.second(2));
            Assert.IsTrue(der1 == 25.m() / 1.second());

            der1 = (10.second() * (2.5.m()) / 1.second(2));
            Assert.IsTrue(der1 == 25.m() / 1.second());
        }
        [TestMethod]
        public void SumDerivedUnits()
        {
            UnitConfig.UnitPrecision = 6;
            var der1 = 1.m() / 1.second(2);
            var der2 = 3600.m() / 1.minute(2);
            Assert.IsTrue(der1 + der2 == DerivedUnit.New(2.m(), 1.second(-1)));

            der1 = 2.kg() * 1.m();
            der2 = 300.g() * 100.cm();
            Assert.IsTrue(der1 + der2 == DerivedUnit.New(1.m(), 2.3.kg()));

            der1 = 2.kg() * 1.m(2);
            der2 = 300.g() * 1000.cm(2);
            Assert.IsTrue(der1 + der2 == DerivedUnit.New(1.m(2), 2.03.kg()));
        }
        [TestMethod]
        public void SubtracktDerivedUnits()
        {
            UnitConfig.UnitPrecision = 6;
            var der1 = 1.m() / 1.second(2);
            var der2 = 3600.m() / 1.minute(2);
            Assert.IsTrue(der1 - der2 == DerivedUnit.New(0.m(), 1.second(-1)));

            der1 = 2.kg() * 1.m();
            der2 = 300.g() * 100.cm();
            Assert.IsTrue(der1 - der2 == DerivedUnit.New(1.m(), 1.7.kg()));

            der1 = 2.kg() * 1.m(2);
            der2 = 300.g() * 1000.cm(2);
            Assert.IsTrue(der1 - der2 == DerivedUnit.New(1.m(2), 1.97.kg()));
        }
        [TestMethod]
        public void EqualityDerivedUnits()
        {
            UnitConfig.UnitPrecision = 6;
            var der1 = 1.m() / 1.second(2);
            var der2 = 1.m() / 1.second(2);
            Assert.IsTrue(der1 == der2);

            der2 = 1000.mm() / 1.second(2);
            Assert.IsTrue(der1 == der2);

            der1 = 10.m() * 1.kg() / 1.second(2);
            der2 = 0.01.km() * 1000.g() / 1.second(2);
            Assert.IsTrue(der1 == der2);

            der1 = (100.mm() * 1.kg()) / 3600.second(2);
            der2 = (0.0001.km() * 1000000.mg()) / 1.minute(2);
            var der3 = ((0.0001.km() * 1000000.mg()) / 1.hour(2))*3600;
            Assert.IsTrue(der1 == der2);
            Assert.IsTrue(der2 == der3);
        }
        [TestMethod]
        public void SpecialUnitTests()
        {
            UnitConfig.UnitPrecision = 6;

            Newton f1 = (Newton)((1.kg() * 1.m()) / 1.second(2));
            Assert.IsTrue(f1 is Newton);

            var speed = 2.km() / 1.hour();
            var acc = speed / 1.hour();
            var f2 = acc * 80.kg();
            var e1 = f2 * 500.mm();
            Joule e2 = (Joule)(f1 * 10.m());
            Assert.IsTrue(e1 is Joule);
            Assert.IsTrue(f2 is Newton);
            Assert.IsTrue(e2 is Joule);

        }

        [TestMethod]
        public void CompareDerivedUnits()
        {
            Assert.IsTrue(1.m() / 1.second() < 2.m() / 1.second());
            Assert.IsTrue(1.kg() / 1.m(3) < 2001.g() / 1.m(3));
            Assert.IsTrue(1.kg() / 1.m(3) > 999.g() / 1.m(3));
            Assert.IsTrue(1.kg() / 1.m(3) >= 1000.g() / 1.m(3));
            Assert.IsTrue(1.kg() / 1.m(3) <= 1000.g() / 1.m(3));
        }
    }
}
