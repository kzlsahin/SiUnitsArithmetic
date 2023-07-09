using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Length
{
    public class Volume<T>
        where T : PrimitiveUnit<T>, new()
    {
        public double Value { get; internal set; }
        internal Type _unit;
        protected int _dimension = 3;
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
                        return $"{a.Symbol}\xB3";
                    }
                }
                return string.Empty;
            }
        }
        public Volume() : this(0)
        {
        }
        public Volume(double a_value)
        {
            this.Value = a_value;
            _unit = typeof(T);
        }
        public override string ToString()
        {
            return $"{this.Value} {symbol}";
        }

        public static Area<T> operator /(Volume<T> a, T b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            double value = a.Value / b.Value;
            var res = (Area<T>)Activator.CreateInstance(typeof(Area<T>));
            res.Value = value;
            return res;
        }
    }
}