using SIUnits.Artihmetic;
using SIUnits.Length;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;


namespace SIUnits
{
    /// <summary>
    /// represents a length unit.
    /// </summary>
    [Guid("6C700696-394B-4F45-AEF8-34405EDF1232")]
    public class MetricLength : Metric<SiMetricUnits>
    {
        /// <summary>
        /// initialize a length unit of type MetricLength in specified unit with specified degree from double value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="degree"></param>
        /// <param name="unit"></param>
        public MetricLength(double value, int degree, SiMetricUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        internal MetricLength() : this(0, 1, SiMetricUnits.metre)
        {

        }
        public override Metric<SiMetricUnits> NewInstance(double value, int degree, SiMetricUnits unit)
        {
            return new MetricLength(value, degree, unit);
        }
        public override IBasicUnit NewInstance(double value, int degree, int unitOrder)
        {
            SiMetricUnits unit = (SiMetricUnits)unitOrder;
            return new MetricLength(value, degree, unit);
        }
        public static MetricLength FundamentalUnit => new MetricLength(1, 1, SiMetricUnits.metre);
        internal static MetricLength ScalerOne => new MetricLength(1, 0, SiMetricUnits.metre);

        /// <summary>
        /// Value of this MetricLength in units of this MetricLength.
        /// </summary>
        public override double Value { get; }
        /// <summary>
        /// power of this MetricLength (if it is 2 and unit is metre, then it means m^2).
        /// </summary>
        public override int Degree { get; }
        /// <summary>
        /// returns the symbol of the unit of this MetricLength.
        /// </summary>
        public override string Symbol { get { return this.GetSymbol(); } }
        /// <summary>
        /// unit of this MetricLength.
        /// </summary>
        public override int UnitOrder {get => (int)Unit; }
        public override SiMetricUnits Unit {get; }

        static readonly Guid _id = new Guid("6C700696-394B-4F45-AEF8-34405EDF1232");
        /// <summary>
        /// to get the static Id of this unit type.
        /// </summary>
        public override Guid Id { get => _id; }
        public static Guid ID { get => _id; }

        readonly static ArithmeticOperations _arithmetics = ArithmeticOperations.Instance;
        #region operators
        /// <summary>
        /// Multiplies a MetricLength with another MetricLength by converting the unit of the one of the operants to the unit ot otherone and multiplies the values.
        /// The higher unit is converted to the lower one. İf the two operants have same units then no conversion occures and values are multiplied. 
        /// The degree of the returned length unit is the sum of the degrees of the two operants.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new MetricLength with the same unit of the oprant that has the lower unit.</returns>
        public static MetricLength operator *(MetricLength a, MetricLength b) => (MetricLength)_arithmetics.Multiply(a, b);
        /// <summary>
        /// Multiplies a MetricLength with a MetricTime and returns derived unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and time units such as m/s (result of 1.m() * 1.s(-1)).</returns>
        public static DerivedUnit operator *(MetricLength a, MetricTime b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricLength a, MetricMass b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricLength a, Ampere b) => a.ToCompositeUnit() * b;
        /// <summary>
        /// scaler multiplication of MetricLength.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new MetricLength as a result of the scaler multiplication of the MetricLength.</returns>
        public static MetricLength operator *(MetricLength a, double b) => (MetricLength)_arithmetics.Multiply(b, a);
        /// <summary>
        /// scaler multiplication of MetricLength.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new MetricLength as a result of the scaler multiplication of the MetricLength.</returns>
        public static MetricLength operator *(double a, MetricLength b) => (MetricLength)_arithmetics.Multiply(a, b);
        public static MetricLength operator /(MetricLength a, MetricLength b) => (MetricLength)_arithmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricLength a, MetricMass b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricLength a, MetricTime b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricLength a, Ampere b) => a.ToCompositeUnit() / b;
        public static MetricLength operator /(MetricLength a, double b) => (MetricLength)_arithmetics.Divide(a, b);
        public static MetricLength operator /(double a, MetricLength b) => (MetricLength)_arithmetics.Divide(a, b);
        public static MetricLength operator +(MetricLength a, MetricLength b) => (MetricLength)_arithmetics.Sum(a, b);
        public static MetricLength operator -(MetricLength a, MetricLength b) => (MetricLength)_arithmetics.Subtract(a, b);
        /// <summary>
        /// checks equality of the two MetricLength based on their values relative to their units such as 100 cm == 1 metre => true.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(MetricLength a, MetricLength b) => _arithmetics.IsEqual(a, b);
        /// <summary>
        /// checks the unequality of the two MetricLength based on their values relative to their units.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(MetricLength a, MetricLength b) => !_arithmetics.IsEqual(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <(MetricLength a, MetricLength b) => _arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >(MetricLength a, MetricLength b) => _arithmetics.IsGreaterThen(a, b);
        /// <summary>
        /// Checks if the value of a is not greater then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not greater then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <=(MetricLength a, MetricLength b) => !_arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is not less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not less then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >=(MetricLength a, MetricLength b) => !_arithmetics.IsGreaterThen(a, b);

        #endregion
        /// <summary>
        /// checks value equality like 100 cm == 1 metre => true.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is MetricLength)
            {
                return _arithmetics.IsEqual(this, (MetricLength)obj);
            }
            return false;
        }
        /// <summary>
        /// returns hashcode of the MetricLength. Hashcodes of MetricLengths with same unit,
        ///  same degree and same value are equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {            
            return (new Tuple<int,int,double>((int)this.UnitOrder * 10, this.Degree, this.Value)).GetHashCode();
        }
        public override double GetValueBy(SiMetricUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
        public override double GetValueBy(int unitOrder)
        {
            SiMetricUnits unit = (SiMetricUnits)unitOrder;
            return this.GetUnitValue(unit, this.Degree);
        }

        public override DerivedUnit ToCompositeUnit()
        {
            return DerivedUnit.New(this);
        }
    }
}
