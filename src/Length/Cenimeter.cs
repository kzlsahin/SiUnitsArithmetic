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
        protected override int Exponent => -2;

        public Centimeter() { }
        public Centimeter(double value) : base(value) { }

        public static implicit operator Centimeter(Meter m)
        {
            return new Centimeter(m.Value * 100);
        }
        public static implicit operator Meter(Centimeter cm)
        {
            return new Meter(cm.Value / 100);
        }
        public static SqCentimeter operator *(Centimeter a, Centimeter b) => new SqCentimeter(a.Value * b.Value);
        public static Double operator /(Centimeter a, Centimeter b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            return a.Value / b.Value;
        }
        public static Centimeter operator +(Centimeter a, Centimeter b) => new Centimeter(a.Value + b.Value);

        public static Centimeter operator -(Centimeter a, Centimeter b) => new Centimeter(a.Value - b.Value);


        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Centimeter a, Centimeter b) => a.Value == b.Value;
        public static bool operator !=(Centimeter a, Centimeter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Centimeter a, Centimeter b) => a.Value < b.Value;
        public static bool operator >(Centimeter a, Centimeter b) => a.Value > b.Value;
        public static bool operator <=(Centimeter a, Centimeter b) => a.Value <= b.Value;
        public static bool operator >=(Centimeter a, Centimeter b) => a.Value >= b.Value;

        public bool Equals(Centimeter m)
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
        public int CompareTo(Centimeter other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
