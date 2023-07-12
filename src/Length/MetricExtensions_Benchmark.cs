using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
#if BENCHMARK
namespace SIUnits.Length
{
    public static class MetricExtensionsClass
    {
        public static MetricLengthClass mc(this int a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.metre);
        }
        public static MetricLengthClass mmc(this int a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.milimetre);
        }
        public static MetricLengthClass cmc(this int a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.centimetre);
        }
        public static MetricLengthClass dmc(this int a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.decimetre);
        }
        public static MetricLengthClass kmc(this int a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.kilometre);
        }
        public static MetricLengthClass metricc(this int a, SiMetricUnits unit, int degree)
        {
            return new MetricLengthClass(a, degree, unit);
        }
        public static MetricLengthClass mc(this double a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.metre);
        }
        public static MetricLengthClass mmc(this double a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.milimetre);
        }
        public static MetricLengthClass cmc(this double a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.centimetre);
        }
        public static MetricLengthClass dmc(this double a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.decimetre);
        }
        public static MetricLengthClass kmc(this double a, int degree = 1)
        {
            return new MetricLengthClass(a, degree, SiMetricUnits.kilometre);
        }
        public static MetricLengthClass metricc(this double a, SiMetricUnits unit, int degree)
        {
            return new MetricLengthClass(a, degree, unit);
        }
        public static MetricLengthClass mc(this MetricLengthClass a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.metre, a.Degree);
            return new MetricLengthClass(value, a.Degree, SiMetricUnits.metre);
        }
        public static MetricLengthClass mmc(this MetricLengthClass a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.milimetre, a.Degree);
            return new MetricLengthClass(value, a.Degree, SiMetricUnits.milimetre);
        }
        public static MetricLengthClass cmc(this MetricLengthClass a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.centimetre, a.Degree);
            return new MetricLengthClass(value, a.Degree, SiMetricUnits.centimetre);
        }
        public static MetricLengthClass dmc(this MetricLengthClass a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.decimetre, a.Degree);
            return new MetricLengthClass(value, a.Degree, SiMetricUnits.decimetre);
        }
        public static MetricLengthClass kmc(this MetricLengthClass a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.kilometre, a.Degree);
            return new MetricLengthClass(value, a.Degree, SiMetricUnits.kilometre);
        }
        public static MetricLengthClass metricc(this MetricLengthClass a, SiMetricUnits unit, int degree)
        {
            double value = a.GetMetre().GetUnitValue(unit, a.Degree);
            return new MetricLengthClass(value, a.Degree, unit);
        }
    }
}
#endif