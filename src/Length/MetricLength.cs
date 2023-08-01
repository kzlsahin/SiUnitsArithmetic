using SIUnits.Artihmetic;
using SIUnits.Length;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace SIUnits
{
    /// <summary>
    /// represents a length unit.
    /// </summary>
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
        /// <summary>
        /// Value of this MetricLength in units of this MetricLength.
        /// </summary>
        public double Value { get; }
        /// <summary>
        /// power of this MetricLength (if it is 2 and unit is metre, then it means m^2).
        /// </summary>
        public int Degree { get; }
        /// <summary>
        /// returns the symbol of the unit of this MetricLength.
        /// </summary>
        public string Symbol { get { return this.GetSymbol(); } }
        /// <summary>
        /// unit of this MetricLength.
        /// </summary>
        public SiMetricUnits Unit { get; }

        readonly static ArithmeticOperations<MetricLength, SiMetricUnits> _artihmetics = ArithmeticOperations<MetricLength, SiMetricUnits>.Instance;
        #region operators
        /// <summary>
        /// Multiplies a MetricLength with another MetricLength by converting the unit of the one of the operants to the unit ot otherone and multiplies the values.
        /// The higher unit is converted to the lower one. İf the two operants have same units then no conversion occures and values are multiplied. 
        /// The degree of the returned length unit is the sum of the degrees of the two operants.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new MetricLength with the same unit of the oprant that has the lower unit.</returns>
        public static MetricLength operator *(MetricLength a, MetricLength b) => _artihmetics.Multiply(a, b);
        /// <summary>
        /// Multiplies a MetricLength with a MetricTime and returns derived unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and time units such as m/s (result of 1.m() * 1.s(-1)).</returns>
        public static DerivedUnit operator *(MetricLength a, MetricTime b) => a.ToCompositeUnit() * b;
        /// <summary>
        /// Multiplies a MetricLength with a MetricMass and returns derived unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns a new DerivedUnit as a result of the multiplication of the length and mass units such as kg/m3 (result of 1.kg()*1.m(-3)).</returns>
        public static DerivedUnit operator *(MetricLength a, MetricMass b) => a.ToCompositeUnit() * b;
        /// <summary>
        /// scaler multiplication of MetricLength.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new MetricLength as a result of the scaler multiplication of the MetricLength.</returns>
        public static MetricLength operator *(MetricLength a, double b) => _artihmetics.Multiply(b, a);
        /// <summary>
        /// scaler multiplication of MetricLength.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>returns new MetricLength as a result of the scaler multiplication of the MetricLength.</returns>
        public static MetricLength operator *(double a, MetricLength b) => _artihmetics.Multiply(a, b);
        public static MetricLength operator /(MetricLength a, MetricLength b) => _artihmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricLength a, MetricTime b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricLength a, MetricMass b) => a.ToCompositeUnit() / b;
        public static MetricLength operator /(MetricLength a, double b) => _artihmetics.Divide(a, b);
        public static MetricLength operator /(double a, MetricLength b) => _artihmetics.Divide(a, b);
        public static MetricLength operator +(MetricLength a, MetricLength b) => _artihmetics.Sum(a, b);
        public static MetricLength operator -(MetricLength a, MetricLength b) => _artihmetics.Subtract(a, b);
        /// <summary>
        /// checks equality of the two MetricLength based on their values relative to their units such as 100 cm == 1 metre => true.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(MetricLength a, MetricLength b) => _artihmetics.IsEqual(a, b);
        /// <summary>
        /// checks the unequality of the two MetricLength based on their values relative to their units.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(MetricLength a, MetricLength b) => !_artihmetics.IsEqual(a, b);
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
                return _artihmetics.IsEqual(this, (MetricLength)obj);
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
            return (new Tuple<int,int,double>((int)this.Unit * 10, this.Degree, this.Value)).GetHashCode();
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
