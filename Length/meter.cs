using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIUnits.Length
{
    [SiSymbol("m")]
    public class Meter :
        IComparable<Meter>,
        ISiLength
    {
        public double m_value { get; internal set; }
        internal static string _symbol = "m";
        public string symbol => Meter._symbol;

        public const double MinValue = Double.MinValue;
        public const double MaxValue = Double.MaxValue;
        public Meter(double value)
        {
            m_value = value;
        }
        public Meter() { }

        public static implicit operator Meter(double value)
        {
            return new Meter(value);
        }
        public static implicit operator Meter(float value)
        {
            return new Meter(value);
        }
        public static implicit operator Meter(int value)
        {
            return new Meter(value);
        }
        public static implicit operator Meter(Centimeter cm)
        {
            return new Meter(cm.m_value / 100);
        }
        public static implicit operator Meter(Milimeter mm)
        {
            return new Meter(mm.m_value / 1000);
        }
        public static Meter operator +(Meter a) => a;
        public static Meter operator -(Meter a) => (-1) * a;
        public static SqMeter operator *(Meter a, Meter b) => new SqMeter(a.m_value * b.m_value);
        public static Meter operator *(double d, Meter a) => new Meter(d*a.m_value);
        public static Meter operator *(Meter a, double d) => new Meter(d*a.m_value);
        public static Double operator /(Meter a, Meter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return a.m_value / b.m_value;
        }
        public static Meter operator /(double d, Meter a)
        {
            if (a.m_value == 0) throw new DivideByZeroException();
            return new Meter(d / a.m_value);
        }
        public static Meter operator /(Meter a, double d)
        {
            if (d == 0) throw new DivideByZeroException();
            return new Meter(a.m_value / d);
        }
        public static Meter operator +(Meter a, Meter b) => new Meter(a.m_value + b.m_value);
        public static Meter operator +(double d, Meter a) => new Meter(d + a.m_value);
        public static Meter operator +(Meter a, double d) => new Meter(d + a.m_value);
       public static Meter operator -(Meter a, Meter b) => new Meter(a.m_value - b.m_value);
        public static Meter operator -(double d, Meter a) => new Meter(d - a.m_value);
        public static Meter operator -(Meter a, double d) => new Meter(d - a.m_value);
       
        // **** when struct is defined as record these equality checks comes by default.
        //public static bool operator ==(Meter a, Meter b) => a.Value == b.Value;
        //public static bool operator !=(Meter a, Meter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Meter a, Meter b) => a.m_value < b.m_value;
        public static bool operator >(Meter a, Meter b) => a.m_value > b.m_value;
        public static bool operator <=(Meter a, Meter b) => a.m_value <= b.m_value;
        public static bool operator >=(Meter a, Meter b) => a.m_value >= b.m_value;
        
        public bool Equals(Meter m)
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

        public int CompareTo(Meter other)
        {
            return this.m_value.CompareTo(other.m_value);
        }
    }
}
