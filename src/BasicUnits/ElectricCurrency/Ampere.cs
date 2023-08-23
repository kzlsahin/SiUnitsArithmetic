using System;
using System.Collections.Generic;
using System.Text;
using SIUnits.Artihmetic;
using SIUnits.BasicUnits.ElectricCurrency;
using SIUnits.Length;

namespace SIUnits
{
    /// <summary>
    /// represents a length unit.
    /// </summary>
    public class Ampere : Metric<SiAmpereUnits>
    {
        /// <summary>
        /// initialize a length unit of type Ampere in specified unit with specified degree from double value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="degree"></param>
        /// <param name="unit"></param>
        public Ampere(double value, int degree, SiAmpereUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        internal Ampere() : this(0, 1, SiAmpereUnits.ampere)
        {

        }
        public override Metric<SiAmpereUnits> NewInstance(double value, int degree, SiAmpereUnits unit)
        {
            return new Ampere(value, degree, unit);
        }

        public override IBasicUnit NewInstance(double value, int degree, int unitOrder)
        {
            SiAmpereUnits unit = (SiAmpereUnits)unitOrder;
            return new Ampere(value, degree, unit);
        }
        public static Ampere FundamentalUnit => new Ampere(1, 1, SiAmpereUnits.ampere);
        public static Ampere ScalerOne => new Ampere(1, 0, SiAmpereUnits.ampere);
        /// <summary>
        /// Value of this Ampere in units of this Ampere.
        /// </summary>
        public override double Value { get; }
        /// <summary>
        /// power of this Ampere (if it is 2 and unit is metre, then it means m^2).
        /// </summary>
        public override int Degree { get; }
        /// <summary>
        /// returns the symbol of the unit of this Ampere.
        /// </summary>
        public override string Symbol { get { return this.GetSymbol(); } }
        /// <summary>
        /// unit of this Ampere.
        /// </summary>
        public override SiAmpereUnits Unit { get; }
        /// <summary>
        /// Unit index of the unit among metric units scale.
        /// </summary>
        public override int UnitOrder { get => (int)Unit; }

        static Guid _id = new Guid("79D1B50F-726E-4718-B46D-B02BE3857BB0");
        /// <summary>
        /// to get the static Id of this unit type.
        /// </summary>
        public override Guid Id { get => _id; }

        readonly static ArithmeticOperations<Ampere, SiAmpereUnits> _arithmetics = ArithmeticOperations<Ampere, SiAmpereUnits>.Instance;
        #region operators
        /// <summary>
        /// Multiplies a Ampere with another Ampere by converting the unit of the one of the operants to the unit ot otherone and multiplies the values.
        /// The higher unit is converted to the lower one. İf the two operants have same units then no conversion occures and values are multiplied. 
        /// The degree of the returned length unit is the sum of the degrees of the two operants.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new Ampere with the same unit of the oprant that has the lower unit.</returns>
        public static Ampere operator *(Ampere a, Ampere b) => (Ampere)_arithmetics.Multiply(a, b);
        /// <summary>
        /// Multiplies a Ampere with a MetricTime and returns derived unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and time units such as m/s (result of 1.m() * 1.s(-1)).</returns>
        public static DerivedUnit operator *(Ampere a, MetricTime b) => a.ToCompositeUnit() * b;
        /// <summary>
        /// Multiplies a Ampere with a MetricMass and returns derived unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and mass units such as kg/m3 (result of 1.kg()*1.m(-3)).</returns>
        public static DerivedUnit operator *(Ampere a, MetricMass b) => a.ToCompositeUnit() * b;
        /// <summary>
        /// scaler multiplication of Ampere.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new Ampere as a result of the scaler multiplication of the Ampere.</returns>
        public static Ampere operator *(Ampere a, double b) => (Ampere)_arithmetics.Multiply(b, a);
        /// <summary>
        /// scaler multiplication of Ampere.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new Ampere as a result of the scaler multiplication of the Ampere.</returns>
        public static Ampere operator *(double a, Ampere b) => (Ampere)_arithmetics.Multiply(a, b);
        /// <summary>
        /// Multiplies a Ampere with a Ampere and returns Ampere unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and time units such as m/s (result of 1.m() * 1.s(-1)).</returns>
        public static Ampere operator /(Ampere a, Ampere b) => (Ampere)_arithmetics.Divide(a, b);
        /// <summary>
        /// Multiplies a Ampere with a Ampere and returns Ampere unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and time units such as m/s (result of 1.m() * 1.s(-1)).</returns>
        public static DerivedUnit operator /(Ampere a, MetricTime b) => a.ToCompositeUnit() / b;
        /// <summary>
        /// Multiplies a Ampere with a Ampere and returns Ampere unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and time units such as m/s (result of 1.m() * 1.s(-1)).</returns>
        public static DerivedUnit operator /(Ampere a, MetricMass b) => a.ToCompositeUnit() / b;
        public static Ampere operator /(Ampere a, double b) => (Ampere)_arithmetics.Divide(a, b);
        public static Ampere operator /(double a, Ampere b) => (Ampere)_arithmetics.Divide(a, b);
        public static Ampere operator +(Ampere a, Ampere b) => (Ampere)_arithmetics.Sum(a, b);
        public static Ampere operator -(Ampere a, Ampere b) => (Ampere)_arithmetics.Subtract(a, b);
        /// <summary>
        /// checks equality of the two Ampere based on their values relative to their units such as 100 cm == 1 metre => true.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Ampere a, Ampere b) => _arithmetics.IsEqual(a, b);
        /// <summary>
        /// checks the unequality of the two Ampere based on their values relative to their units.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Ampere a, Ampere b) => !_arithmetics.IsEqual(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <(Ampere a, Ampere b) => _arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >(Ampere a, Ampere b) => _arithmetics.IsGreaterThen(a, b);
        /// <summary>
        /// Checks if the value of a is not greater then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not greater then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <=(Ampere a, Ampere b) => !_arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is not less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not less then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >=(Ampere a, Ampere b) => !_arithmetics.IsGreaterThen(a, b);

        #endregion
        /// <summary>
        /// checks value equality like 100 cm == 1 metre => true.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Ampere)
            {
                return _arithmetics.IsEqual(this, (Ampere)obj);
            }
            return false;
        }
        /// <summary>
        /// returns hashcode of the Ampere. Hashcodes of Amperes with same unit,
        ///  same degree and same value are equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (new Tuple<int, int, double>((int)this.UnitOrder * 10, this.Degree, this.Value)).GetHashCode();
        }

        public override double GetValueBy(SiAmpereUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
        public override double GetValueBy(int unitOrder)
        {
            var unit = (SiAmpereUnits)unitOrder;
            return this.GetUnitValue(unit, this.Degree);
        }

        public override DerivedUnit ToCompositeUnit()
        {
            return DerivedUnit.New(this);
        }
    }
}
