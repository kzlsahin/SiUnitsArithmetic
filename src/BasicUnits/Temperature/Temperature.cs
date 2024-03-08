using SIUnits.Artihmetic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SIUnits
{
    [Guid("2E233835-08E5-4C37-B01C-BBB06F081292")]
    public class Temperature : Metric<SiTemperatureUnits>
    {
        public Temperature(double value, int degree, SiTemperatureUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public override Metric<SiTemperatureUnits> NewInstance(double value, int degree, SiTemperatureUnits unit)
        {
            return new Temperature(value, degree, unit);
        }
        public override IBasicUnit NewInstance(double value, int degree, int unitOrder)
        {
            SiTemperatureUnits unit = (SiTemperatureUnits)unitOrder;
            return new Temperature(value, degree, unit);
        }
        public static Temperature FundamentalUnit => new Temperature(1, 1, SiTemperatureUnits.kelvin);
        internal static Temperature ScalerOne => new Temperature(1, 0, SiTemperatureUnits.kelvin);
        /// <summary>
        /// Value of this Temperature in units of this Temperature.
        /// </summary>
        public override double Value { get; }
        /// <summary>
        /// power of this Temperature (if it is 2, then it means kg^2).
        /// </summary>
        public override int Degree { get; }
        /// <summary>
        /// unit of this Temperature.
        /// </summary>
        public override int UnitOrder { get => (int)(Unit); }
        /// <summary>
        /// unit of this Temperature.
        /// </summary>
        public override SiTemperatureUnits Unit { get; }
        /// <summary>
        /// String symbol of the unit
        /// </summary>
        public override string Symbol { get { return this.GetSymbol(); } }

        static readonly Guid _id = new Guid("2E233835-08E5-4C37-B01C-BBB06F081292");
        /// <summary>
        /// to get the static Id of this unit type.
        /// </summary>
        public override Guid Id { get => _id; }
        public static Guid ID { get => _id; }

        readonly static ArithmeticOperations<Temperature, SiTemperatureUnits> _arithmetics = ArithmeticOperations<Temperature, SiTemperatureUnits>.Instance;

        #region operators
        public static Temperature operator *(Temperature a, Temperature b) => (Temperature)_arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(Temperature a, IBasicUnit b) => a.ToCompositeUnit() * b.ToCompositeUnit();
        public static Temperature operator *(Temperature a, double b) => (Temperature)_arithmetics.Multiply(b, a);
        public static Temperature operator *(double a, Temperature b) => (Temperature)_arithmetics.Multiply(a, b);
        public static Temperature operator /(Temperature a, Temperature b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(Temperature a, IBasicUnit b) => a.ToCompositeUnit() / b.ToCompositeUnit();
        public static Temperature operator /(Temperature a, double b) => (Temperature)_arithmetics.Divide(a, b);
        public static Temperature operator /(double a, Temperature b) => (Temperature)_arithmetics.Divide(a, b);
        public static Temperature operator +(Temperature a, Temperature b) => (Temperature)_arithmetics.Sum(a, b);
        public static Temperature operator -(Temperature a, Temperature b) => (Temperature)_arithmetics.Subtract(a, b);
        public static bool operator ==(Temperature a, Temperature b) => _arithmetics.IsEqual(a, b);
        public static bool operator !=(Temperature a, Temperature b) => !_arithmetics.IsEqual(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <(Temperature a, Temperature b) => _arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >(Temperature a, Temperature b) => _arithmetics.IsGreaterThen(a, b);
        /// <summary>
        /// Checks if the value of a is not greater then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not greater then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <=(Temperature a, Temperature b) => !_arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is not less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not less then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >=(Temperature a, Temperature b) => !_arithmetics.IsGreaterThen(a, b);
        #endregion
        /// <summary>
        /// checks value equality like 1000 g == 1 kg => true.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Temperature)
            {
                return _arithmetics.IsEqual(this, (Temperature)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (new Tuple<int, int, double>((int)this.UnitOrder * 10 + 1, this.Degree, this.Value)).GetHashCode();
        }
        public override double GetValueBy(int unitOrder)
        {
            SiTemperatureUnits unit = (SiTemperatureUnits)unitOrder;
            return this.GetUnitValue(unit, this.Degree);
        }
        public override double GetValueBy(SiTemperatureUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
        public override DerivedUnit ToCompositeUnit()
        {
            return DerivedUnit.New(this);
        }
    }
}
