using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// A unit of Electric potential difference, Joule per coulomb derived from DerievedUnit in kg⋅m2⋅s−3⋅A−1.
    /// </summary>
    public sealed class Volt : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(2, -3, 1, -1);

        Volt(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit) : base(lengthUnit.m(), timeUnit.second(), massUnit.kg(), Ampere.ScalerOne)
        {
        }
        /// <summary>
        /// initializes a Volt type DerivedUnit in kg.m/s2.
        /// </summary>
        /// <param name="lengthUnit"></param>
        /// <param name="timeUnit"></param>
        /// <param name="massUnit"></param>
        public static new Volt New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            return new Volt(lengthUnit, timeUnit, massUnit);
        }
        /// <summary>
        /// converts a derived unit into Volt if the derivedunit is in kg⋅m2⋅s−3⋅A−1.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <param name="volt"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out Volt volt)
        {
            if (derivedUnit.Degree == Volt.refDegree)
            {
                volt = new Volt(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit);
                return true;
            }
            volt = null;
            return false;
        }
        /// <summary>
        /// converts a derived unit into Volt if the derivedunit is in kg⋅m2⋅s−3⋅A−1.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <returns></returns>
        public Volt Convert(DerivedUnit derivedUnit)
        {
            Volt volt;
            if (derivedUnit.Degree == Volt.refDegree)
            {
                volt = new Volt(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit);
                return volt;
            }
            volt = null;
            return volt;
        }
    }
}
