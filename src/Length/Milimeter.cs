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
        protected override int Exponent => -3;

        public Milimeter() { }
        public Milimeter(double value) : base(value) { }

        public static implicit operator Milimeter(Meter m)
        {
            return new Milimeter(m.Value * 1000);
        }
        public static implicit operator Meter(Milimeter mm)
        {
            return new Meter(mm.Value / 1000);
        }
        public static SqMilimeter operator *(Milimeter a, Milimeter b) => new SqMilimeter(a.Value * b.Value);
        public static Double operator /(Milimeter a, Milimeter b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            return a.Value / b.Value;
        }
        public static Milimeter operator +(Milimeter a, Milimeter b) => new Milimeter(a.Value + b.Value);

        public static Milimeter operator -(Milimeter a, Milimeter b) => new Milimeter(a.Value - b.Value);


        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Milimeter a, Milimeter b) => a.Value == b.Value;
        public static bool operator !=(Milimeter a, Milimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Milimeter a, Milimeter b) => a.Value < b.Value;
        public static bool operator >(Milimeter a, Milimeter b) => a.Value > b.Value;
        public static bool operator <=(Milimeter a, Milimeter b) => a.Value <= b.Value;
        public static bool operator >=(Milimeter a, Milimeter b) => a.Value >= b.Value;

        public bool Equals(Milimeter m)
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
        public int CompareTo(Milimeter other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
