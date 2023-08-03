using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Artihmetic
{
    internal class DerivedUnitArithmetics
    {
        static DerivedUnitArithmetics _instance;
        DerivedUnitArithmetics()
        {

        }
        internal static DerivedUnitArithmetics Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DerivedUnitArithmetics();
                }
                return _instance;
            }
        }
        internal DerivedUnit Multiply(DerivedUnit a, DerivedUnit b)
        {
            DerivedUnit newUnit = DerivedUnit.New(
                a.l_unit * b.l_unit,
                a.t_unit * b.t_unit,
                a.m_unit * b.m_unit
                );
            return newUnit;
        }

        internal DerivedUnit Multiply(DerivedUnit a, double b)
        {
            MetricLength newL = a.l_unit * b;
            MetricTime newT = a.t_unit;
            MetricMass newM = a.m_unit;
            return DerivedUnit.New(newL, newT, newM);
        }

        internal DerivedUnit Sum(DerivedUnit a, DerivedUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMetricUnits l_metric = b.l_unit.UnitOrder;
            SiTimeUnits t_metric = b.t_unit.UnitOrder;
            SiMassUnits m_metric = b.m_unit.UnitOrder;
            double value_a = a.GetValue(l_metric, t_metric, m_metric);
            double value_b = b.Value;
            double value = value_a + value_b;
            DerivedUnit newUnit = DerivedUnit.New(
                new MetricLength(value, a.Degree.l_degree, l_metric),
                new MetricTime(1, a.Degree.t_degree, t_metric),
                new MetricMass(1, a.Degree.m_degree, m_metric)
                );
            return newUnit;
        }
        internal DerivedUnit Subtract(DerivedUnit a, DerivedUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMetricUnits l_metric = b.l_unit.UnitOrder;
            SiTimeUnits t_metric = b.t_unit.UnitOrder;
            SiMassUnits m_metric = b.m_unit.UnitOrder;
            double value_a = a.GetValue(l_metric, t_metric, m_metric);
            double value_b = b.Value;
            double value = value_a - value_b;
            DerivedUnit newUnit = DerivedUnit.New(
                new MetricLength(value, a.Degree.l_degree, l_metric),
                new MetricTime(1, a.Degree.t_degree, t_metric),
                new MetricMass(1, a.Degree.m_degree, m_metric)
                );
            return newUnit;
        }
        internal DerivedUnit Divide(DerivedUnit a, DerivedUnit b)
        {
            DerivedUnit newUnit = DerivedUnit.New(
               a.l_unit / b.l_unit,
               a.t_unit / b.t_unit,
               a.m_unit / b.m_unit
               );
            return newUnit;
        }
        internal DerivedUnit Divide(DerivedUnit a, double b)
        {
            MetricLength newL = a.l_unit / b;
            MetricTime newT = a.t_unit;
            MetricMass newM = a.m_unit;
            return DerivedUnit.New(newL, newT, newM);
        }
        internal DerivedUnit Divide(double a, DerivedUnit b)
        {
            MetricLength newL = a / b.l_unit;
            MetricTime newT = 1 / b.t_unit;
            MetricMass newM = 1 / b.m_unit;
            return DerivedUnit.New(newL, newT, newM);
        }
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        internal bool IsLessThen(DerivedUnit a, DerivedUnit b)
        {
            bool isEqual = a.Degree == b.Degree;
            bool lessThen;
            if (isEqual)
            {
                SiMetricUnits l_metric = b.l_unit.UnitOrder;
                SiTimeUnits t_metric = b.t_unit.UnitOrder;
                SiMassUnits m_metric = b.m_unit.UnitOrder;
                double value_a = a.GetValue(l_metric, t_metric, m_metric);
                lessThen = value_a < b.Value;
            }
            else
            {
                throw new ArgumentException("Degrees of units are different.");
            }
            return lessThen;
        }
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        internal bool IsGreaterThen(DerivedUnit a, DerivedUnit b)
        {
            bool isEqual = a.Degree == b.Degree;
            bool greaterThen;
            if (isEqual)
            {
                SiMetricUnits l_metric = b.l_unit.UnitOrder;
                SiTimeUnits t_metric = b.t_unit.UnitOrder;
                SiMassUnits m_metric = b.m_unit.UnitOrder;
                double value_a = a.GetValue(l_metric, t_metric, m_metric);
                greaterThen = value_a > b.Value;
            }
            else
            {
                throw new ArgumentException("Degrees of units are different.");
            }
            return greaterThen;
        }
        internal bool IsEqual(DerivedUnit a, DerivedUnit b)
        {
            SiMetricUnits l_metric = b.l_unit.UnitOrder;
            SiTimeUnits t_metric = b.t_unit.UnitOrder;
            SiMassUnits m_metric = b.m_unit.UnitOrder;
            double value_a = a.GetValue(l_metric, t_metric, m_metric);
            if (UnitConfig.UnitPrecision == 0)
            {
                return value_a == b.Value;
            }
            else 
            {
                return Math.Abs(value_a - b.Value) < Math.Pow(10, -1 * UnitConfig.UnitPrecision);
            }
        }
    }
}
