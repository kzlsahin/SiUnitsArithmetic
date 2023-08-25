﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// to extend DerivedUnit class.
    /// </summary>
    public abstract class CustomSpecialUnit<T> : DerivedUnit where T: CustomSpecialUnit<T>
    {
        protected CustomSpecialUnit(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit, double scaler) : base(l_unit * scaler, t_unit, m_unit, a_unit)
        {

        }
        protected CustomSpecialUnit(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, double scaler) : base(l_unit * scaler, t_unit, m_unit, Ampere.ScalerOne)
        {

        }
        /// <summary>
        /// registers the defined cutsom special units. So that, the DerivedUnits with the proper unit pattern will be created as the custom unit.
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public static bool RegisterSpecialUnit(DerivedDegree degree, Func<MetricLength, MetricTime, MetricMass, Ampere, CustomSpecialUnit<T>> constructor)
        {
            refDegree = degree;
            return SpecialUnitMap.Instance.RegisterSpecialUnit(degree, constructor);
        }
        /// <summary>
        /// reference degree of type DerivedDegree, representing the unit pattern of the custom unit.
        /// </summary>
        protected static DerivedDegree refDegree;

        /// <summary>
        /// Use this method as a public constructor.
        /// </summary>
        /// <param name="l_unit"></param>
        /// <param name="t_unit"></param>
        /// <param name="m_unit"></param>
        /// <param name="a_unit"></param>
        /// <returns></returns>
        protected abstract T New(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit);
    }
}
