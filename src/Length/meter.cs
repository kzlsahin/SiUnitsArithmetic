using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIUnits.Length
{
    [SiSymbol("m")]
    public class Meter :
        PrimitiveUnit<Meter>,
        IComparable<Meter>,
        ISiLength
    {
        private static int _exponent = 1;

        internal static string _symbol = "m";
        public override string symbol => Meter._symbol;
        internal override int Exponent { get { return _exponent; } }

        public Meter() { }
        public Meter(double value) : base(value) { }

        public static SqMeter operator *(Meter a, Meter b) => new SqMeter(a.Value * b.Value);
        public static Double operator /(Meter a, Meter b)
        {
            if (b.Value == 0) throw new DivideByZeroException();
            return a.Value / b.Value;
        }
        public static Meter operator +(Meter a, Meter b) => new Meter(a.Value + b.Value);
       
       public static Meter operator -(Meter a, Meter b) => new Meter(a.Value - b.Value);
        
       
        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Meter a, Meter b) => a.Value == b.Value;
        public static bool operator !=(Meter a, Meter b) => a.Value != b.Value;
        // ****
        public static bool operator <(Meter a, Meter b) => a.Value < b.Value;
        public static bool operator >(Meter a, Meter b) => a.Value > b.Value;
        public static bool operator <=(Meter a, Meter b) => a.Value <= b.Value;
        public static bool operator >=(Meter a, Meter b) => a.Value >= b.Value;
        
        public bool Equals(Meter m)
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

        public int CompareTo(Meter other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
