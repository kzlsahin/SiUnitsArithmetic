using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Time
{
    public static class MetricTimeExtensions
    {
        public static MetricTime msec(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.milisecond);
        }
        public static MetricTime msec(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.milisecond);
        }
        public static MetricTime milisecond(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.milisecond);
        }
        public static MetricTime milisecond(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.milisecond);
        }
        public static MetricTime sec(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.second);
        }
        public static MetricTime sec(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.second);
        }
        public static MetricTime second(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.second);
        }
        public static MetricTime second(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.second);
        }

        public static MetricTime h(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.hour);
        }
        public static MetricTime h(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.hour);
        }
        public static MetricTime hour(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.hour);
        }
        public static MetricTime hour(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.hour);
        }

        public static MetricTime m(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.minute);
        }
        public static MetricTime m(this int a, int degree = 1)
        {   
            return new MetricTime(a, degree, SiTimeUnits.minute);
        }
        public static MetricTime minute(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.minute);
        }
        public static MetricTime minute(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.minute);
        }
        public static MetricTime metric(this double a, SiTimeUnits unit, int degree = 1)
        {
            return new MetricTime(a, degree, unit);
        }
        public static MetricTime msec(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.milisecond, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.milisecond);
        }
        public static MetricTime milisecond(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.milisecond, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.milisecond);
        }
        public static MetricTime sec(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.second, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.second);
        }
        public static MetricTime second(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.second, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.second);
        }

        public static MetricTime h(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.hour, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.hour);
        }
        public static MetricTime hour(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.hour, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.hour);
        }
        public static MetricTime m(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.minute, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.minute);
        }
        public static MetricTime minute(this MetricTime a, int degree = 1)
        {
            double value = a.GetSecond().GetUnitValue(SiTimeUnits.minute, a.Degree);
            return new MetricTime(value, degree, SiTimeUnits.minute);
        }
    }
}
