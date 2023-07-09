using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIUnits.Length
{
    [SiSymbol("cm")]
    public class Centimeter :
        PrimitiveUnit<Centimeter>,
        IComparable<Centimeter>,
        ISiLength
    {
        internal static string _symbol = "m";
        public override string symbol => Centimeter._symbol;
        protected override int _exponent => -2;

        public Centimeter() { }
        public Centimeter(double value) : base(value) { }

        public static implicit operator Centimeter(Meter m)
        {
            return new Centimeter(m.m_value * 100);
        }
        public static implicit operator Meter(Centimeter cm)
        {
            return new Meter(cm.m_value / 100);
        }
        public static SqCentimeter operator *(Centimeter a, Centimeter b) => new SqCentimeter(a.m_value * b.m_value);
        public static Double operator /(Centimeter a, Centimeter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return a.m_value / b.m_value;
        }
        public static Centimeter operator +(Centimeter a, Centimeter b) => new Centimeter(a.m_value + b.m_value);

        public static Centimeter operator -(Centimeter a, Centimeter b) => new Centimeter(a.m_value - b.m_value);


        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Centimeter a, Centimeter b) => a.m_value == b.m_value;
        public static bool operator !=(Centimeter a, Centimeter b) => a.m_value != b.m_value;
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
