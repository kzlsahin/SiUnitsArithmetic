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
        public override Metric<SiMassUnits> NewInstance(double value, int degree, SiMassUnits unit)
        {
            return new MetricMass(value, degree, unit);
        }
        public override IBasicUnit NewInstance(double value, int degree, int unitOrder)
        {
            SiMassUnits unit = (SiMassUnits)unitOrder;
            return new MetricMass(value, degree, unit);
        }
        /// <summary>
        /// Value of this MetricMass in units of this MetricMass.
        /// </summary>
        public override double Value { get;}
        /// <summary>
        /// power of this MetricMass (if it is 2, then it means kg^2).
        /// </summary>
        public override int Degree { get; }
        /// <summary>
        /// unit of this MetricMass.
        /// </summary>
        public override int UnitOrder { get => (int)(Unit);}
        /// <summary>
        /// unit of this MetricMass.
        /// </summary>
        public override SiMassUnits Unit { get; }
        /// <summary>
        /// String symbol of the unit
        /// </summary>
        public override string Symbol { get { return this.GetSymbol(); } }

        static Guid _id = new Guid("76109C9F-CE95-4032-A3B3-6A8272EED00D");
        /// <summary>
        /// to get the static Id of this unit type.
        /// </summary>
        public override Guid Id { get => _id; }
        readonly static ArithmeticOperations<MetricMass, SiMassUnits> _arithmetics = ArithmeticOperations<MetricMass, SiMassUnits>.Instance;

        #region operators
        public static MetricMass operator *(MetricMass a, MetricMass b) => (MetricMass)_arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricMass a, IBasicUnit b) => a.ToCompositeUnit() * b.ToCompositeUnit();
        public static MetricMass operator *(MetricMass a, double b) => (MetricMass)_arithmetics.Multiply(b, a);
        public static MetricMass operator *(double a, MetricMass b) => (MetricMass)_arithmetics.Multiply(a, b);
        public static MetricMass operator /(MetricMass a, MetricMass b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricMass a, IBasicUnit b) => a.ToCompositeUnit() / b.ToCompositeUnit();
        public static MetricMass operator /(MetricMass a, double b) => (MetricMass)_arithmetics.Divide(a, b);
        public static MetricMass operator /(double a, MetricMass b) => (MetricMass)_arithmetics.Divide(a, b);
        public static MetricMass operator +(MetricMass a, MetricMass b) => (MetricMass)_arithmetics.Sum(a, b);
        public static MetricMass operator -(MetricMass a, MetricMass b) => (MetricMass)_arithmetics.Subtract(a, b);
        public static bool operator ==(MetricMass a, MetricMass b) => _arithmetics.IsEqual(a, b);
        public static bool operator !=(MetricMass a, MetricMass b) => !_arithmetics.IsEqual(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <(MetricMass a, MetricMass b) => _arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >(MetricMass a, MetricMass b) => _arithmetics.IsGreaterThen(a, b);
        /// <summary>
        /// Checks if the value of a is not greater then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not greater then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <=(MetricMass a, MetricMass b) => !_arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is not less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not less then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >=(MetricMass a, MetricMass b) => !_arithmetics.IsGreaterThen(a, b);
        #endregion
        /// <summary>
        /// checks value equality like 1000 g == 1 kg => true.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is MetricMass)
            {
                return _arithmetics.IsEqual(this, (MetricMass)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (new Tuple<int, int, double>((int)this.UnitOrder*10 +1, this.Degree, this.Value)).GetHashCode();
        }       
        public override double GetValueBy(int unitOrder)
        {
            SiMassUnits unit = (SiMassUnits)unitOrder;
            return this.GetValueBy(unit, this.Degree);
        }
        public override double GetValueBy(SiMassUnits unit)
        {
            return this.GetValueBy(unit, this.Degree);
        }
        public override DerivedUnit ToCompositeUnit()
        {
            return DerivedUnit.New(this);
        }
    }
}
