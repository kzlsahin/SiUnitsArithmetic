using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public static class MetricExtensions
    {
        /// <summary>
        /// Converts into a derived unit type
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static DerivedUnit ToCompositeUnit(this MetricLength l)
        {
            return new DerivedUnit(l);
        }
        public static MetricLength m(this int a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.metre);
        }
        public static MetricLength mm(this int a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.milimetre);
        }
        public static MetricLength cm(this int a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.centimetre);
        }
        public static MetricLength dm(this int a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.decimetre);
        }
        public static MetricLength km(this int a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.kilometre);
        }
        public static MetricLength MetricLength(this int a, SiMetricUnits unit, int degree)
        {
            return new MetricLength(a, degree, unit);
        }
        public static MetricLength m(this double a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.metre);
        }
        public static MetricLength mm(this double a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.milimetre);
        }
        public static MetricLength cm(this double a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.centimetre);
        }
        public static MetricLength dm(this double a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.decimetre);
        }
        public static MetricLength km(this double a, int degree = 1)
        {
            return new MetricLength(a, degree, SiMetricUnits.kilometre);
        }
        public static MetricLength MetricLength(this double a, SiMetricUnits unit, int degree)
        {
            return new MetricLength(a, degree, unit);
        }
        /// <summary>
        /// Converts MetricLength unit into metre.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of MetricLength is not metre, returns a new MetricLength in metre.</returns>
        public static MetricLength m(this MetricLength a)
        {
            if (a.Unit == SiMetricUnits.metre)
                return a;
            double value = a.GetValueBy(SiMetricUnits.metre);
            return new MetricLength(value, a.Degree, SiMetricUnits.metre);
        }
        /// <summary>
        /// Converts MetricLength unit into milimetre.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of MetricLength is not milimetre, returns a new MetricLength in milimetre.</returns>
        public static MetricLength mm(this MetricLength a)
        {
            if (a.Unit == SiMetricUnits.milimetre)
                return a;
            double value = a.GetValueBy(SiMetricUnits.milimetre);
            return new MetricLength(value, a.Degree, SiMetricUnits.milimetre);
        }
        /// <summary>
        /// Converts MetricLength unit into centimetre.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of MetricLength is not centimetre, returns a new MetricLength in centimetre.</returns>
        public static MetricLength cm(this MetricLength a)
        {
            if (a.Unit == SiMetricUnits.centimetre)
                return a;
            double value = a.GetValueBy(SiMetricUnits.centimetre);
            return new MetricLength(value, a.Degree, SiMetricUnits.centimetre);
        }
        /// <summary>
        /// Converts MetricLength unit into decimetre.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of MetricLength is not decimetre, returns a new MetricLength in decimetre.</returns>
        public static MetricLength dm(this MetricLength a)
        {
            if (a.Unit == SiMetricUnits.decimetre)
                return a;
            double value = a.GetValueBy(SiMetricUnits.decimetre);
            return new MetricLength(value, a.Degree, SiMetricUnits.decimetre);
        }
        /// <summary>
        /// Converts MetricLength unit into kilometre.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of MetricLength is not kilometre, returns a new MetricLength in kilometre.</returns>
        public static MetricLength km(this MetricLength a)
        {
            if (a.Unit == SiMetricUnits.kilometre)
                return a;
            double value = a.GetValueBy(SiMetricUnits.kilometre);
            return new MetricLength(value, a.Degree, SiMetricUnits.kilometre);
        }
        /// <summary>
        /// Converts MetricLength unit into specified unit.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of MetricLength is specified unit, returns a new MetricLength in specified unit.</returns>
        public static MetricLength MetricLength(this MetricLength a, SiMetricUnits unit, int degree)
        {
            if (a.Unit == unit)
                return a;
            double value = a.GetValueBy(unit);
            return new MetricLength(value, a.Degree, unit);
        }
    }
}
