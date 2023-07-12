using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Length
{
    public struct MetricLength
    {
        public MetricLength(double value, int degree, SiMetricUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public double Value { get;}
        public int Degree{ get; }
        public string Symbol { get { return this.GetSymbol(); } }
        public SiMetricUnits Unit { get;}

        public static MetricLength operator *(MetricLength a, MetricLength b)
        {
            SiMetricUnits unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetMetre() * b.GetMetre()).GetUnitValue(unit, deg);            
            return new MetricLength(value, deg, unit);
        }
        public static MetricLength operator *(MetricLength a, double b)
        {
            SiMetricUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricLength(value, a.Degree, unit);
        }
        public static MetricLength operator *(double b, MetricLength a)
        {
            SiMetricUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricLength(value, a.Degree, unit);
        }
        public static MetricLength operator /(MetricLength a, MetricLength b)
        {
            SiMetricUnits unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetMetre() / b.GetMetre()).GetUnitValue(unit, deg);
            return new MetricLength(value, deg, unit);
        }
        public static MetricLength operator /(MetricLength a, double b)
        {
            SiMetricUnits unit = a.Unit;
            double value = a.Value / b;
            return new MetricLength(value, a.Degree, unit);
        }
        public static MetricLength operator /(double b, MetricLength a)
        {
            SiMetricUnits unit = a.Unit;
            double value = b / a.Value;
            int degree = -1 * a.Degree;
            return new MetricLength(value, degree, unit);
        }
        public static MetricLength operator +(MetricLength a, MetricLength b)
        {
            if(a.Degree != b.Degree) 
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() + b.GetMetre()).GetUnitValue(unit, a.Degree);
            return new MetricLength(value, a.Degree, unit);
        }
        public static MetricLength operator -(MetricLength a, MetricLength b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() - b.GetMetre()).GetUnitValue(unit, a.Degree);
            return new MetricLength(value, a.Degree, unit);
        }

        public override string ToString()
        {
            if(Degree == 0)
            {
                return $"{Value}";
            }
            else if(Degree == 1)
            {
                return $"{Value} <{Symbol}>";
            }
            else if (Degree >= 1)
            {
                return $"{Value} <{Symbol}{Degree}>";
            }
            else
            {
                return $"{Value} <1/{Symbol}{-1*Degree}>";
            }
        }
    }
}
