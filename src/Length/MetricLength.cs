using SIUnits.Artihmetic;
using SIUnits.Length;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace SIUnits
{
    public class MetricLength : Metric<SiMetricUnits>
    {
        public MetricLength(double value, int degree, SiMetricUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        internal MetricLength() : this(0, 1, SiMetricUnits.metre)
        {

        }
        /// <summary>
        /// Value of this MetricLength in units of this MetricLength.
        /// </summary>
        public double Value { get; }
        /// <summary>
        /// power of this MetricLength (if it is 2 and unit is metre, then it means m^2).
        /// </summary>
        public int Degree { get; }
        public string Symbol { get { return this.GetSymbol(); } }
        /// <summary>
        /// unit of this MetricLength.
        /// </summary>
        public SiMetricUnits Unit { get; }

        readonly static ArithmeticOperations<MetricLength, SiMetricUnits> _artihmetics = ArithmeticOperations<MetricLength, SiMetricUnits>.Instance;
        #region operators
        public static MetricLength operator *(MetricLength a, MetricLength b) => _artihmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricLength a, MetricTime b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricLength a, MetricMass b) => a.ToCompositeUnit() * b;
        public static MetricLength operator *(MetricLength a, double b) => _artihmetics.Multiply(b, a);
        public static MetricLength operator *(double a, MetricLength b) => _artihmetics.Multiply(a, b);
        public static MetricLength operator /(MetricLength a, MetricLength b) => _artihmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricLength a, MetricTime b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricLength a, MetricMass b) => a.ToCompositeUnit() / b;
        public static MetricLength operator /(MetricLength a, double b) => _artihmetics.Divide(a, b);
        public static MetricLength operator /(double a, MetricLength b) => _artihmetics.Divide(a, b);
        public static MetricLength operator +(MetricLength a, MetricLength b) => _artihmetics.Sum(a, b);
        public static MetricLength operator -(MetricLength a, MetricLength b) => _artihmetics.Subtract(a, b);
        public static bool operator ==(MetricLength a, MetricLength b) => _artihmetics.Equal(a, b);
        public static bool operator !=(MetricLength a, MetricLength b) => !_artihmetics.Equal(a, b);
        #endregion
        public override bool Equals(object obj)
        {
            if(obj is MetricLength)
            {
                return _artihmetics.Equal(this, (MetricLength)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {            
            return (new Tuple<int,int,double>((int)this.Unit * 10, this.Degree, this.Value)).GetHashCode();
        }

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
        public override string ToString()
        {
            if (UnitConfig.UnitPrecision == 0)
            {
                return ToString(string.Empty);
            }
            string formatter = $"F{UnitConfig.UnitPrecision}";
            return ToString(formatter);
        }

        public Metric<SiMetricUnits> NewInstance(double value, int degree, SiMetricUnits unit)
        {
            return new MetricLength(value, degree, unit);
        }

        public double GetValueBy(SiMetricUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
    }
}
