﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void MultiplyDerivedUnits()
        {
            var der1 = 1.m() / 1.second(2);
            Assert.AreEqual(DerivedUnit.New(1.m(), 1.second(-2), 1.kg(0)), der1);
        }
        [TestMethod]
        public void EqualityDerivedUnits()
        {
            UnitConfig.UnitPrecision = 4;
            var der1 = 1.m() / 1.second(2);
            var der2 = 1.m() / 1.second(2);
            Assert.AreEqual(der1 == der2, true);

            der2 = 1000.mm() / 1.second(2);
            Assert.AreEqual(der1 == der2, true);

            der1 = 10.m() * 1.kg() / 1.second(2);
            der2 = 0.01.km() * 1000.g() / 1.second(2);
            Assert.AreEqual(der1 == der2, true);

           
        }
        [TestMethod]
        public void SpecialUnitTests()
        {
            UnitConfig.UnitPrecision = 4;

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
    }
}
