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
        protected override int Exponent => -1;

        public Decimeter() { }
        public Decimeter(double value) : base(value) { }

        public static implicit operator Decimeter(Meter m)
        {
            return new Decimeter(m.Value * 10);
        }
        public static implicit operator Meter(Decimeter dm)
        {
            return new Meter(dm.Value / 10);
        }
        public static SqDecimeter operator *(Decimeter a, Decimeter b) => new SqDecimeter(a.Value * b.Value);
        public static Double operator /(Decimeter a, Decimeter b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            return a.Value / b.Value;
        }
        public static Decimeter operator +(Decimeter a, Decimeter b) => new Decimeter(a.Value + b.Value);

        public static Decimeter operator -(Decimeter a, Decimeter b) => new Decimeter(a.Value - b.Value);


        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Decimeter a, Decimeter b) => a.Value == b.Value;
        public static bool operator !=(Decimeter a, Decimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Decimeter a, Decimeter b) => a.Value < b.Value;
        public static bool operator >(Decimeter a, Decimeter b) => a.Value > b.Value;
        public static bool operator <=(Decimeter a, Decimeter b) => a.Value <= b.Value;
        public static bool operator >=(Decimeter a, Decimeter b) => a.Value >= b.Value;

        public bool Equals(Decimeter m)
        {
            return this.Value == m.Value;
        }
        public override string ToString()
        {
            return $"{this.Value} {_symbol}";
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
        public int CompareTo(Decimeter other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}

