using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Time
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
        public static MetricTime operator *(MetricTime a, MetricTime b)
        {
            SiTimeUnits unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetSecond() * b.GetSecond()).GetUnitValue(unit, deg);            
            return new MetricTime(value, deg, unit);
        }
        public static MetricTime operator *(MetricTime a, double b)
        {
            SiTimeUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime operator *(double b, MetricTime a)
        {
            SiTimeUnits unit = a.Unit;
            double value = a.Value * b;
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime operator /(MetricTime a, MetricTime b)
        {
            SiTimeUnits unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetSecond() / b.GetSecond()).GetUnitValue(unit, deg);
            return new MetricTime(value, deg, unit);
        }
        public static MetricTime operator /(MetricTime a, double b)
        {
            SiTimeUnits unit = a.Unit;
            double value = a.Value / b;
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime operator /(double b, MetricTime a)
        {
            SiTimeUnits unit = a.Unit;
            double value = b / a.Value;
            int degree = -1 * a.Degree;
            return new MetricTime(value, degree, unit);
        }
        public static MetricTime operator +(MetricTime a, MetricTime b)
        {
            if(a.Degree != b.Degree) 
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiTimeUnits unit = a.Unit;
            double value = (a.GetSecond() + b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricTime(value, a.Degree, unit);
        }
        public static MetricTime operator -(MetricTime a, MetricTime b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiTimeUnits unit = a.Unit;
            double value = (a.GetSecond() - b.GetSecond()).GetUnitValue(unit, a.Degree);
            return new MetricTime(value, a.Degree, unit);
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
