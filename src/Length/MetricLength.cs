using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
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


        #region operators
        public static MetricLength operator *(MetricLength a, MetricLength b) => MetricLength.Multiply(a, b);
        public static MetricLength operator *(MetricLength a, double b) => MetricLength.Multiply(b, a);
        public static MetricLength operator *(double a, MetricLength b)=> MetricLength.Multiply(a, b);
        public static MetricLength operator /(MetricLength a, MetricLength b) => MetricLength.Divide(a, b);
        public static MetricLength operator /(MetricLength a, double b) => MetricLength.Divide(a, b);
        public static MetricLength operator /(double a, MetricLength b) => MetricLength.Divide(a, b);
        public static MetricLength operator +(MetricLength a, MetricLength b) => MetricLength.Sum(a, b);
        public static MetricLength operator -(MetricLength a, MetricLength b) => MetricLength.Subtract(a, b);
        #endregion

        /// <summary>
        /// Addition of two MetricLength units.Caution! error-prone method. Summation of two units with different degrees throws exception
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a new MetricLength unit.</returns>
        /// <exception cref="ArgumentException"> Summation of two units with different degrees throws exception</exception>
        public static MetricLength Sum(MetricLength a, MetricLength b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() + b.GetMetre()).GetUnitValue(unit, a.Degree);
            return new MetricLength(value, a.Degree, unit);
        }
        /// <summary>
        /// Subtraction of two MetricLength units.Caution! error-prone method. Subtraction of two units with different degrees throws exception
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> new MetricLength unit.</returns>
        /// <exception cref="ArgumentException">Subtraction of two units with different degrees throws exception</exception>
        public static MetricLength Subtract(MetricLength a, MetricLength b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            SiMetricUnits unit = a.Unit;
            double value = (a.GetMetre() - b.GetMetre()).GetUnitValue(unit, a.Degree);
            return new MetricLength(value, a.Degree, unit);
        }
        public static MetricLength Multiply(MetricLength a, MetricLength b)
        {
            SiMetricUnits unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetMetre() * b.GetMetre()).GetUnitValue(unit, deg);
            return new MetricLength(value, deg, unit);
        }
        public static MetricLength Multiply(double a, MetricLength b)
        {
            SiMetricUnits unit = b.Unit;
            double value = b.Value * a;
            return new MetricLength(value, b.Degree, unit);
        }
        public static MetricLength Divide(MetricLength a, MetricLength b)
        {
            SiMetricUnits unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetMetre() / b.GetMetre()).GetUnitValue(unit, deg);
            return new MetricLength(value, deg, unit);
        }
        public static MetricLength Divide(MetricLength a, double b)
        {
            SiMetricUnits unit = a.Unit;
            double value = a.Value / b;
            return new MetricLength(value, a.Degree, unit);
        }
        public static MetricLength Divide(double a, MetricLength b)
        {
            SiMetricUnits unit = b.Unit;
            double value = a / b.Value;
            int degree = -1 * b.Degree;
            return new MetricLength(value, degree, unit);
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
                return $"{Value} <{Symbol}{Degree.ToSupStr()}>";
            }
            else
            {
                return $"{Value} <1/{Symbol}{(-1*Degree).ToSupStr()}>";
            }
        }
    }
}
