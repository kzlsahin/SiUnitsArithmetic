using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricUnitTests
{
    [TestClass]
    public class CustomSpecialUnitTests
    {
        [TestMethod]
        public void CreateCustomSpecialUnit()
        {
            CustomUnit.RegisterSpecialUnit(new DerivedDegree(2, -2, 2,0), CustomUnit.Instance);
            var customUnit = DerivedUnit.New(2.m(2), 3.second(-2), 3.kg(2));
            Assert.IsTrue(customUnit is CustomUnit);
            var custom2 = (400.mm(2) / 9.minute(2)) * 100.g(2);
            Assert.IsTrue(custom2 is CustomUnit);
        }
    }

    class CustomUnit : CustomSpecialUnit<CustomUnit>
    {
        public new string Symbol { get; } = "custom";
        CustomUnit(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, double scaler) : base(l_unit, t_unit, m_unit, scaler)
        {

        }

        protected override CustomUnit New(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit)
        {
            return new CustomUnit(l_unit, t_unit, m_unit, 1);
        }
        public static CustomUnit Instance(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit)
        {
            return new CustomUnit(l_unit, t_unit, m_unit, 1);
        }
    }
}
