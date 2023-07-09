using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits.Length
{
    public struct Metric
    {
        internal Metric(double value, int degree, SiMetricUnits unit)
        {
            Value = value;
            Degree = degree;
            Unit = unit;
        }
        public double Value { get;}
        public int Degree{ get; }
        public SiMetricUnits Unit { get;}

        public static Metric operator *(Metric a, Metric b)
        {
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() * b.GetMetre()).GetUnitValue(unit);
            int deg = a.Degree + b.Degree;
            return new Metric(value, deg, unit);
        }
        public static Metric operator /(Metric a, Metric b)
        {
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() / b.GetMetre()).GetUnitValue(unit);
            int deg = a.Degree - b.Degree;
            return new Metric(value, deg, unit);
        }
        public static Metric operator +(Metric a, Metric b)
        {
            if(a.Degree != b.Degree) 
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() + b.GetMetre()).GetUnitValue(unit);
            return new Metric(value, a.Degree, unit);
        }
        public static Metric operator -(Metric a, Metric b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() - b.GetMetre()).GetUnitValue(unit);
            return new Metric(value, a.Degree, unit);
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
