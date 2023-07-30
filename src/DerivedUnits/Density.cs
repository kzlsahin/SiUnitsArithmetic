using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public class Density : DerivedUnit
    {
        /// <summary>
        /// represents a density such as kg/m3 or g/cm3.
        /// </summary>
        /// <param name="lengthUnit"></param>
        /// <param name="massUnit"></param>
        public Density(MetricLength lengthUnit, MetricMass massUnit) : base(lengthUnit, new MetricTime(1, 0, SiTimeUnits.second), massUnit)
        {
        }        
        internal readonly static DerivedDegree refDegree = new DerivedDegree(-3, 0, 1);
    }
}
