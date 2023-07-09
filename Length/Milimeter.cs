using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIUnits.Length
{
    [SiSymbol("mm")]
    public class Milimeter:
    ISiLength
    {
        public double m_value { get; internal set; }
        static string _symbol = "mm";
        public string symbol => Milimeter._symbol;
        public const double MinValue = Double.MinValue;
        public const double MaxValue = Double.MaxValue;
        public Milimeter(double value)
        {
            m_value = value;
        }
        public Milimeter() { }
        public static implicit operator Milimeter(double value)
        {
            return new Milimeter(value);
        }
        public static implicit operator Milimeter(float value)
        {
            return new Milimeter(value);
        }
        public static implicit operator Milimeter(int value)
        {
            return new Milimeter(value);
        }
        public static implicit operator Milimeter(Centimeter cm)
        {
            return new Milimeter(cm.m_value * 10);
        }
        public static implicit operator Milimeter(Meter m)
        {
            return new Milimeter(m.m_value * 1000);
        }
        //public static implicit operator Meter(Milimeter mm)
        //{
        //    return new Meter(mm.m_value / 1000);
        //}
        //public static implicit operator Centimeter(Milimeter mm)
        //{
        //    return new Meter(mm.m_value / 10);
        //}
        public static Milimeter operator +(Milimeter a) => a;
        public static Milimeter operator -(Milimeter a) => (-1) * a;
        public static SqMilimeter operator *(Milimeter a, Milimeter b) => new SqMilimeter(a.m_value * b.m_value);
        public static Milimeter operator *(double d, Milimeter a) => new Milimeter(d * a.m_value);
        public static Milimeter operator *(Milimeter a, double d) => new Milimeter(d * a.m_value);

        public static double operator /(Milimeter a, Milimeter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return a.m_value / b.m_value;
        }
        public static Milimeter operator /(double d, Milimeter a)
        {
            if (a.m_value == 0) throw new DivideByZeroException();
            return new Milimeter(d / a.m_value);
        }
        public static Milimeter operator /(Milimeter a, double d)
        {
            if (d == 0) throw new DivideByZeroException();
            return new Milimeter(a.m_value / d);
        }
        public static Milimeter operator +(Milimeter a, Milimeter b) => new Milimeter(a.m_value + b.m_value);
        public static Milimeter operator +(double d, Milimeter a) => new Milimeter(d + a.m_value);
        public static Milimeter operator +(Milimeter a, double d) => new Milimeter(d + a.m_value);
        public static Milimeter operator -(Milimeter a, Milimeter b) => new Milimeter(a.m_value - b.m_value);
        public static Milimeter operator -(double d, Milimeter a) => new Milimeter(d - a.m_value);
        public static Milimeter operator -(Milimeter a, double d) => new Milimeter(d - a.m_value);

        // **** when struct is defined as record these equality checks comes by default.
        //public static bool operator ==(Milimeter a, Milimeter b) => a.Value == b.Value;
        //public static bool operator !=(Milimeter a, Milimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Milimeter a, Milimeter b) => a.m_value < b.m_value;
        public static bool operator >(Milimeter a, Milimeter b) => a.m_value > b.m_value;
        public static bool operator <=(Milimeter a, Milimeter b) => a.m_value <= b.m_value;
        public static bool operator >=(Milimeter a, Milimeter b) => a.m_value >= b.m_value;
        public bool Equals(Milimeter m)
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

        public int CompareTo(Milimeter other)
        {
            return this.m_value.CompareTo(other.m_value);
        }
    }
}
