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
        internal readonly static DerivedDegree refDegree = new DerivedDegree(
            new KeyValuePair<Guid, int>(MetricLength.ID, 1),
            new KeyValuePair<Guid, int>(MetricTime.ID, -2),
            new KeyValuePair<Guid, int>(MetricMass.ID, 1)
            );
        Newton(params IBasicUnit[] units) : base(units)
        {
        }
        /// <summary>
        /// initializes a Newton type DerivedUnit in kg.m/s2.
        /// </summary>
        /// <param name="memberUnits"></param>
        /// <remarks>Check degrees before calling this method!</remarks>
        /// <returns></returns>
        internal static new Newton New(Dictionary<Guid, IBasicUnit> memberUnits)
        {
            Newton newton;
            if (
                memberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                memberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                memberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit)
                )
            {
                newton = new Newton((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit);
                return newton;
            }
            return null;
        }
        /// <summary>
        /// initializes a Newton type DerivedUnit in kg.m/s2.
        /// </summary>
        public static Newton New(double value)
        {
            var l_unit = (value).m(1);
            var t_unit = 1.second(-2);
            var m_unit = 1.kg(1);
            return new Newton(l_unit, t_unit, m_unit);
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
                if (
                derivedUnit.MemberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit)
                )
                {
                    newton = new Newton((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit);
                    return true;
                }
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
            Newton newton = null;
            if (derivedUnit.Degree == Newton.refDegree)
            {
                if (
                derivedUnit.MemberUnits.TryGetValue(MetricLength.ID, out IBasicUnit l_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricTime.ID, out IBasicUnit t_unit) &&
                derivedUnit.MemberUnits.TryGetValue(MetricMass.ID, out IBasicUnit m_unit)
                )
                {
                    newton = new Newton((MetricLength)l_unit, (MetricTime)t_unit, (MetricMass)m_unit);
                }
            }
            return newton;
        }
    }
}
