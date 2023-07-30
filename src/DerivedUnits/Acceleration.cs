using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public class Acceleration : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(1, -2, 0);
        public Acceleration(MetricLength lengthUnit, MetricTime timeUnit) : base(lengthUnit, timeUnit, new MetricMass(1, 0, SiMassUnits.kilogram))
        {
        }
    }
}
