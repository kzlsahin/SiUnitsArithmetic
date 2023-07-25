using SIUnits.Artihmetic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public class MetricMass : Metric<SiMassUnits>
    {
        public MetricMass(double value, int degree,SiMassUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public double Value { get;}
        public int Degree{ get; }
        public SiMassUnits Unit { get;}
        public string Symbol { get { return this.GetSymbol(); } }
        readonly static ArithmeticOperations<MetricMass, SiMassUnits> _artihmetics = ArithmeticOperations<MetricMass, SiMassUnits>.Instance;
        public Metric<SiMassUnits> NewInstance(double value, int degree, SiMassUnits unit)
        {
            return new MetricMass(value, degree, unit);
        }
        #region operators
        public static MetricMass operator *(MetricMass a, MetricMass b) => _artihmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricMass a, MetricLength b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricMass a, MetricTime b) => a.ToCompositeUnit() * b;
        public static MetricMass operator *(MetricMass a, double b) => _artihmetics.Multiply(b, a);
        public static MetricMass operator *(double a, MetricMass b) => _artihmetics.Multiply(a, b);
        public static MetricMass operator /(MetricMass a, MetricMass b) => _artihmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricMass a, MetricLength b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricMass a, MetricTime b) => a.ToCompositeUnit() / b;
        public static MetricMass operator /(MetricMass a, double b) => _artihmetics.Divide(a, b);
        public static MetricMass operator /(double a, MetricMass b) => _artihmetics.Divide(a, b);
        public static MetricMass operator +(MetricMass a, MetricMass b) => _artihmetics.Sum(a, b);
        public static MetricMass operator -(MetricMass a, MetricMass b) => _artihmetics.Subtract(a, b);
        public static bool operator ==(MetricMass a, MetricMass b) => _artihmetics.Equal(a, b);
        public static bool operator !=(MetricMass a, MetricMass b) => !_artihmetics.Equal(a, b);
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is MetricMass)
            {
                return _artihmetics.Equal(this, (MetricMass)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (new Tuple<int, int, double>((int)this.Unit*10 +1, this.Degree, this.Value)).GetHashCode();
        }

        public string UnitStr(bool asPositiveExponent = false)
        {
            if (Degree > 0)
            {
                return $"{Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            if (asPositiveExponent)
            {
                return $"{Symbol}{(Degree == -1 ? "" : (-1*Degree).ToSupStr())}";
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
                return $"{Value} 1/{this.GetSymbol()}{(-1*Degree).ToSupStr()}";
            }
        }

        public double GetValueBy(SiMassUnits unit)
        {
            return this.GetValueBy(unit, this.Degree);
        }
    }
}
