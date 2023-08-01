using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public static class MetricMassExtensions
    {
        /// <summary>
        /// Converts into a derived unit type
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static DerivedUnit ToCompositeUnit(this MetricMass m)
        {
            return DerivedUnit.New(m);
        }
        public static MetricMass mg(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.miligram);
        }
        public static MetricMass mg(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.miligram);
        }
        public static MetricMass miligram(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.miligram);
        }
        public static MetricMass miligram(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.miligram);
        }
        public static MetricMass g(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.gram);
        }
        public static MetricMass g(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.gram);
        }
        public static MetricMass gram(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.gram);
        }
        public static MetricMass gram(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.gram);
        }

        public static MetricMass kg(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.kilogram);
        }
        public static MetricMass kg(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.kilogram);
        }
        public static MetricMass kilogram(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.kilogram);
        }
        public static MetricMass kilogram(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.kilogram);
        }

        public static MetricMass t(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.tonne);
        }
        public static MetricMass t(this int a, int degree = 1)
        {   
            return new MetricMass(a, degree, SiMassUnits.tonne);
        }
        public static MetricMass tonne(this double a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.tonne);
        }
        public static MetricMass tonne(this int a, int degree = 1)
        {
            return new MetricMass(a, degree, SiMassUnits.tonne);
        }
        public static MetricMass MetricMass(this double a, SiMassUnits unit, int degree = 1)
        {
            return new MetricMass(a, degree, unit);
        }
        public static MetricMass MetricMass(this int a, SiMassUnits unit, int degree = 1)
        {
            return new MetricMass(a, degree, unit);
        }
        /// <summary>
        /// Converts MetricMass unit into specified unit.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="unit"></param>
        /// <param name="degree"></param>
        /// <returns>if the unit of MetricTime is not specified unit, returns a new MetricMass in specified unit.</returns>
        public static MetricMass MetricMass(this MetricMass a, SiMassUnits unit)
        {
            double value = a.GetValueBy(unit);
            return new MetricMass(value, a.Degree, unit);
        }
        /// <summary>
        /// Converts MetricMass unit into miligram.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in miligram.</param>
        /// <returns></returns>
        public static MetricMass mg(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.miligram);
            return new MetricMass(value, a.Degree, SiMassUnits.miligram);
        }
        /// <summary>
        /// Converts MetricMass unit into miligram.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in miligram.</param>
        /// <returns></returns>
        public static MetricMass miligram(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.miligram);
            return new MetricMass(value, a.Degree, SiMassUnits.miligram);
        }
        /// <summary>
        /// Converts MetricMass unit into gram.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in gram.</param>
        /// <returns></returns>
        public static MetricMass g(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.gram);
            return new MetricMass(value, a.Degree, SiMassUnits.gram);
        }
        /// <summary>
        /// Converts MetricMass unit into gram.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in gram.</param>
        /// <returns></returns>
        public static MetricMass gram(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.gram);
            return new MetricMass(value, a.Degree, SiMassUnits.gram);
        }
        /// <summary>
        /// Converts MetricMass unit into kilogram.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in kilogram.</param>
        /// <returns></returns>
        public static MetricMass kg(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.kilogram);
            return new MetricMass(value, a.Degree, SiMassUnits.kilogram);
        }
        /// <summary>
        /// Converts MetricMass unit into kilogram.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in kilogram.</param>
        /// <returns></returns>
        public static MetricMass kilogram(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.kilogram);
            return new MetricMass(value, a.Degree, SiMassUnits.kilogram);
        }
        /// <summary>
        /// Converts MetricMass unit into tonne.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in tonne.</param>
        /// <returns></returns>
        public static MetricMass t(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.tonne);
            return new MetricMass(value, a.Degree, SiMassUnits.tonne);
        }
        /// <summary>
        /// Converts MetricMass unit into tonne.
        /// </summary>
        /// <param name="a">if the unit of MetricMass is not miligram, returns a new MetricMass in tonne.</param>
        /// <returns></returns>
        public static MetricMass tonne(this MetricMass a)
        {
            double value = a.GetValueBy(SiMassUnits.tonne);
            return new MetricMass(value, a.Degree, SiMassUnits.tonne);
        }
    }
}
