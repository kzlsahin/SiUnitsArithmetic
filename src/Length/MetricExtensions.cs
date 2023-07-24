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
        public static MetricLength metric(this int a, SiMetricUnits unit, int degree)
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
        public static MetricLength metric(this double a, SiMetricUnits unit, int degree)
        {
            return new MetricLength(a, degree, unit);
        }
        public static MetricLength m(this MetricLength a)
        {
            double value = a.GetValueBy(SiMetricUnits.metre);
            return new MetricLength(value, a.Degree, SiMetricUnits.metre);
        }
        public static MetricLength mm(this MetricLength a)
        {
            double value = a.GetValueBy(SiMetricUnits.milimetre);
            return new MetricLength(value, a.Degree, SiMetricUnits.milimetre);
        }
        public static MetricLength cm(this MetricLength a)
        {
            double value = a.GetValueBy(SiMetricUnits.centimetre);
            return new MetricLength(value, a.Degree, SiMetricUnits.centimetre);
        }
        public static MetricLength dm(this MetricLength a)
        {
            double value = a.GetValueBy(SiMetricUnits.decimetre);
            return new MetricLength(value, a.Degree, SiMetricUnits.decimetre);
        }
        public static MetricLength km(this MetricLength a)
        {
            double value = a.GetValueBy(SiMetricUnits.kilometre);
            return new MetricLength(value, a.Degree, SiMetricUnits.kilometre);
        }
        public static MetricLength metric(this MetricLength a, SiMetricUnits unit, int degree)
        {
            double value = a.GetValueBy(unit);
            return new MetricLength(value, a.Degree, unit);
        }
    }
}
