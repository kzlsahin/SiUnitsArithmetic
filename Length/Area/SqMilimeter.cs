using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Length
{
    public class SqMilimeter : Area<Milimeter>
    {
        protected static int _exponent = 6;
        public SqMilimeter(double value) : base(value)
        {

        }
        public static implicit operator SqMilimeter(SqMeter m)
        {
            return new SqMilimeter(m.a_value * Math.Pow(10, _exponent));
        }
        public static implicit operator SqMeter(SqMilimeter mm)
        {
            return new SqMeter(mm.a_value / Math.Pow(10, _exponent));
        }
    }
}
