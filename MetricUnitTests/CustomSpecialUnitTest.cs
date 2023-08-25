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
        /// <summary>
        /// This constructor is only for wrapping base class constructor.
        /// Values of each unit and the scaler value are multiplied and the result becomes the value of the initialized Customunit.
        /// </summary>
        CustomUnit(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, double scaler) : base(l_unit, t_unit, m_unit, scaler)
        {

        }
        /// <summary>
        /// This method is defined inside the base abstract class that is used for unit conversions.
        /// </summary>
        protected override CustomUnit New(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit)
        {
            return new CustomUnit(l_unit, t_unit, m_unit, 1);
        }
        /// <summary>
        /// This method is used as a delegate for registry of the CustomUnit.
        /// </summary>
        public static CustomUnit Instance(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit)
        {
            return new CustomUnit(l_unit, t_unit, m_unit, 1);
        }
    }
}
