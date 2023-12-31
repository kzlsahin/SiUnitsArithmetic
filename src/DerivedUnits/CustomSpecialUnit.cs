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
        /// <returns>True if successful, false otherwise.</returns>
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

        /// <summary>
        /// Converts a DerivedUnit to this type if the degree pattern of the DerivedUnit is compatible.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="derivedUnit"></param>
        /// <param name="specialUnit"></param>
        /// <returns></returns>
        public bool TryConvert(DerivedUnit derivedUnit, out T specialUnit)
        {
            if (derivedUnit.Degree == refDegree)
            {
                specialUnit = New(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit, derivedUnit.a_unit);
                return true;
            }
            specialUnit = null;
            return false;
        }
        /// <summary>
        /// Converts a DerivedUnit to this type if the degree pattern of the DerivedUnit is compatible.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="derivedUnit"></param>
        /// <param name="specialUnit"></param>
        /// <returns></returns>
        public T Convert(DerivedUnit derivedUnit)
        {
            T specialUnit;
            if (derivedUnit.Degree == refDegree)
            {
                specialUnit = New(derivedUnit.l_unit, derivedUnit.t_unit, derivedUnit.m_unit, derivedUnit.a_unit);
                return specialUnit;
            }
            specialUnit = null;
            return specialUnit;
        }
        protected abstract T New(MetricLength l_unit, MetricTime t_unit, MetricMass m_unit, Ampere a_unit);
    }
}
