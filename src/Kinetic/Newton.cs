using SIUnits;
using System;
using System.Collections.Generic;
using System.Text;
using DegreePair = System.Collections.Generic.KeyValuePair<System.Guid, int>;

namespace SIUnits
{
    /// <summary>
    /// A unit of force derived from DerievedUnit in kg.m/s2.
    /// </summary>
    public sealed class Newton : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(new DegreePair(MetricLength.ID, 1), new DegreePair(MetricTime.ID, -2), new DegreePair(MetricMass.ID, 1));
        
        Newton(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit) : base(lengthUnit.m(), timeUnit.second(), massUnit.kg(), Ampere.ScalerOne)
        {
        }
        /// <summary>
        /// initializes a Newton type DerivedUnit in kg.m/s2.
        /// </summary>
        /// <param name="lengthUnit"></param>
        /// <param name="timeUnit"></param>
        /// <param name="massUnit"></param>
        public static new Newton New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            return new Newton(lengthUnit, timeUnit, massUnit);
        }
        /// <summary>
        /// converts a derived unit into Newton if the derivedunit is in mass*length/time^2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <param name="newton"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out Newton newton)
        {
            if (derivedUnit.Degree == Newton.refDegree)
            {
                newton = new Newton(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit);
                return true;
            }
            newton = null;
            return false;
        }
        /// <summary>
        /// converts a derived unit into Newton if the derivedunit is in mass*length/time^2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <returns>Return new Newton object or null</returns>
        public Newton Convert(DerivedUnit derivedUnit)
        {
            Newton newton;
            if (derivedUnit.Degree == Newton.refDegree)
            {
                newton = new Newton(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit);
                return newton;
            }
            newton = null;
            return newton;
        }
    }
}
