using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public abstract class SiUnit
    {
        internal abstract int Dimension { get; }
        public abstract string symbol { get; }
        internal abstract int Exponent { get; }
    }
}
