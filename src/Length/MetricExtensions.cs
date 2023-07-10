using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Length
{
    public static class MetricExtensions
    {
        public static Metric m(this int a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.metre);
        }
        public static Metric mm(this int a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.milimetre);
        }
        public static Metric cm(this int a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.centimetre);
        }
        public static Metric dm(this int a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.decimetre);
        }
        public static Metric km(this int a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.kilometre);
        }
        public static Metric metric(this int a, SiMetricUnits unit, int degree)
        {
            return new Metric(a, degree, unit);
        }
        public static Metric m(this double a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.metre);
        }
        public static Metric mm(this double a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.milimetre);
        }
        public static Metric cm(this double a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.centimetre);
        }
        public static Metric dm(this double a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.decimetre);
        }
        public static Metric km(this double a, int degree = 1)
        {
            return new Metric(a, degree, SiMetricUnits.kilometre);
        }
        public static Metric metric(this double a, SiMetricUnits unit, int degree)
        {
            return new Metric(a, degree, unit);
        }
        public static Metric m(this Metric a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.metre, a.Degree);
            return new Metric(value, a.Degree, SiMetricUnits.metre);
        }
        public static Metric mm(this Metric a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.milimetre, a.Degree);
            return new Metric(value, a.Degree, SiMetricUnits.milimetre);
        }
        public static Metric cm(this Metric a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.centimetre, a.Degree);
            return new Metric(value, a.Degree, SiMetricUnits.centimetre);
        }
        public static Metric dm(this Metric a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.decimetre, a.Degree);
            return new Metric(value, a.Degree, SiMetricUnits.decimetre);
        }
        public static Metric km(this Metric a)
        {
            double value = a.GetMetre().GetUnitValue(SiMetricUnits.kilometre, a.Degree);
            return new Metric(value, a.Degree, SiMetricUnits.kilometre);
        }
        public static Metric metric(this Metric a, SiMetricUnits unit, int degree)
        {
            double value = a.GetMetre().GetUnitValue(unit, a.Degree);
            return new Metric(value, a.Degree, unit);
        }
    }
}
