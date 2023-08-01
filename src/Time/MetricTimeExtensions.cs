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
            return DerivedUnit.New(t);
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
        /// <summary>
        /// Converts MetricTime unit into specified unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="unit"></param>
        /// <param name="degree"></param>
        /// <returns>if the unit of MetricTime is not specified unit, returns a new MetricTime in specified unit.</returns>
        public static MetricTime MetricTime(this MetricTime a, SiTimeUnits unit)
        {
            double value = a.GetValueBy(unit);
            return new MetricTime(value, a.Degree, unit);
        }
        /// <summary>
        /// Converts MetricTime unit into milisecond.
        /// </summary>
        /// <param name="a">if the unit of MetricTime is not milisecond, returns a new MetricTime in milisecond.</param>
        /// <returns></returns>
        public static MetricTime msec(this MetricTime a)
        {
            if (a.Unit == SiTimeUnits.milisecond)
                return a;
            double value = a.GetValueBy(SiTimeUnits.milisecond);
            return new MetricTime(value, a.Degree, SiTimeUnits.milisecond);
        }
        /// <summary>
        /// Converts MetricTime unit into milisecond.
        /// </summary>
        /// <param name="a">if the unit of MetricTime is not milisecond, returns a new MetricTime in milisecond.</param>
        /// <returns></returns>
        public static MetricTime milisecond(this MetricTime a)
        {
            if (a.Unit == SiTimeUnits.milisecond)
                return a;
            double value = a.GetValueBy(SiTimeUnits.milisecond);
            return new MetricTime(value, a.Degree, SiTimeUnits.milisecond);
        }
        /// <summary>
        /// Converts MetricTime unit into second.
        /// </summary>
        /// <param name="a">if the unit of MetricTime is not second, returns a new MetricTime in second.</param>
        /// <returns></returns>
        public static MetricTime sec(this MetricTime a)
        {
            if (a.Unit == SiTimeUnits.second)
                return a;
            double value = a.GetValueBy(SiTimeUnits.second);
            return new MetricTime(value, a.Degree, SiTimeUnits.second);
        }
        /// <summary>
        /// Converts MetricTime unit into second.
        /// </summary>
        /// <param name="a">if the unit of MetricTime is not second, returns a new MetricTime in second.</param>
        /// <returns></returns>
        public static MetricTime second(this MetricTime a)
        {
            if (a.Unit == SiTimeUnits.second)
                return a;
            double value = a.GetValueBy(SiTimeUnits.second);
            return new MetricTime(value, a.Degree, SiTimeUnits.second);
        }
        /// <summary>
        /// Converts MetricTime unit into hour.
        /// </summary>
        /// <param name="a">if the unit of MetricTime is not hour, returns a new MetricTime in hour.</param>
        /// <returns></returns>
        public static MetricTime hour(this MetricTime a)
        {
            if (a.Unit == SiTimeUnits.hour)
                return a;
            double value = a.GetValueBy(SiTimeUnits.hour);
            return new MetricTime(value, a.Degree, SiTimeUnits.hour);
        }
        /// <summary>
        /// Converts MetricTime unit into minute.
        /// </summary>
        /// <param name="a">if the unit of MetricTime is not minute, returns a new MetricTime in minute.</param>
        /// <returns></returns>
        public static MetricTime minute(this MetricTime a)
        {
            if (a.Unit == SiTimeUnits.minute)
                return a;
            double value = a.GetValueBy(SiTimeUnits.minute);
            return new MetricTime(value, a.Degree, SiTimeUnits.minute);
        }
    }
}
