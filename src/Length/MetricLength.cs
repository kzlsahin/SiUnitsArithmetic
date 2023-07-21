using SIUnits.Artihmetic;
using System;
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
        public double Value { get; }
        public int Degree { get; }
        public string Symbol { get { return this.GetSymbol(); } }
        public SiMetricUnits Unit { get; }

        private static ArithmeticOperations<MetricLength, SiMetricUnits> _artihmetics = ArithmeticOperations<MetricLength, SiMetricUnits>.Instance;
        #region operators
        public static MetricLength operator *(MetricLength a, MetricLength b) => _artihmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricLength a, MetricTime b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricLength a, MetricMass b) => a.ToCompositeUnit() * b;
        public static MetricLength operator *(MetricLength a, double b) => _artihmetics.Multiply(b, a);
        public static MetricLength operator *(double a, MetricLength b) => MetricLength.Multiply(a, b);
        public static MetricLength operator /(MetricLength a, MetricLength b) => MetricLength.Divide(a, b);
        public static DerivedUnit operator /(MetricLength a, MetricTime b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricLength a, MetricMass b) => a.ToCompositeUnit() / b;
        public static MetricLength operator /(MetricLength a, double b) => MetricLength.Divide(a, b);
        public static MetricLength operator /(double a, MetricLength b) => MetricLength.Divide(a, b);
        public static MetricLength operator +(MetricLength a, MetricLength b) => MetricLength.Sum(a, b);
        public static MetricLength operator -(MetricLength a, MetricLength b) => MetricLength.Subtract(a, b);
        #endregion

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
        public override string ToString()
        {
            if (Degree == 0)
            {
                return $"{Value}";
            }
            if (Degree > 0)
            {
                return $"{Value} {Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            else
            {
                return $"{Value} 1/{Symbol}{(-1 * Degree).ToSupStr()}";
            }
        }

        public Metric<SiMetricUnits> NewInstance(double value, int degree, SiMetricUnits unit)
        {
            return new MetricLength(value, degree, unit);
        }
    }
}
