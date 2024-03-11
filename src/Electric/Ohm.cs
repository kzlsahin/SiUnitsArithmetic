using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// A unit of Electric potential difference, Joule per coulomb derived from DerievedUnit in kg⋅m2⋅s−3⋅A−2.
    /// </summary>
    public sealed class Ohm : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(2, -3, 1, -2);

        Ohm(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit, Ampere ampereUnit) : base(lengthUnit.m(), timeUnit.second(), massUnit.kg(), ampereUnit)
        {
        }
        /// <summary>
        /// initializes a Ohm type DerivedUnit in kg.m/s2.
        /// </summary>
        /// <param name="lengthUnit"></param>
        /// <param name="timeUnit"></param>
        /// <param name="massUnit"></param>
        public static new Ohm New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit, Ampere ampereUnit)
        {
            return new Ohm(lengthUnit, timeUnit, massUnit, ampereUnit);
        }
        /// <summary>
        /// converts a derived unit into Ohm if the derivedunit is in kg⋅m2⋅s−3⋅A−2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <param name="ohm"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out Ohm ohm)
        {
            if (derivedUnit.Degree == Ohm.refDegree)
            {
                ohm = new Ohm(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit, derivedUnit.a_unit);
                return true;
            }
            ohm = null;
            return false;
        }
        /// <summary>
        /// converts a derived unit into Ohm if the derivedunit is in kg⋅m2⋅s−3⋅A−1.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <returns></returns>
        public Ohm Convert(DerivedUnit derivedUnit)
        {
            Ohm ohm;
            if (derivedUnit.Degree == Ohm.refDegree)
            {
                ohm = new Ohm(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit, derivedUnit.a_unit);
                return ohm;
            }
            ohm = null;
            return ohm;
        }
    }
}
