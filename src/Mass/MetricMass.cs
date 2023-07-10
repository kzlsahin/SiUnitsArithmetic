using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Mass
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

        public static MetricMass operator *(MetricMass a, MetricMass b)
        {
            SiMassUnits unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetSecond() * b.GetSecond()).GetUnitValue(unit, deg);            
            return new MetricMass(value, deg, unit);
        }
        public static MetricMass operator *(MetricMass a, double b)
        {
            SiMassUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass operator *(double b, MetricMass a)
        {
            SiMassUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass operator /(MetricMass a, MetricMass b)
        {
            SiMassUnits unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetSecond() / b.GetSecond()).GetUnitValue(unit, deg);
            return new MetricMass(value, deg, unit);
        }
        public static MetricMass operator /(MetricMass a, double b)
        {
            SiMassUnits unit = a.Unit;
            double value = a.Value / b;
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass operator /(double b, MetricMass a)
        {
            SiMassUnits unit = a.Unit;
            double value = b / a.Value;
            int degree = -1 * a.Degree;
            return new MetricMass(value, degree, unit);
        }
        public static MetricMass operator +(MetricMass a, MetricMass b)
        {
            if(a.Degree != b.Degree) 
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMassUnits unit = a.Unit;
            double value = (a.GetSecond() + b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricMass(value, a.Degree, unit);
        }
        public static MetricMass operator -(MetricMass a, MetricMass b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiMassUnits unit = a.Unit;
            double value = (a.GetSecond() - b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricMass(value, a.Degree, unit);
        }

        public override string ToString()
        {
            if(Degree == 0)
            {
                return $"{Value}";
            }
            else if(Degree == 1)
            {
                return $"{Value} <{this.GetSymbol()}>";
            }
            else if (Degree >= 1)
            {
                return $"{Value} <{this.GetSymbol()}{Degree}>";
            }
            else
            {
                return $"{Value} <1/{this.GetSymbol()}{-1*Degree}>";
            }
        }
    }
}
