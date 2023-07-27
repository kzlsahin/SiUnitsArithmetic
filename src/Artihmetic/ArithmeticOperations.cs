using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Artihmetic
{
    internal class ArithmeticOperations<T, U>
        where T : Metric<U>
        where U : Enum
    {
        static ArithmeticOperations<T, U> _instance;
        internal static ArithmeticOperations<T, U> Instance
        {
            get { return _instance ?? (_instance = new ArithmeticOperations<T, U>()); }
        }
        protected ArithmeticOperations()
        {

        }
        /// <summary>
        /// Addition of two T units.Caution! error-prone method. Summation of two units with different degrees throws exception
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>a new T unit.</returns>
        /// <exception cref="ArgumentException"> Summation of two units with different degrees throws exception</exception>
        internal T Sum(T a, T b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            U unit = a.Unit;
            double value = (a.GetValueBy(unit) + b.GetValueBy(unit));
            return (T)a.NewInstance(value, a.Degree, unit);
        }
        /// <summary>
        /// Subtraction of two T units.Caution! error-prone method. Subtraction of two units with different degrees throws exception
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> new T unit.</returns>
        /// <exception cref="ArgumentException">Subtraction of two units with different degrees throws exception</exception>
        internal T Subtract(T a, T b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            U unit = a.Unit;
            double value = (a.GetValueBy(unit) - b.GetValueBy(unit));
            return (T)a.NewInstance(value, a.Degree, unit);
        }
        internal T Multiply(T a, T b)
        {
            U unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetValueBy(unit) * b.GetValueBy(unit));
            return (T)a.NewInstance(value, deg, unit);
        }
        internal T Multiply(double a, T b)
        {
            U unit = b.Unit;
            double value = b.Value * a;
            return (T)b.NewInstance(value, b.Degree, unit);
        }
        internal T Divide(T a, T b)
        {
            U unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetValueBy(unit) / b.GetValueBy(unit));
            return (T)a.NewInstance(value, deg, unit);
        }
        internal T Divide(T a, double b)
        {
            U unit = a.Unit;
            double value = a.Value / b;
            return (T)a.NewInstance(value, a.Degree, unit);
        }
        internal T Divide(double a, T b)
        {
            U unit = b.Unit;
            double value = a / b.Value;
            int degree = -1 * b.Degree;
            return (T)b.NewInstance(value, degree, unit);
        }
        internal bool IsEqual(T a, T b)
        {
            bool isEqual = a.Degree == b.Degree;
            if (isEqual)
            {
                U unit = ((int)(object)(a.Unit) < (int)(object)(b.Unit)) ? a.Unit : b.Unit;
                if(UnitConfig.UnitPrecision == 0)
                {
                    isEqual = a.GetValueBy(unit) == b.GetValueBy(unit);
                }
                else
                {
                    isEqual = Math.Abs(a.GetValueBy(unit) - b.GetValueBy(unit)) < Math.Pow(10, -1 * UnitConfig.UnitPrecision);
                }
            }
            return isEqual;
        }
    }
}
