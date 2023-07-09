using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public class SqDecimeter : Area<Decimeter>
    {
        protected static int _exponent = 2;
        public SqDecimeter(double value) : base(value)
        {

        }
        public static implicit operator SqDecimeter(SqMeter m)
        {
            return new SqDecimeter(m.Value * Math.Pow(10, _exponent));
        }
        public static implicit operator SqMeter(SqDecimeter mm)
        {
            return new SqMeter(mm.Value / Math.Pow(10, _exponent));
        }
    }
}
