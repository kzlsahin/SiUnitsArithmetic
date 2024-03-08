using SIUnits.Artihmetic;
using SIUnits;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using SIUnits.DerivedUnits;

namespace SIUnits
{
    /// <summary>
    /// Represents a derived unit type consists of more then one units such as m/s or kg/m3.
    /// </summary>
    public class DerivedUnit
    {
        /// <summary>
        /// units this composite unit is composed of
        /// </summary>
        public Dictionary<Guid, IBasicUnit> MemberUnits { get; private set; }

        internal static SpecialUnitMap specialUnitMap = SpecialUnitMap.Instance;
        /// <summary>
        /// Creates new ınstane
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public static DerivedUnit New(params IBasicUnit[] units)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            for (int i = 0; i < units.Length; ++i)
            {
                memberUnits.Add(units[i].Id, units[i]);
            }
            DerivedDegree degree = new DerivedDegree(memberUnits);
            Func<Dictionary<Guid, IBasicUnit>, DerivedUnit> specialUnitConstructor;
            if (specialUnitMap.GetSpecialUnitContructor(degree, out specialUnitConstructor))
            {
                return specialUnitConstructor(memberUnits);
            }
            return new DerivedUnit(memberUnits);
        }
        /// <summary>
        /// Creates new ınstane
        /// </summary>
        /// <param name="memberUnits"></param>
        /// <returns></returns>
        public static DerivedUnit New(Dictionary<Guid, IBasicUnit> memberUnits)
        {
            return new DerivedUnit(memberUnits);
        }
        private protected DerivedUnit() : this(MetricLength.ScalerOne, MetricTime.ScalerOne, MetricMass.ScalerOne, Ampere.ScalerOne)
        {

        }
        private protected DerivedUnit(params IBasicUnit[] units)
        {
            MemberUnits = new Dictionary<Guid, IBasicUnit>();
            for (int i = 0; i < units.Length; ++i)
            {
                MemberUnits.Add(units[i].Id, units[i]);
            }
            Degree = new DerivedDegree(MemberUnits);
        }
        private protected DerivedUnit(Dictionary<Guid, IBasicUnit> memberUnits)
        {
            MemberUnits = memberUnits;
            Degree = new DerivedDegree(memberUnits);
        }

        public double Value
        {
            get
            {
                double res = 1;
                foreach (var unit in MemberUnits.Values)
                {
                    res *= unit.Value;
                }
                return res;
            }
        }
        /// <summary>
        /// gets value in the specified metric units.
        /// </summary>
        /// <param name="l_metric"></param>
        /// <param name="t_metric"></param>
        /// <param name="m_metric"></param>
        /// <returns></returns>
        public double GetValueByRef(DerivedUnit other)
        {
            double res = 1;
            foreach (var unitPair in other.MemberUnits)
            {
                var id = unitPair.Key;
                if (MemberUnits.TryGetValue(id, out var unit))
                {
                    double value = unit.GetValueBy(unitPair.Value.UnitOrder);
                    res *= unit.Value;
                }
                else
                {
                    throw new ArgumentException("Referenced DerivedUnit is not identical to the DerivedUnit");
                }
            }
            return res;
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
            return this.GetHashCode();
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
        /// <returns></returns>
        public DerivedUnit ConvertTo(params UnitScalePair[] unitScales)
        {
            var scales = new Dictionary<Guid, UnitScalePair>();
            for (int i = 0; i < unitScales.Length; ++i)
            {
                var id = unitScales[i].UnitId;
                scales.Add(id, unitScales[i]);
            }

            return ConvertTo(scales);
        }
        /// <summary>
        /// Returns new DerivedUnit in specified unit pattern.
        /// </summary>
        /// <returns></returns>
        public DerivedUnit ConvertTo(Dictionary<Guid, UnitScalePair> unitScales)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            foreach (var member in MemberUnits)
            {
                var id = member.Key;
                var unit = member.Value;
                if (unitScales.TryGetValue(id, out UnitScalePair scale))
                {
                    int scaleUnit = scale.ScaleUnit;
                    memberUnits.Add(id, unit.NewInstance(unit.GetValueBy(scaleUnit), unit.Degree, scaleUnit));
                }
                memberUnits.Add(id, unit.NewInstance(unit.Value, unit.Degree, unit.UnitOrder));
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
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

            foreach(var unit in MemberUnits.Values)
            {
                if (unit.Degree > 0)
                {
                    if (preceded) sb.Append(".");
                    sb.Append($"{unit.UnitStr(true)}");
                    preceded = true;
                }
            }
            bool subproceded = false;
            foreach (var unit in MemberUnits.Values)
            {
                if (!subproceded)
                {
                    if (preceded) { sb.Append("/"); } else { sb.Append("1/"); }
                }
                sb.Append($"{(unit.UnitStr(true))}");
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
