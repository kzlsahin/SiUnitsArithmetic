using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
using System.Reflection;

namespace SIUnits.Length
{
    public class Area<T>
        where T : ISiLength
    {
        public double a_value { get; internal set; }
        internal Type _unit;
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
                        return $"{a.Symbol}²";
                    }
                }
                return string.Empty;
            }
        }
        internal Area(double a_value)
        {
            this.a_value = a_value;
            _unit = typeof(T);
        }
        public override string ToString()
        {
            return $"{this.a_value} {symbol}";
        }

        public static T operator /(Area<T> a, T b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return (T)Activator.CreateInstance(a._unit, new Object[] { (a.a_value / b.m_value) });
        }
    }
}
