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
        public override Metric<SiTimeUnits> NewInstance(double value, int degree, SiTimeUnits unit)
        {
            return new MetricTime(value, degree, unit);
        }
        public override IBasicUnit NewInstance(double value, int degree, int unitOrder)
        {
            SiTimeUnits unit = (SiTimeUnits)UnitOrder;
            return new MetricTime(value, degree, unit);
        }
        public static MetricTime FundamentalUnit => new MetricTime(1, 1, SiTimeUnits.second);
        internal static MetricTime ScalerOne => new MetricTime(1, 0, SiTimeUnits.second);
        /// <summary>
        /// Value of this MetricTime in units of this MetricTime.
        /// </summary>
        public override double Value { get;}
        /// <summary>
        /// power of this MetricTime (if it is 2 and unit is minute, then it means min^2).
        /// </summary>
        public override int Degree { get; }
        /// <summary>
        /// unit of this MetricTime.
        /// </summary>
        public override SiTimeUnits Unit { get;}
        public override int UnitOrder { get => (int)Unit; }
        /// <summary>
        /// String symbol of the unit
        /// </summary>
        public override string Symbol { get { return this.GetSymbol(); } }

        static Guid _id = new Guid("C19C4E5F-F216-49AB-9265-9F250B58A58A");
        /// <summary>
        /// to get the static Id of this unit type.
        /// </summary>
        public override Guid Id { get => _id; }
        public static Guid ID { get => _id; }

        readonly static ArithmeticOperations _arithmetics = ArithmeticOperations.Instance;

        #region operators
        public static MetricTime operator *(MetricTime a, MetricTime b) => (MetricTime)_arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricTime a, IBasicUnit b) => a.ToCompositeUnit() * b.ToCompositeUnit();
        public static MetricTime operator *(MetricTime a, double b) => (MetricTime)_arithmetics.Multiply(b, a);
        public static MetricTime operator *(double a, MetricTime b) => (MetricTime)_arithmetics.Multiply(a, b);
        public static MetricTime operator /(MetricTime a, MetricTime b) => (MetricTime)_arithmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricTime a, IBasicUnit b) => a.ToCompositeUnit() / b.ToCompositeUnit();
        public static MetricTime operator /(MetricTime a, double b) => (MetricTime)_arithmetics.Divide(a, b);
        public static MetricTime operator /(double a, MetricTime b) => (MetricTime)_arithmetics.Divide(a, b);
        public static MetricTime operator +(MetricTime a, MetricTime b) => (MetricTime)_arithmetics.Sum(a, b);
        public static MetricTime operator -(MetricTime a, MetricTime b) => (MetricTime)_arithmetics.Subtract(a, b);
        public static bool operator ==(MetricTime a, MetricTime b) => _arithmetics.IsEqual(a, b);
        public static bool operator !=(MetricTime a, MetricTime b) => !_arithmetics.IsEqual(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <(MetricTime a, MetricTime b) => _arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >(MetricTime a, MetricTime b) => _arithmetics.IsGreaterThen(a, b);
        /// <summary>
        /// Checks if the value of a is not greater then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not greater then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator <=(MetricTime a, MetricTime b) => !_arithmetics.IsLessThen(a, b);
        /// <summary>
        /// Checks if the value of a is not less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true if the value of a is not less then value of b</returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        public static bool operator >=(MetricTime a, MetricTime b) => !_arithmetics.IsGreaterThen(a, b);
        #endregion
        /// <summary>
        /// checks value equality like 60 minute == 1 hour => true.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is MetricTime)
            {
                return _arithmetics.IsEqual(this, (MetricTime)obj);
            }
            return false;
        }
        public override int GetHashCode()
        {

            return (new Tuple<int, int, double>((int)this.UnitOrder*10 +2, this.Degree, this.Value)).GetHashCode();
        }
        public override double GetValueBy(SiTimeUnits unit)
        {
            return this.GetUnitValue(unit, this.Degree);
        }
        public override double GetValueBy(int unitOrder)
        {
            SiTimeUnits unit = (SiTimeUnits)unitOrder;
            return this.GetUnitValue(unit, this.Degree);
        }
        public override DerivedUnit ToCompositeUnit()
        {
            return DerivedUnit.New(this);
        }
    }
}
