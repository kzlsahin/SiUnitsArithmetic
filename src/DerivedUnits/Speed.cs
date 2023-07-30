using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public class Speed : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(1, -1, 0);
        public Speed(MetricLength lengthUnit, MetricTime timeUnit) : base(lengthUnit, timeUnit, new MetricMass(1, 0, SiMassUnits.kilogram))
        {
        }
    }
}
