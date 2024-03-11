using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// A unit of force derived from DerievedUnit in kg.m2/s2.
    /// </summary>
    public sealed class Joule : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(2, -2, 1, 0);
        
        Joule(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit, Ampere ampereUnit) : base(lengthUnit.m(), timeUnit.second(), massUnit.kg(), ampereUnit)
        {
        }
        /// <summary>
        /// initializes a Joule type DerivedUnit in kg.m2/s2.
        /// </summary>
        /// <param name="lengthUnit"></param>
        /// <param name="timeUnit"></param>
        /// <param name="massUnit"></param>
        public static new Joule New(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit, Ampere ampereUnit)
        {
            return new Joule(lengthUnit, timeUnit, massUnit, ampereUnit);
        }
        /// <summary>
        /// converts a derived unit into Joule if the derivedunit is in mass*length^2/time^2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <param name="Joule"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out Joule Joule)
        {
            if (derivedUnit.Degree == Joule.refDegree)
            {
                Joule = new Joule(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit, derivedUnit.a_unit);
                return true;
            }
            Joule = null;
            return false;
        }
        /// <summary>
        /// converts a derived unit into Joule if the derivedunit is in mass*length^2/time^2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <returns>Returns a new Joule object or null</returns>
        public Joule Convert(DerivedUnit derivedUnit)
        {
            Joule joule;
            if (derivedUnit.Degree == Joule.refDegree)
            {
                joule = new Joule(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit, derivedUnit.a_unit);
                return joule;
            }
            joule = null;
            return joule;
        }
    }
}
