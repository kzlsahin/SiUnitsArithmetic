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
        public double Value { get;}
        public int Degree{ get; }
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
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is MetricTime)
            {
                return _artihmetics.Equal(this, (MetricTime)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {

            return HashCode.Combine(this.Unit, this.Degree, this.Value);
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
        public override string ToString()
        {
            if(Degree == 0)
            {
                return $"{Value}";
            }
            if (Degree > 0)
            {
                return $"{Value} {Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            else
            {
                return $"{Value} 1/{Symbol}{(-1*Degree).ToSupStr()}";
            }
        }
        public double GetValueBy(SiTimeUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
    }
}
