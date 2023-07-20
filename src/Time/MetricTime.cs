using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public struct MetricTime
    {
        public MetricTime(double value, int degree,SiTimeUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public double Value { get;}
        public int Degree{ get; }
        public SiTimeUnits Unit { get;}
        public string Symbol { get { return this.GetSymbol(); } }

        #region operators
        public static MetricTime operator *(MetricTime a, MetricTime b) => MetricTime.Multiply(a, b);
        public static DerivedUnit operator *(MetricTime a, MetricLength b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricTime a, MetricMass b) => a.ToCompositeUnit() * b;
        public static MetricTime operator *(MetricTime a, double b) => MetricTime.Multiply(b, a);
        public static MetricTime operator *(double a, MetricTime b) => MetricTime.Multiply(a, b);
        public static MetricTime operator /(MetricTime a, MetricTime b) => MetricTime.Divide(a, b);
        public static DerivedUnit operator /(MetricTime a, MetricLength b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricTime a, MetricMass b) => a.ToCompositeUnit() / b;
        public static MetricTime operator /(MetricTime a, double b) => MetricTime.Divide(a, b);
        public static MetricTime operator /(double a, MetricTime b) => MetricTime.Divide(a, b);
        public static MetricTime operator +(MetricTime a, MetricTime b) => MetricTime.Sum(a, b);
        public static MetricTime operator -(MetricTime a, MetricTime b) => MetricTime.Subtract(a, b);
        #endregion

        public static MetricTime Multiply(MetricTime a, MetricTime b)
        {
            SiTimeUnits unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetSecond() * b.GetSecond()).GetUnitValue(unit, deg);            
            return new MetricTime(value, deg, unit);
        }
        public static MetricTime Multiply(MetricTime a, double b)
        {
            SiTimeUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime Multiply(double b, MetricTime a)
        {
            SiTimeUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime Divide(MetricTime a, MetricTime b)
        {
            SiTimeUnits unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetSecond() / b.GetSecond()).GetUnitValue(unit, deg);
            return new MetricTime(value, deg, unit);
        }
        public static MetricTime Divide(MetricTime a, double b)
        {
            SiTimeUnits unit = a.Unit;
            double value = a.Value / b;
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime Divide(double b, MetricTime a)
        {
            SiTimeUnits unit = a.Unit;
            double value = b / a.Value;
            int degree = -1 * a.Degree;
            return new MetricTime(value, degree, unit);
        }
        public static MetricTime Sum(MetricTime a, MetricTime b)
        {
            if(a.Degree != b.Degree) 
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiTimeUnits unit = a.Unit;
            double value = (a.GetSecond() + b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime Subtract(MetricTime a, MetricTime b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiTimeUnits unit = a.Unit;
            double value = (a.GetSecond() - b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricTime(value, a.Degree, unit);
        }
        public string UnitStr(bool asPositiveExponent = false)
        {
            if (Degree > 0)
            {
                return $"{Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            if (asPositiveExponent)
            {
                return $"{Symbol}{(Degree == -1 ? "" : (-1 * Degree).ToSupStr())}";
            }
            else
            {
                return $"1/{Symbol}{(-1 * Degree).ToSupStr()}";

            }
        }
        public override string ToString()
        {
            if(Degree == 0)
            {
                return $"{Value}";
            }
            if (Degree > 0)
            {
                return $"{Value} {Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            else
            {
                return $"{Value} 1/{Symbol}{(-1*Degree).ToSupStr()}";
            }
        }
    }
}
