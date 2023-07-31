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
        internal static SpecialUnitMap specialUnitMap = SpecialUnitMap.Instance;
        public static DerivedUnit New(MetricLength l)
        {
            return new DerivedUnit(l, new MetricTime(1, 0, SiTimeUnits.second), new MetricMass(1, 0, SiMassUnits.kilogram));
        }
        public static DerivedUnit New(MetricTime t) 
        {
            return new DerivedUnit(new MetricLength(1, 0, SiMetricUnits.metre), t, new MetricMass(1, 0, SiMassUnits.kilogram));
        }
        public static DerivedUnit New(MetricMass m) 
        {
            return new DerivedUnit(new MetricLength(1, 0, SiMetricUnits.metre), new MetricTime(1, 0, SiTimeUnits.second), m);
        }
        public static DerivedUnit New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            DerivedDegree degree = new DerivedDegree(lengthUnit.Degree, timeUnit.Degree, massUnit.Degree);
            Func<MetricLength, MetricTime, MetricMass, DerivedUnit> specialUnitConstructor;
            if(specialUnitMap.GetSpecialUnitContructor(degree,out specialUnitConstructor))
            {
                return specialUnitConstructor(lengthUnit, timeUnit, massUnit);
            }
            return new DerivedUnit(lengthUnit, timeUnit, massUnit);
        }
        private protected DerivedUnit() : this(new MetricLength(1, 0, SiMetricUnits.metre), new MetricTime(1, 0, SiTimeUnits.second), new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        private protected DerivedUnit(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            l_unit = lengthUnit;
            t_unit = timeUnit;
            m_unit = massUnit;
            Degree = new DerivedDegree(l_unit.Degree, t_unit.Degree, m_unit.Degree);
        }

        public double Value { get { return l_unit.Value * t_unit.Value * m_unit.Value; } }
        public string Symbol { get; }
        public DerivedDegree Degree { get; private set; }

        static DerivedUnitArithmetics _arithmetics = DerivedUnitArithmetics.Instance;
        #region operators
        public static DerivedUnit operator *(DerivedUnit a, DerivedUnit b) => _arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(DerivedUnit a, MetricLength b) => _arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(DerivedUnit a, double b) => _arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(double a, DerivedUnit b) => _arithmetics.Multiply(b, a);
        public static DerivedUnit operator /(DerivedUnit a, DerivedUnit b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(DerivedUnit a, double b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(double a, DerivedUnit b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator +(DerivedUnit a, DerivedUnit b) => _arithmetics.Sum(a, b);
        public static DerivedUnit operator -(DerivedUnit a, DerivedUnit b) => _arithmetics.Subtract(a, b);
        public static bool operator ==(DerivedUnit a, DerivedUnit b) => _arithmetics.IsEqual(a, b);
        public static bool operator !=(DerivedUnit a, DerivedUnit b) => !_arithmetics.IsEqual(a, b);
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
            return (new Tuple<MetricLength, MetricTime, MetricMass>(l_unit, t_unit, m_unit)).GetHashCode();
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
        #endregion


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
            sb.Append(Value.ToString());
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
            return sb.ToString();
        }
        /// <summary>
        /// writes the value of the unit with unit symbol.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToString(string.Empty);
        }
    }
}
