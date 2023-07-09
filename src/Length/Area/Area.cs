﻿using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Reflection;

namespace SIUnits.Length
{
    public class Area<T>
        where T : PrimitiveUnit<T>, new()
    {
        public double Value { get; internal set; }
        internal Type _unit;
        protected int _dimension = 2;
        internal int Dimension { get { return _dimension; } }
        public string symbol
        {
            get
            {
                System.Attribute[] attrs = System.Attribute.GetCustomAttributes(_unit);  // Reflection.

                // Displaying output.
                foreach (System.Attribute attr in attrs)
                {
                    if (attr is SiSymbolAttribute a)
                    {
                        return $"{a.Symbol}\xB2";
                    }
                }
                return string.Empty;
            }
        }
        public Area() : this(0)
        {
        }
        public Area(double a_value)
        {
            this.Value = a_value;
            _unit = typeof(T);
        }
        public override string ToString()
        {
            return $"{this.Value} {symbol}";
        }

        public static T operator /(Area<T> a, T b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            double value = a.Value / b.Value;
            var res = (T)Activator.CreateInstance(a._unit);
            res.Value = value;
            return res;
        }

        public static Volume<T> operator *(Area<T> a, T b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            double value = a.Value * b.Value;
            var res = (Volume<T>)Activator.CreateInstance(typeof(Volume<T>));
            res.Value = value;
            return res;
        }
        public static Volume<T> operator *(T b, Area<T> a)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            double value = a.Value * b.Value;
            var res = (Volume<T>)Activator.CreateInstance(typeof(Volume<T>));
            res.Value = value;
            return res;
        }
    }
}
