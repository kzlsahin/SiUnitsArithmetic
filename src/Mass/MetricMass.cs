﻿using SIUnits.Artihmetic;
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
        /// <summary>
        /// Value of this MetricMass in units of this MetricMass.
        /// </summary>
        public double Value { get;}
        /// <summary>
        /// power of this MetricMass (if it is 2, then it means kg^2).
        /// </summary>
        public int Degree{ get; }
        /// <summary>
        /// unit of this MetricMass.
        /// </summary>
        public SiMassUnits Unit { get;}
        public string Symbol { get { return this.GetSymbol(); } }
        readonly static ArithmeticOperations<MetricMass, SiMassUnits> _arithmetics = ArithmeticOperations<MetricMass, SiMassUnits>.Instance;
        public Metric<SiMassUnits> NewInstance(double value, int degree, SiMassUnits unit)
        {
            return new MetricMass(value, degree, unit);
        }
        #region operators
        public static MetricMass operator *(MetricMass a, MetricMass b) => _arithmetics.Multiply(a, b);
        public static DerivedUnit operator *(MetricMass a, MetricLength b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricMass a, MetricTime b) => a.ToCompositeUnit() * b;
        public static MetricMass operator *(MetricMass a, double b) => _arithmetics.Multiply(b, a);
        public static MetricMass operator *(double a, MetricMass b) => _arithmetics.Multiply(a, b);
        public static MetricMass operator /(MetricMass a, MetricMass b) => _arithmetics.Divide(a, b);
        public static DerivedUnit operator /(MetricMass a, MetricLength b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricMass a, MetricTime b) => a.ToCompositeUnit() / b;
        public static MetricMass operator /(MetricMass a, double b) => _arithmetics.Divide(a, b);
        public static MetricMass operator /(double a, MetricMass b) => _arithmetics.Divide(a, b);
        public static MetricMass operator +(MetricMass a, MetricMass b) => _arithmetics.Sum(a, b);
        public static MetricMass operator -(MetricMass a, MetricMass b) => _arithmetics.Subtract(a, b);
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
            return (new Tuple<int, int, double>((int)this.Unit*10 +1, this.Degree, this.Value)).GetHashCode();
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
                return $"{Symbol}{(Degree == -1 ? "" : (-1*Degree).ToSupStr())}";
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

        public double GetValueBy(SiMassUnits unit)
        {
            return this.GetValueBy(unit, this.Degree);
        }
    }
}
