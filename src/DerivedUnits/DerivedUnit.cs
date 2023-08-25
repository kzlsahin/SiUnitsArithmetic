using SIUnits.Artihmetic;
using SIUnits;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// Represents a derived unit type consists of more then one units such as m/s or kg/m3.
    /// </summary>
    public class DerivedUnit
    {
        
        internal readonly MetricLength l_unit;
        internal readonly MetricTime t_unit;
        internal readonly MetricMass m_unit;
        internal readonly Ampere a_unit;
        internal static SpecialUnitMap specialUnitMap = SpecialUnitMap.Instance;
        public static DerivedUnit New(MetricLength l)
        {
            return New(l, MetricTime.ScalerOne, MetricMass.ScalerOne, Ampere.ScalerOne);
        }
        public static DerivedUnit New(MetricLength l, MetricTime t)
        {
            return New(l, t, MetricMass.ScalerOne, Ampere.ScalerOne);
        }
        public static DerivedUnit New(MetricLength l, MetricMass m)
        {
            return New(l, MetricTime.ScalerOne, m, Ampere.ScalerOne);
        }
        public static DerivedUnit New(MetricTime t) 
        {
            return New(MetricLength.ScalerOne, t, MetricMass.ScalerOne, Ampere.ScalerOne);
        }
        public static DerivedUnit New(MetricTime t, MetricMass m)
        {
            return New(MetricLength.ScalerOne, t, m, Ampere.ScalerOne);
        }
        public static DerivedUnit New(MetricMass m)
        {
            return New(MetricLength.ScalerOne, MetricTime.ScalerOne, m, Ampere.ScalerOne);
        }
        public static DerivedUnit New(Ampere a)
        {
            return New(MetricLength.ScalerOne, MetricTime.ScalerOne, MetricMass.ScalerOne, a);
        }
        public static DerivedUnit New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            return New(lengthUnit, timeUnit, massUnit, Ampere.ScalerOne);
        }
        public static DerivedUnit New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit, Ampere ampereUnit)
        {
            DerivedDegree degree = new DerivedDegree(lengthUnit.Degree, timeUnit.Degree, massUnit.Degree, ampereUnit.Degree);
            Func<MetricLength, MetricTime, MetricMass, Ampere, DerivedUnit> specialUnitConstructor;
            if(specialUnitMap.GetSpecialUnitContructor(degree,out specialUnitConstructor))
            {
                return specialUnitConstructor(lengthUnit, timeUnit, massUnit, ampereUnit);
            }
            return new DerivedUnit(lengthUnit, timeUnit, massUnit, ampereUnit);
        }
        private protected DerivedUnit() : this(MetricLength.ScalerOne, MetricTime.ScalerOne, MetricMass.ScalerOne, Ampere.ScalerOne)
        {

        }
        private protected DerivedUnit(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit, Ampere ampereUnit)
        {
            l_unit = lengthUnit;
            t_unit = timeUnit;
            m_unit = massUnit;
            a_unit = ampereUnit;
            Degree = new DerivedDegree(l_unit.Degree, t_unit.Degree, m_unit.Degree, a_unit.Degree);
        }

        public double Value { get { return l_unit.Value * t_unit.Value * m_unit.Value; } }
        /// <summary>
        /// gets value in the specified metric units.
        /// </summary>
        /// <param name="l_metric"></param>
        /// <param name="t_metric"></param>
        /// <param name="m_metric"></param>
        /// <returns></returns>
        public double GetValue(SiMetricUnits l_metric, SiTimeUnits t_metric, SiMassUnits m_metric, SiAmpereUnits a_metric)
        {
            double lValue = l_unit.GetValueBy(l_metric);
            double tValue = t_unit.GetValueBy(t_metric);
            double mValue = m_unit.GetValueBy(m_metric);
            double aValue = a_unit.GetValueBy(a_metric);
            return lValue * tValue * mValue * aValue;
        }
        public string Symbol { get; }
        public DerivedDegree Degree { get; private set; }

        static DerivedUnitArithmetics _arithmetics = DerivedUnitArithmetics.Instance;
        #region operators
        public static DerivedUnit operator *(DerivedUnit a, DerivedUnit b) => _arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(DerivedUnit a, double b) => _arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(double a, DerivedUnit b) => _arithmetics.Multiply(b, a);
        public static DerivedUnit operator /(DerivedUnit a, DerivedUnit b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(DerivedUnit a, double b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(double a, DerivedUnit b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator +(DerivedUnit a, DerivedUnit b) => _arithmetics.Sum(a, b);
        public static DerivedUnit operator -(DerivedUnit a, DerivedUnit b) => _arithmetics.Subtract(a, b);
        public static bool operator ==(DerivedUnit a, DerivedUnit b) => _arithmetics.IsEqual(a, b);
        public static bool operator !=(DerivedUnit a, DerivedUnit b) => !_arithmetics.IsEqual(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <(DerivedUnit a, DerivedUnit b) => _arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >(DerivedUnit a, DerivedUnit b) => _arithmetics.IsGreaterThen(a, b);
        /// <summary>
        /// Checks if the value of a is not greater then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not greater then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <=(DerivedUnit a, DerivedUnit b) => !_arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is not less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not less then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >=(DerivedUnit a, DerivedUnit b) => !_arithmetics.IsGreaterThen(a, b);

        #endregion
        /// <summary>
        /// The DerivedUnit objects are immutable objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is DerivedUnit)
            {
                DerivedUnit unit = obj as DerivedUnit;
                return _arithmetics.IsEqual(this, unit);
            }
            return false;
        }
        /// <summary>
        /// HashCode of the DerivedUnit.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (new Tuple<MetricLength, MetricTime, MetricMass, Ampere>(l_unit, t_unit, m_unit, a_unit)).GetHashCode();
        }

        #region conversions

        public static implicit operator DerivedUnit(MetricLength l)
        {
            return DerivedUnit.New(l);
        }
        public static implicit operator DerivedUnit(MetricTime t)
        {
            return DerivedUnit.New(t);
        }
        public static implicit operator DerivedUnit(MetricMass m)
        {
            return DerivedUnit.New(m);
        }
        public static implicit operator DerivedUnit(Ampere a)
        {
            return DerivedUnit.New(a);
        }
        #endregion

        /// <summary>
        /// Returns new DerivedUnit in specified unit pattern.
        /// </summary>
        /// <param name="l_metric"></param>
        /// <param name="t_metric"></param>
        /// <param name="m_metric"></param>
        /// <returns></returns>
        public DerivedUnit ConvertTo(SiMetricUnits l_metric, SiTimeUnits t_metric, SiMassUnits m_metric, SiAmpereUnits a_metric)
        {
            DerivedUnit newUnit = DerivedUnit.New(l_unit.MetricLength(l_metric), t_unit.MetricTime(t_metric), m_unit.MetricMass(m_metric), a_unit.Ampere(a_metric));
            return newUnit;
        }
        /// <summary>
        /// Returns new DerivedUnit in specified unit pattern.
        /// </summary>
        /// <param name="l_metric"></param>
        /// <returns></returns>
        public DerivedUnit ConvertTo(SiMetricUnits l_metric)
        {
            DerivedUnit newUnit = DerivedUnit.New(l_unit.MetricLength(l_metric), t_unit, m_unit, a_unit);
            return newUnit;
        }
        /// <summary>
        /// Returns new DerivedUnit in specified unit pattern.
        /// </summary>
        /// <param name="t_metric"></param>
        /// <returns></returns>
        public DerivedUnit ConvertTo(SiTimeUnits t_metric)
        {
            DerivedUnit newUnit = DerivedUnit.New(l_unit, t_unit.MetricTime(t_metric), m_unit, a_unit);
            return newUnit;
        }
        /// <summary>
        /// Returns new DerivedUnit in specified unit pattern.
        /// </summary>
        /// <param name="m_metric"></param>
        /// <returns></returns>
        public DerivedUnit ConvertTo(SiMassUnits m_metric)
        {
            DerivedUnit newUnit = DerivedUnit.New(l_unit, t_unit, m_unit.MetricMass(m_metric), a_unit);
            return newUnit;
        }
        /// <summary>
        /// Returns new DerivedUnit in specified unit pattern.
        /// </summary>
        /// <param name="a_metric"></param>
        /// <returns></returns>
        public DerivedUnit ConvertTo(SiAmpereUnits a_metric)
        {
            DerivedUnit newUnit = DerivedUnit.New(l_unit, t_unit, m_unit, a_unit.Ampere(a_metric));
            return newUnit;
        }
        /// <summary>
        /// writes the value of the unit with unit symbol.
        /// </summary>
        /// <param name="formatter">If formatter is not string.Empty, then the value is formatted accordingly.</param>
        /// <returns></returns>
        public string ToString(string formatter)
        {
            StringBuilder sb = new StringBuilder();
            string value;
            if (formatter == string.Empty)
            {
                value = Value.ToString();
            }
            else
            {
                value = Value.ToString(formatter);
            }
            sb.Append(value);
            sb.Append(" ");
            bool preceded = false;
            if (l_unit.Degree > 0)
            {
                sb.Append($"{l_unit.UnitStr(true)}");
                preceded = true;
            }
            if (t_unit.Degree > 0)
            {
                if (preceded) sb.Append(".");
                sb.Append($"{t_unit.UnitStr(true)}");
                preceded = true;
            }
            if (m_unit.Degree > 0)
            {
                if (preceded) sb.Append(".");
                sb.Append($"{m_unit.UnitStr(true)}");
                preceded = true;
            }
            if (a_unit.Degree > 0)
            {
                if (preceded) sb.Append(".");
                sb.Append($"{a_unit.UnitStr(true)}");
                preceded = true;
            }
            bool subproceded = false;
            if (l_unit.Degree < 0)
            {
                if (!subproceded)
                {
                    if (preceded) { sb.Append("/"); } else { sb.Append("1/"); }
                }
                sb.Append($"{(l_unit.UnitStr(true))}");
                subproceded = true;
                preceded = true;
            }
            if (t_unit.Degree < 0)
            {
                if (!subproceded)
                {
                    if (preceded) { sb.Append("/"); } else { sb.Append("1/"); }
                }
                if (subproceded) sb.Append(".");
                sb.Append($"{(t_unit.UnitStr(true))}");
                subproceded = true;
                preceded = true;
            }
            if (m_unit.Degree < 0)
            {
                if (!subproceded)
                {
                    if (preceded) { sb.Append("/"); } else { sb.Append("1/"); }
                }
                if (subproceded) sb.Append(".");
                sb.Append($"{(m_unit.UnitStr(true))}");
                subproceded = true;
                preceded = true;
            }
            if (a_unit.Degree < 0)
            {
                if (!subproceded)
                {
                    if (preceded) { sb.Append("/"); } else { sb.Append("1/"); }
                }
                if (subproceded) sb.Append(".");
                sb.Append($"{(a_unit.UnitStr(true))}");
                subproceded = true;
                preceded = true;
            }
            return sb.ToString();
        }
        /// <summary>
        /// writes the value of the unit with unit symbol.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (UnitConfig.UnitPrecision == 0)
            {
                return ToString(string.Empty);
            }
            string formatter = $"F{UnitConfig.UnitPrecision}";
            return ToString(formatter);
        }
    }
}
