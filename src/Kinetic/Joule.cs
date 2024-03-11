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
        internal readonly static DerivedDegree refDegree = new DerivedDegree(
            new KeyValuePair<Guid, int>(MetricLength.ID, 2),
            new KeyValuePair<Guid, int>(MetricTime.ID, -2),
            new KeyValuePair<Guid, int>(MetricMass.ID, 1)
            );
        Joule(params IBasicUnit[] units) : base(units)
        {
        }
        /// <summary>
        /// initializes a Joule type DerivedUnit in kg.m2/s2.
        /// </summary>
        /// <param name="memberUnits"></param>
        /// <returns></returns>
        internal static new Joule New(Dictionary<Guid, IBasicUnit> memberUnits)
        {
            Joule joule;
            if (
                memberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                memberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                memberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit)
                )
            {
                joule = new Joule((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit);
                return joule;
            }
            return null;
        }
        /// <summary>
        /// initializes a Joule type DerivedUnit in kg.m2/s2.
        /// </summary>
        public static Joule New(double value)
        {
            var l_unit = (value).m(2);
            var t_unit = 1.second(-2);
            var m_unit = 1.kg(1);
            return new Joule(l_unit, t_unit, m_unit);
        }
        /// <summary>
        /// converts a derived unit into Joule if the derivedunit is in mass*length^2/time^2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <param name="Joule"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out Joule joule)
        {
            if (derivedUnit.Degree == Joule.refDegree)
            {
                if (
                derivedUnit.MemberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit)
                )
                {
                    joule = new Joule((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit);
                    return true;
                }
            }
            joule = null;
            return false;
        }
        /// <summary>
        /// converts a derived unit into Joule if the derivedunit is in mass*length^2/time^2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <returns>Returns a new Joule object or null</returns>
        public Joule Convert(DerivedUnit derivedUnit)
        {
            Joule joule = null;
            if (derivedUnit.Degree == Joule.refDegree)
            {
                if (
                derivedUnit.MemberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit)
                )
                {
                    joule = new Joule((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit);
                }
            }
            return joule;
        }
    }
}
