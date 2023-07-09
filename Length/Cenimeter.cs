using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIUnits.Length
{
    [SiSymbol("cm")]
    public class Centimeter:
        ISiLength
    {
        public double m_value { get; internal set; }
        static string _symbol = "m";
        public string symbol => Centimeter._symbol;
        public const double MinValue = Double.MinValue;
        public const double MaxValue = Double.MaxValue;
        public Centimeter(double value)
        {
            m_value = value;
        }
        public Centimeter() { }
        public static implicit operator Centimeter(double value)
        {
            return new Centimeter(value);
        }
        public static implicit operator Centimeter(float value)
        {
            return new Centimeter(value);
        }
        public static implicit operator Centimeter(int value)
        {
            return new Centimeter(value);
        }
        public static implicit operator Centimeter(Meter cm)
        {
            return new Centimeter(cm.m_value * 100);
        }
        public static implicit operator Centimeter(Milimeter mm)
        {
            return new Centimeter(mm.m_value / 10);
        }
        public static Centimeter operator +(Centimeter a) => a;
        public static Centimeter operator -(Centimeter a) => (-1) * a;
        public static Centimeter operator *(Centimeter a, Centimeter b) => new Centimeter(a.m_value * b.m_value);
        public static Centimeter operator *(double d, Centimeter a) => new Centimeter(d * a.m_value);
        public static Centimeter operator *(Centimeter a, double d) => new Centimeter(d * a.m_value);
        public static Meter operator *(ISiLength a, Centimeter d) => new Centimeter(d.m_value * ((Centimeter)a).m_value);

        public static Centimeter operator /(Centimeter a, Centimeter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return new Centimeter(a.m_value / b.m_value);
        }
        public static Centimeter operator /(double d, Centimeter a)
        {
            if (a.m_value == 0) throw new DivideByZeroException();
            return new Centimeter(d / a.m_value);
        }
        public static Centimeter operator /(Centimeter a, double d)
        {
            if (d == 0) throw new DivideByZeroException();
            return new Centimeter(a.m_value / d);
        }
        public static Centimeter operator +(Centimeter a, Centimeter b) => new Centimeter(a.m_value + b.m_value);
        public static Centimeter operator +(double d, Centimeter a) => new Centimeter(d + a.m_value);
        public static Centimeter operator +(Centimeter a, double d) => new Centimeter(d + a.m_value);
        public static Centimeter operator -(Centimeter a, Centimeter b) => new Centimeter(a.m_value - b.m_value);
        public static Centimeter operator -(double d, Centimeter a) => new Centimeter(d - a.m_value);
        public static Centimeter operator -(Centimeter a, double d) => new Centimeter(d - a.m_value);

        // **** when struct is defined as record these equality checks comes by default.
        //public static bool operator ==(Centimeter a, Centimeter b) => a.Value == b.Value;
        //public static bool operator !=(Centimeter a, Centimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Centimeter a, Centimeter b) => a.m_value < b.m_value;
        public static bool operator >(Centimeter a, Centimeter b) => a.m_value > b.m_value;
        public static bool operator <=(Centimeter a, Centimeter b) => a.m_value <= b.m_value;
        public static bool operator >=(Centimeter a, Centimeter b) => a.m_value >= b.m_value;
        public bool Equals(Centimeter m)
        {
            return this.m_value == m.m_value;
        }
        public override string ToString()
        {
            return $"{this.m_value} {_symbol}";
        }
        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }

        public int CompareTo(Centimeter other)
        {
            return this.m_value.CompareTo(other.m_value);
        }
    }
}
