using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIUnits.Length
{
    [SiSymbol("mm")]
    public class Milimeter :
        PrimitiveUnit<Milimeter>,
        IComparable<Milimeter>,
        ISiLength
    {
        internal static string _symbol = "m";
        public override string symbol => Milimeter._symbol;
        protected override int _exponent => -3;

        public Milimeter() { }
        public Milimeter(double value) : base(value) { }

        public static implicit operator Milimeter(Meter m)
        {
            return new Milimeter(m.m_value * 1000);
        }
        public static implicit operator Meter(Milimeter mm)
        {
            return new Meter(mm.m_value / 1000);
        }
        public static SqMilimeter operator *(Milimeter a, Milimeter b) => new SqMilimeter(a.m_value * b.m_value);
        public static Double operator /(Milimeter a, Milimeter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return a.m_value / b.m_value;
        }
        public static Milimeter operator +(Milimeter a, Milimeter b) => new Milimeter(a.m_value + b.m_value);

        public static Milimeter operator -(Milimeter a, Milimeter b) => new Milimeter(a.m_value - b.m_value);


        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Milimeter a, Milimeter b) => a.m_value == b.m_value;
        public static bool operator !=(Milimeter a, Milimeter b) => a.m_value != b.m_value;
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
