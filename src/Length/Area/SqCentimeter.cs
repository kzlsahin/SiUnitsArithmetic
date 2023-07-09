using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Length
{
    public class SqCentimeter : Area<Centimeter>
    {
        protected static int _exponent = 4;
        public SqCentimeter(double value) : base(value)
        {

        }
        public static implicit operator SqCentimeter(SqMeter m)
        {
            return new SqCentimeter(m.a_value * Math.Pow(10, _exponent));
        }
        public static implicit operator SqMeter(SqCentimeter mm)
        {
            return new SqMeter(mm.a_value / Math.Pow(10, _exponent));
        }
    }
}
