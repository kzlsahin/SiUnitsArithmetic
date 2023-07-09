using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    internal class NestedUnit<T, U> : SiUnit
        where T : PrimitiveUnit<T>, new()
        where U : NestedUnit<T, U>
    {
        private int _exponent;
        public double Value { get; internal set; }
        protected static int _dimension = 2;
        internal override int Dimension { get { return _dimension; } }

        public override string symbol
        {
            get
            {
                return string.Empty;
            }
        }

        public NestedUnit(PrimitiveUnit<T> prime, NestedUnit<T, U> combined)
        {
            _dimension = prime.Dimension + combined.Dimension;
            _exponent = prime.Exponent * prime.Exponent;

        }
        internal override int Exponent { get { return _exponent; } }

        public NestedUnit() { }
    }
}
