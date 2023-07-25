using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public static class MetricTimeExtensions
    {
        /// <summary>
        /// Converts into a derived unit type
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DerivedUnit ToCompositeUnit(this MetricTime t)
        {
            return new DerivedUnit(t);
        }
        /// <summary>
        /// milisecond
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static MetricTime msec(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.milisecond);
        }
        /// <summary>
        /// milisecond
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
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
        public static MetricTime second(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.second);
        }
        public static MetricTime second(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.second);
        }
        public static MetricTime hour(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.hour);
        }
        public static MetricTime hour(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.hour);
        }
        public static MetricTime minute(this double a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.minute);
        }
        public static MetricTime minute(this int a, int degree = 1)
        {
            return new MetricTime(a, degree, SiTimeUnits.minute);
        }
        public static MetricTime MetricTime(this double a, SiTimeUnits unit, int degree = 1)
        {
            return new MetricTime(a, degree, unit);
        }
        public static MetricTime MetricTime(this int a, SiTimeUnits unit, int degree = 1)
        {
            return new MetricTime(a, degree, unit);
        }
        public static MetricTime MetricMass(this MetricTime a, SiTimeUnits unit, int degree = 1)
        {
            double value = a.GetValueBy(unit);
            return new MetricTime(value, a.Degree, unit);
        }
        /// <summary>
        /// milisecond
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static MetricTime msec(this MetricTime a)
        {
            double value = a.GetValueBy(SiTimeUnits.milisecond);
            return new MetricTime(value, a.Degree, SiTimeUnits.milisecond);
        }
        public static MetricTime milisecond(this MetricTime a)
        {
            double value = a.GetValueBy(SiTimeUnits.milisecond);
            return new MetricTime(value, a.Degree, SiTimeUnits.milisecond);
        }
        public static MetricTime sec(this MetricTime a)
        {
            double value = a.GetValueBy(SiTimeUnits.second);
            return new MetricTime(value, a.Degree, SiTimeUnits.second);
        }
        public static MetricTime second(this MetricTime a)
        {
            double value = a.GetValueBy(SiTimeUnits.second);
            return new MetricTime(value, a.Degree, SiTimeUnits.second);
        }
        public static MetricTime hour(this MetricTime a)
        {
            double value = a.GetValueBy(SiTimeUnits.hour);
            return new MetricTime(value, a.Degree, SiTimeUnits.hour);
        }
        public static MetricTime minute(this MetricTime a)
        {
            double value = a.GetValueBy(SiTimeUnits.minute);
            return new MetricTime(value, a.Degree, SiTimeUnits.minute);
        }
    }
}
