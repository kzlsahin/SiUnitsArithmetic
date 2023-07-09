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
        internal static string _symbol = "m";
        public override string symbol => Meter._symbol;
        protected override int _exponent => 0;

        public Meter() { }
        public Meter(double value) : base(value) { }

        public static SqMeter operator *(Meter a, Meter b) => new SqMeter(a.m_value * b.m_value);
        public static Double operator /(Meter a, Meter b)
        {
            if (b.m_value == 0) throw new DivideByZeroException();
            return a.m_value / b.m_value;
        }
        public static Meter operator +(Meter a, Meter b) => new Meter(a.m_value + b.m_value);
       
       public static Meter operator -(Meter a, Meter b) => new Meter(a.m_value - b.m_value);
        
       
        // **** when struct is defined as record these equality checks comes by default.
        public static bool operator ==(Meter a, Meter b) => a.m_value == b.m_value;
        public static bool operator !=(Meter a, Meter b) => a.m_value != b.m_value;
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
