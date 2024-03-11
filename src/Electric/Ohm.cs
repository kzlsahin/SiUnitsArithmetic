using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// A unit of Electric potential difference, Joule per coulomb derived from DerievedUnit in kg⋅m2 /s3⋅A2.
    /// </summary>
    public sealed class Ohm : DerivedUnit
    {
        internal readonly static DerivedDegree refDegree = new DerivedDegree(
            new KeyValuePair<Guid, int>(MetricLength.ID, 2),
            new KeyValuePair<Guid, int>(MetricTime.ID, -3),
            new KeyValuePair<Guid, int>(MetricMass.ID, 1),
            new KeyValuePair<Guid, int>(Ampere.ID, -2)
            );

        Ohm(params IBasicUnit[] units) : base(units)
        {
        }
        /// <summary>
        /// initializes a Ohm type DerivedUnit in kg.m/s2.A2.
        /// </summary>
        internal static new Ohm New(Dictionary<Guid, IBasicUnit> memberUnits)
        {
            Ohm ohm;
            if (
                memberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                memberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                memberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit) &&
                memberUnits.TryGetValue(Ampere.ID, out IBasicUnit a_unit)
                )
            {
                ohm = new Ohm((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit, (Ampere)a_unit);
                return ohm;
            }
            return null;
        }
        /// <summary>
        /// initializes a Ohm type DerivedUnit in kg.m/s2.A2.
        /// </summary>
        public static Ohm New(double value)
        {
            var l_unit = (value).m(2);
            var t_unit = 1.second(-3);
            var m_unit = 1.kg();
            var a_unit = 1.A(-2);
            return new Ohm(l_unit, t_unit, m_unit, a_unit);
        }
        
        /// <summary>
        /// converts a derived unit into Ohm if the derivedunit is in kg⋅m2/s3⋅A2.
        /// </summary>
        /// <param name="derivedUnit"></param>
        /// <param name="ohm"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out Ohm ohm)
        {
            if (derivedUnit.Degree == Ohm.refDegree)
            {
                if(
                derivedUnit.MemberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit) &&
                derivedUnit.MemberUnits.TryGetValue(Ampere.ID, out IBasicUnit a_unit)
                )
                {
                    ohm = new Ohm((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit, (Ampere)a_unit);
                    return true;
                }                
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
            Ohm ohm = null;
            if (derivedUnit.Degree == Ohm.refDegree)
            {
                if (
                derivedUnit.MemberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit) &&
                derivedUnit.MemberUnits.TryGetValue(Ampere.ID, out IBasicUnit a_unit)
                )
                {
                    ohm = new Ohm((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit, (Ampere)a_unit);
                }
            }
            return ohm;
        }
    }
}
