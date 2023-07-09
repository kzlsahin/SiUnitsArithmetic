using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Length
{
    [SiSymbol("dm")]
    public class Decimeter :
        PrimitiveUnit<Decimeter>,
        IComparable<Decimeter>,
        ISiLength
    {
        internal static string _symbol = "m";
        public override string symbol => Decimeter._symbol;
        protected override int _exponent => -1;

        public Decimeter() { }
        public Decimeter(double value) : base(value) { }

        public static implicit operator Decimeter(Meter m)
        {
            return new Decimeter(m.m_value * 10);
        }
        public static implicit operator Meter(Decimeter dm)
        {
            return new Meter(dm.m_value / 10);
        }
        public static SqDecimeter operator *(Decimeter a, Decimeter b) => new SqDecimeter(a.m_value * b.m_value);
        public static Double operator /(Decimeter a, Decimeter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return a.m_value / b.m_value;
        }
        public static Decimeter operator +(Decimeter a, Decimeter b) => new Decimeter(a.m_value + b.m_value);

        public static Decimeter operator -(Decimeter a, Decimeter b) => new Decimeter(a.m_value - b.m_value);


        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Decimeter a, Decimeter b) => a.m_value == b.m_value;
        public static bool operator !=(Decimeter a, Decimeter b) => a.m_value != b.m_value;
        // ****
        public static bool operator <(Decimeter a, Decimeter b) => a.m_value < b.m_value;
        public static bool operator >(Decimeter a, Decimeter b) => a.m_value > b.m_value;
        public static bool operator <=(Decimeter a, Decimeter b) => a.m_value <= b.m_value;
        public static bool operator >=(Decimeter a, Decimeter b) => a.m_value >= b.m_value;

        public bool Equals(Decimeter m)
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
        public int CompareTo(Decimeter other)
        {
            return this.m_value.CompareTo(other.m_value);
        }
    }
}

