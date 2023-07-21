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
        internal static T Sum(T a, T b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            U unit = a.Unit;
            double value = (a.GetMetre() + b.GetMetre()).GetUnitValue(unit, a.Degree);
            return new T(value, a.Degree, unit);
        }
        /// <summary>
        /// Subtraction of two T units.Caution! error-prone method. Subtraction of two units with different degrees throws exception
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> new T unit.</returns>
        /// <exception cref="ArgumentException">Subtraction of two units with different degrees throws exception</exception>
        internal static T Subtract(T a, T b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            U unit = a.Unit;
            double value = (a.GetMetre() - b.GetMetre()).GetUnitValue(unit, a.Degree);
            return new T(value, a.Degree, unit);
        }
        internal static T Multiply(T a, T b)
        {
            U unit = a.Unit;
            int deg = a.Degree + b.Degree;
            double value = (a.GetMetre() * b.GetMetre()).GetUnitValue(unit, deg);
            return new T(value, deg, unit);
        }
        internal static T Multiply(double a, T b)
        {
            U unit = b.Unit;
            double value = b.Value * a;
            return new T(value, b.Degree, unit);
        }
        internal static T Divide(T a, T b)
        {
            U unit = a.Unit;
            int deg = a.Degree - b.Degree;
            double value = (a.GetMetre() / b.GetMetre()).GetUnitValue(unit, deg);
            return new T(value, deg, unit);
        }
        internal static T Divide(T a, double b)
        {
            U unit = a.Unit;
            double value = a.Value / b;
            return new T(value, a.Degree, unit);
        }
        internal static T Divide(double a, T b)
        {
            U unit = b.Unit;
            double value = a / b.Value;
            int degree = -1 * b.Degree;
            return new T(value, degree, unit);
        }
    }
}
