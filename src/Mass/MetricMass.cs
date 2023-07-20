using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public struct MetricMass
    {
        public MetricMass(double value, int degree,SiMassUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public double Value { get;}
        public int Degree{ get; }
        public SiMassUnits Unit { get;}
        public string Symbol { get { return this.GetSymbol(); } }

        #region operators
        public static MetricMass operator *(MetricMass a, MetricMass b) => MetricMass.Multiply(a, b);
        public static DerivedUnit operator *(MetricMass a, MetricLength b) => a.ToCompositeUnit() * b;
        public static DerivedUnit operator *(MetricMass a, MetricTime b) => a.ToCompositeUnit() * b;
        public static MetricMass operator *(MetricMass a, double b) => MetricMass.Multiply(b, a);
        public static MetricMass operator *(double a, MetricMass b) => MetricMass.Multiply(a, b);
        public static MetricMass operator /(MetricMass a, MetricMass b) => MetricMass.Divide(a, b);
        public static DerivedUnit operator /(MetricMass a, MetricLength b) => a.ToCompositeUnit() / b;
        public static DerivedUnit operator /(MetricMass a, MetricTime b) => a.ToCompositeUnit() / b;
        public static MetricMass operator /(MetricMass a, double b) => MetricMass.Divide(a, b);
        public static MetricMass operator /(double a, MetricMass b) => MetricMass.Divide(a, b);
        public static MetricMass operator +(MetricMass a, MetricMass b) => MetricMass.Sum(a, b);
        public static MetricMass operator -(MetricMass a, MetricMass b) => MetricMass.Subtract(a, b);
        #endregion

        public static MetricMass Multiply(MetricMass a, MetricMass b)
        {
            SiMassUnits unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetSecond() * b.GetSecond()).GetUnitValue(unit, deg);            
            return new MetricMass(value, deg, unit);
        }
        public static MetricMass Multiply(MetricMass a, double b)
        {
            SiMassUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass Multiply(double b, MetricMass a)
        {
            SiMassUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass Divide(MetricMass a, MetricMass b)
        {
            SiMassUnits unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetSecond() / b.GetSecond()).GetUnitValue(unit, deg);
            return new MetricMass(value, deg, unit);
        }
        public static MetricMass Divide(MetricMass a, double b)
        {
            SiMassUnits unit = a.Unit;
            double value = a.Value / b;
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass Divide(double b, MetricMass a)
        {
            SiMassUnits unit = a.Unit;
            double value = b / a.Value;
            int degree = -1 * a.Degree;
            return new MetricMass(value, degree, unit);
        }
        public static MetricMass Sum(MetricMass a, MetricMass b)
        {
            if(a.Degree != b.Degree) 
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMassUnits unit = a.Unit;
            double value = (a.GetSecond() + b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass Subtract(MetricMass a, MetricMass b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiMassUnits unit = a.Unit;
            double value = (a.GetSecond() - b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricMass(value, a.Degree, unit);
        }
        public string UnitStr(bool asPositiveExponent = false)
        {
            if (Degree > 0)
            {
                return $"{Symbol}{(Degree == 1 ? "" : Degree.ToSupStr())}";
            }
            if (asPositiveExponent)
            {
                return $"{Symbol}{(Degree == -1 ? "" : (-1*Degree).ToSupStr())}";
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
                return $"{Value} 1/{this.GetSymbol()}{(-1*Degree).ToSupStr()}";
            }
        }
    }
}
