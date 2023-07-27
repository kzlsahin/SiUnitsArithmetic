using SIUnits.Artihmetic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SIUnits.Time;

namespace SIUnits
{
    public class MetricTime : Metric<SiTimeUnits>
    {
        public MetricTime(double value, int degree,SiTimeUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public Metric<SiTimeUnits> NewInstance(double value, int degree, SiTimeUnits unit)
        {
            return new MetricTime(value, degree, unit);
        }
        /// <summary>
        /// Value of this MetricTime in units of this MetricTime.
        /// </summary>
        public double Value { get;}
        /// <summary>
        /// power of this MetricTime (if it is 2 and unit is minute, then it means min^2).
        /// </summary>
        public int Degree{ get; }
        /// <summary>
        /// unit of this MetricTime.
        /// </summary>
        public SiTimeUnits Unit { get;}
        public string Symbol { get { return this.GetSymbol(); } }
        readonly static ArithmeticOperations<MetricTime, SiTimeUnits> _artihmetics = ArithmeticOperations<MetricTime, SiTimeUnits>.Instance;

        #region operators
        public static MetricTime operator *(MetricTime a, MetricTime b) => _artihmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricTime a, MetricLength b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricTime a, MetricMass b) => a.ToCompositeUnit() * b;
        public static MetricTime operator *(MetricTime a, double b) => _artihmetics.Multiply(b, a);
        public static MetricTime operator *(double a, MetricTime b) => _artihmetics.Multiply(a, b);
        public static MetricTime operator /(MetricTime a, MetricTime b) => _artihmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricTime a, MetricLength b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricTime a, MetricMass b) => a.ToCompositeUnit() / b;
        public static MetricTime operator /(MetricTime a, double b) => _artihmetics.Divide(a, b);
        public static MetricTime operator /(double a, MetricTime b) => _artihmetics.Divide(a, b);
        public static MetricTime operator +(MetricTime a, MetricTime b) => _artihmetics.Sum(a, b);
        public static MetricTime operator -(MetricTime a, MetricTime b) => _artihmetics.Subtract(a, b);
        public static bool operator ==(MetricTime a, MetricTime b) => _artihmetics.IsEqual(a, b);
        public static bool operator !=(MetricTime a, MetricTime b) => !_artihmetics.IsEqual(a, b);
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is MetricTime)
            {
                return _artihmetics.IsEqual(this, (MetricTime)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {

            return (new Tuple<int, int, double>((int)this.Unit*10 +2, this.Degree, this.Value)).GetHashCode();
        }
        /// <summary>
        /// returns unit symbol (for ex. m or 1/m).
        /// </summary>
        /// <param name="asPositiveExponent">If true, then this method returns only unit symbol without considering degree of the unit (or exponent)</param>
        /// <returns></returns>
        public string UnitStr(bool asPositiveExponent = false)
        {
            if (Degree > 0)
            {
                return $"{Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            if (asPositiveExponent)
            {
                return $"{Symbol}{(Degree == -1 ? "" : (-1 * Degree).ToSupStr())}";
            }
            else
            {
                return $"1/{Symbol}{(-1 * Degree).ToSupStr()}";

            }
        }
        /// <summary>
        /// writes the value of the unit with unit symbol.
        /// </summary>
        /// <param name="formatter">If formatter is not string.Empty, then the value is formatted accordingly.</param>
        /// <returns></returns>
        public string ToString(string formatter)
        {
            string value;
            if (formatter == string.Empty)
            {
                value = Value.ToString();
            }
            else
            {
                value = Value.ToString(formatter);
            }
             
            if (Degree == 0)
            {
                return value;
            }
            if (Degree > 0)
            {
                return $"{value} {Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            else
            {
                return $"{value} 1/{Symbol}{(-1 * Degree).ToSupStr()}";
            }
        }
        /// <summary>
        /// writes the value of the unit with unit symbol.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(UnitConfig.UnitPrecision == 0)
            {
                return ToString(string.Empty);
            }
            string formatter = $"F{UnitConfig.UnitPrecision}";
            return ToString(formatter);
        }
        public double GetValueBy(SiTimeUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
    }
}
