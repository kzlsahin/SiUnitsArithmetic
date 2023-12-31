﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public abstract class Metric<T> :
        IBasicUnit,
        IComparable
        where T : Enum
    {
        public abstract double Value { get; }
        public abstract int Degree { get; }
        public abstract String Symbol { get; }
        public abstract int UnitOrder { get; }
        public abstract T Unit { get; }
        public abstract IBasicUnit NewInstance(double value, int degree, int unitOrder);
        public abstract Metric<T> NewInstance(double value, int degree, T unit);
        public abstract double GetValueBy(int unitOrder);
        public abstract double GetValueBy(T unit);
        public abstract Guid Id { get; }
        public abstract DerivedUnit ToCompositeUnit();
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
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer 
        /// that indicates whether the current instance precedes, follows, 
        /// or occurs in the same position in the sort order as the other object.
        /// if Less than zero, this instance precedes obj in the sort order.
        /// if zero, this instance occurs in the same position in the sort order as obj.
        /// if greater then zero, this instance follows obj in the sort order.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            if(obj is Metric<T>)
            {
                return this.Value.CompareTo(((Metric<T>)obj).Value);
            }
            else
            {
                throw new ArgumentException($"Object is not a Metric<{typeof(T)}>");
            }
        }
    }
}
