using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public class Force : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(1, -2, 1);
        public Force(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit) : base(lengthUnit, timeUnit, massUnit)
        {
        }
    }
}
