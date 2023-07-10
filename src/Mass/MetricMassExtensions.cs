using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Mass
{
    public static class MetricMassExtensions
    {
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
        public static MetricMass metric(this double a, SiMassUnits unit, int degree = 1)
        {
            return new MetricMass(a, degree, unit);
        }
        public static MetricMass mg(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.miligram, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.miligram);
        }
        public static MetricMass miligram(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.miligram, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.miligram);
        }
        public static MetricMass g(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.gram, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.gram);
        }
        public static MetricMass gram(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.gram, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.gram);
        }
        public static MetricMass kg(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.kilogram, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.kilogram);
        }
        public static MetricMass kilogram(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.kilogram, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.kilogram);
        }
        public static MetricMass t(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.tonne, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.tonne);
        }
        public static MetricMass tonne(this MetricMass a)
        {
            double value = a.GetSecond().GetUnitValue(SiMassUnits.tonne, a.Degree);
            return new MetricMass(value, a.Degree, SiMassUnits.tonne);
        }
    }
}
