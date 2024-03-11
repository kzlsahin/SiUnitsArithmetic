using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Artihmetic
{
    internal class ArithmeticOperations
    {
        static ArithmeticOperations _instance;
        internal static ArithmeticOperations Instance
        {
            get { return _instance ?? (_instance = new ArithmeticOperations()); }
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
        internal IBasicUnit Sum(IBasicUnit a, IBasicUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of Sum operator shall be same type");
            }
            int unitOrder = a.UnitOrder;
            double value = (a.GetValueBy(unitOrder) + b.GetValueBy(unitOrder));
            return a.NewInstance(value, a.Degree, unitOrder);
        }
        /// <summary>
        /// Subtraction of two T units.Caution! error-prone method. Subtraction of two units with different degrees throws exception
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> new T unit.</returns>
        /// <exception cref="ArgumentException">Subtraction of two units with different degrees throws exception</exception>
        internal IBasicUnit Subtract(IBasicUnit a, IBasicUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be subtracted");
            }
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of Sum operator shall be same type");
            }
            int unitOrder = a.UnitOrder;
            double value = (a.GetValueBy(unitOrder) - b.GetValueBy(unitOrder));
            return a.NewInstance(value, a.Degree, unitOrder);
        }
        internal IBasicUnit Multiply(IBasicUnit a, IBasicUnit b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of basic multiply operator shall be same type");
            }
            int unitOrder = a.UnitOrder;
            int deg = a.Degree + b.Degree;
            double value = (a.GetValueBy(unitOrder) * b.GetValueBy(unitOrder));
            return a.NewInstance(value, deg, unitOrder);
        }
        internal IBasicUnit Multiply(double a, IBasicUnit b)
        {
            int unitOrder = b.UnitOrder;
            double value = b.Value * a;
            return b.NewInstance(value, b.Degree, unitOrder);
        }
        internal IBasicUnit Divide(IBasicUnit a, IBasicUnit b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of basic devide operator shall be same type");
            }
            int unitOrder = a.UnitOrder;
            int deg = a.Degree - b.Degree;
            double value = (a.GetValueBy(unitOrder) / b.GetValueBy(unitOrder));
            return a.NewInstance(value, deg, unitOrder);
        }
        internal IBasicUnit Divide(IBasicUnit a, double b)
        {
            int unitOrder = a.UnitOrder;
            double value = a.Value / b;
            return a.NewInstance(value, a.Degree, unitOrder);
        }
        internal IBasicUnit Divide(double a, IBasicUnit b)
        {
            int unitOrder = b.UnitOrder;
            double value = a / b.Value;
            int degree = -1 * b.Degree;
            return b.NewInstance(value, degree, unitOrder);
        }
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        internal bool IsLessThen(IBasicUnit a, IBasicUnit b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of basic less than operator shall be same type");
            }
            bool isEqual = a.Degree == b.Degree;
            bool lessThen;
            if (isEqual)
            {
                int unitOrder = (a.UnitOrder < b.UnitOrder) ? a.UnitOrder : b.UnitOrder;
                lessThen = a.GetValueBy(unitOrder) < b.GetValueBy(unitOrder);
            }
            else
            {
                throw new ArgumentException("Degrees of units are different.");
            }
            return lessThen;
        }
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        internal bool IsGreaterThen(IBasicUnit a, IBasicUnit b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of basic greater than operator shall be same type");
            }
            bool isEqual = a.Degree == b.Degree;
            bool greaterThen;
            if (isEqual)
            {
                int unitOrder = (a.UnitOrder < b.UnitOrder) ? a.UnitOrder : b.UnitOrder;
                greaterThen = a.GetValueBy(unitOrder) > b.GetValueBy(unitOrder);
            }
            else
            {
                throw new ArgumentException("Degrees of units are different.");
            }
            return greaterThen;
        }
        internal bool IsEqual(IBasicUnit a, IBasicUnit b)
        {
            if (a.GetType() != b.GetType())
            {
                throw new ArgumentException("operants of basic equal to operator shall be same type");
            }
            bool isEqual = a.Degree == b.Degree;
            if (isEqual)
            {
                int unitOrder = (a.UnitOrder < b.UnitOrder) ? a.UnitOrder : b.UnitOrder;
                if (UnitConfig.UnitPrecision == 0)
                {
                    isEqual = a.GetValueBy(unitOrder) == b.GetValueBy(unitOrder);
                }
                else
                {
                    isEqual = Math.Abs(a.GetValueBy(unitOrder) - b.GetValueBy(unitOrder)) < Math.Pow(10, -1 * UnitConfig.UnitPrecision);
                }
            }
            return isEqual;
        }
    }
}
