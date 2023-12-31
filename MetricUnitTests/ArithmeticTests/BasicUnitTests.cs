﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class BasicunitTests
    {
        [TestMethod]
        public void UnitAmpereTest()
        {
            UnitConfig.UnitPrecision = 4;
            var a1 = 1.A();
            var a2 = 3.A();
            Assert.IsTrue(a1 + a2 == 4.Ampere(SiAmpereUnits.ampere, 1));
            Assert.IsTrue(a1 - a2 == (-2).Ampere(SiAmpereUnits.ampere, 1));
            Assert.IsTrue(4*a1 - a2 == 1.Ampere(SiAmpereUnits.ampere, 1));
            Assert.IsTrue((a2 + 0.A()) == 3.Ampere(SiAmpereUnits.ampere, 1));
            Assert.IsTrue((a1 + a2 / 3) == 2.Ampere(SiAmpereUnits.ampere, 1));

            var a3 = 2.mA();
            var a4 = 15.cA();
            Assert.IsTrue(a3 * a4 == 3.cA(2));

            a3 = 2.dA();
            a4 = 25.cA();
            Assert.IsTrue(a3 * a4 == 0.05.A(2));
        }
            [TestMethod]
        public void UnitMassTest()
        {
            UnitConfig.UnitPrecision = 4;
            var m1 = 5.kg() + 2.kg();
            var m2 = 5.kg() * 2.kg();
            var m3 = 2.kg() * 3;
            var m4 = 5.kg() / 1.kg();
            var m5 = 3.kg(2) / 1.kg();
            var m6 = 2.kg() / 1.kg(2);
            var m7 = 4.kg() / 2;
            var m8 = 4.kg() / 200.g();
            var m9 = 4.kg() * 2.tonne();
            var m10 = (4.kg() * 2.kg()).g();
            var m11 = (4.kg() * 20000.g()).tonne();
            var m12 = 1.kg() * 1.g();
            var m13 = 1.kg(2).g();
            Assert.AreEqual(7.kg(), m1);
            Assert.AreEqual(10.kg(2), m2);
            Assert.AreEqual(6.kg(), m3);
            Assert.AreEqual(5.kg(0), m4);
            Assert.AreEqual(3.kg(), m5);
            Assert.AreEqual(2.kg(-1), m6);
            Assert.AreEqual(2.kg(), m7);
            Assert.AreEqual(20.kg(0), m8);
            Assert.AreEqual(8000.kg(2), m9);
            Assert.AreEqual(8.kg(2), m10);
            Assert.AreEqual(8000000.g(2), m10);
            Assert.AreEqual(80.kg(2), m11);
            Assert.AreEqual(0.001.kg(2), m12);
            Assert.AreEqual(1000000.g(2), m13);

            Assert.AreEqual(1.kg()==1000.g(), true);
            Assert.AreEqual(1.mg()==0.001.g(), true);
        }
        [TestMethod]
        public void UnitLengthTest()
        {
            UnitConfig.UnitPrecision = 4;
            var l1 = 5.m() + 2.m();
            var l2 = 5.m() * 2.m();
            var l3 = 2.m() * 3;
            var l4 = 5.m() / 1.m();
            var l5 = 3.m(2) / 1.m();
            var l6 = 2.m() / 1.m(2);
            var l7 = 4.m() / 2;
            var l8 = 4.m() / 200.mm();
            var l9 = 4.m() * 2.km();
            var l10 = (4.cm() * 20.mm()).cm();
            var l11 = (4.m() * 20000.mm()).km();
            var l12 = 1.m() * 1.mm();
            var l13 = 1.m(2).mm();
            Assert.AreEqual(7.m(), l1);
            Assert.AreEqual(10.m(2), l2);
            Assert.AreEqual(6.m(), l3);
            Assert.AreEqual(5.m(0), l4);
            Assert.AreEqual(3.m(), l5);
            Assert.AreEqual(2.m(-1), l6);
            Assert.AreEqual(2.m(), l7);
            Assert.AreEqual(20.m(0), l8);
            Assert.AreEqual(8000.m(2), l9);
            Assert.AreEqual(true, 800.mm(2) == l10);
            Assert.AreEqual(80.m(2), l11);
            Assert.AreEqual(0.001.m(2), l12);
            Assert.AreEqual(1000000.mm(2), l13);

            Assert.AreEqual(1.m() == 1000.mm(), true);
            Assert.AreEqual(1.cm() == 0.1.dm(), true);
        }
        [TestMethod]
        public void UnitTimeTest()
        {
            UnitConfig.UnitPrecision = 4;

            Assert.AreEqual(60.minute(), 1.hour());
            Assert.AreEqual(3600.minute(2), 1.hour(2));
            Assert.AreEqual(3600.second(), 1.hour());
            Assert.AreEqual(3600.minute(2), 1.hour() * 60.minute());
            Assert.AreEqual(1.hour(0), 1.hour() / 1.hour());
        }

        [TestMethod]
        public void CollectionLengthTest()
        {
            HashSet<MetricLength> set = new();
            List<MetricLength> lengths = new();
            lengths.Add(1.m());
            lengths.Add(40.mm());
            lengths.Add(5.cm());
            lengths.Add(8.dm());
            lengths.Add(0.01.km());
            lengths.Add(1.m());
            lengths.Add(40.mm());
            lengths.Add(5.cm());
            lengths.Add(9.mm(2));
            lengths.Add(9.mm(2));
            List<bool> expecteds = new()
            {
                true,
                true,
                true,
                true,
                true,
                false,
                false,
                false,
                true,
                false
            };
            for (int i = 0; i < lengths.Count; i++)
            {
                Assert.AreEqual(expecteds[i], set.Add(lengths[i]));
            }
        }
        [TestMethod]
        public void CollectionMassTest()
        {
            HashSet<MetricMass> set = new();
            List<MetricMass> lengths = new();
            lengths.Add(1.kg());
            lengths.Add(40.g());
            lengths.Add(5.MetricMass(SiMassUnits.centigram, 1));
            lengths.Add(8.MetricMass(SiMassUnits.decigram, 1));
            lengths.Add(0.01.t());
            lengths.Add(1.kg());
            lengths.Add(40.g());
            lengths.Add(5.MetricMass(SiMassUnits.centigram, 1));
            lengths.Add(9.g(2));
            lengths.Add(9.g(2));
            List<bool> expecteds = new()
            {
                true,
                true,
                true,
                true,
                true,
                false,
                false,
                false,
                true,
                false
            };
            for (int i = 0; i < lengths.Count; i++)
            {
                Assert.AreEqual(expecteds[i], set.Add(lengths[i]));
            }
        }

        [TestMethod]
        public void Compare()
        {
            Assert.IsTrue(1.second() < 1.minute());
            Assert.IsTrue(1.minute() < 1.hour());
            Assert.IsTrue(1.milisecond() < 1.second());
            Assert.IsTrue(2.minute() > 1.minute());
            Assert.IsTrue(1.hour() > 1.minute());
            Assert.IsTrue(0.5.second() > 0.0001.minute());

            Assert.IsTrue(1.m() < 1.km());
            Assert.IsTrue(1.mm() < 1.cm());
            Assert.IsTrue(1.dm() < 1.m());
            Assert.IsTrue(2.cm() > 1.cm());
            Assert.IsTrue(1.m() > 1.dm());
            Assert.IsTrue(0.5.mm() > 0.0001.m());

            Assert.IsTrue(1.g() < 1.kg());
            Assert.IsTrue(1.mg() < 1.g());
            Assert.IsTrue(1.kg() < 1.tonne());
            Assert.IsTrue(2.kg() > 1.kg());
            Assert.IsTrue(1001.g() > 1.g());
            Assert.IsTrue(0.5.kg() > 0.0001.tonne());

            Assert.IsTrue(1.kg() <= 1.kg());
            Assert.IsTrue(1.m() >= 1.m());
            Assert.IsTrue(1.second() <= 1.second());

        }

    }
}