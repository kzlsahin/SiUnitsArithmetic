using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public static class TemperatureExtensions
    {
        /// <summary>
        /// Creates a length unit in kelvins from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature A(this int a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.kelvin);
        }
        /// <summary>
        /// creates a length unit in milimeters from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature mA(this int a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.milikelvin);
        }
        /// <summary>
        /// creates length unit in centikelvin from integer values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature cA(this int a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.centikelvin);
        }
        /// <summary>
        /// creates length unit in decikelvin from integer value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature dA(this int a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.decikelvin);
        }
        /// <summary>
        /// creates length unit in kilokelvins from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature kA(this int a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.kilokelvin);
        }
        /// <summary>
        /// creates length unit in specified metric unit and specified degree from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="unit"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Temperature Temperature(this int a, SiTemperatureUnits unit, int degree)
        {
            return new Temperature(a, degree, unit);
        }
        /// <summary>
        /// Creates a length unit in kelvins from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature A(this double a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.kelvin);
        }
        /// <summary>
        /// Creates a length unit in milikelvins from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature mA(this double a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.milikelvin);
        }
        /// <summary>
        /// Creates a length unit in centikelvins from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature cA(this double a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.centikelvin);
        }
        /// <summary>
        /// Creates a length unit in decikelvins from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature dA(this double a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.decikelvin);
        }
        /// <summary>
        /// Creates a length unit in kilokelvins from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Temperature kA(this double a, int degree = 1)
        {
            return new Temperature(a, degree, SiTemperatureUnits.kilokelvin);
        }
        /// <summary>
        /// creates length unit in specified metric unit and specified degree from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="unit"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Temperature Temperature(this double a, SiTemperatureUnits unit, int degree)
        {
            return new Temperature(a, degree, unit);
        }
        /// <summary>
        /// Converts Temperature unit into kelvin.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Temperature is not kelvin, returns a new Temperature in kelvin.</returns>
        public static Temperature A(this Temperature a)
        {
            if (a.Unit == SiTemperatureUnits.kelvin)
                return a;
            double value = a.GetValueBy(SiTemperatureUnits.kelvin);
            return new Temperature(value, a.Degree, SiTemperatureUnits.kelvin);
        }
        /// <summary>
        /// Converts Temperature unit into milikelvin.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Temperature is not milikelvin, returns a new Temperature in milikelvin.</returns>
        public static Temperature mA(this Temperature a)
        {
            if (a.Unit == SiTemperatureUnits.milikelvin)
                return a;
            double value = a.GetValueBy(SiTemperatureUnits.milikelvin);
            return new Temperature(value, a.Degree, SiTemperatureUnits.milikelvin);
        }
        /// <summary>
        /// Converts Temperature unit into centikelvin.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Temperature is not centikelvin, returns a new Temperature in centikelvin.</returns>
        public static Temperature cA(this Temperature a)
        {
            if (a.Unit == SiTemperatureUnits.centikelvin)
                return a;
            double value = a.GetValueBy(SiTemperatureUnits.centikelvin);
            return new Temperature(value, a.Degree, SiTemperatureUnits.centikelvin);
        }
        /// <summary>
        /// Converts Temperature unit into decikelvin.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Temperature is not decikelvin, returns a new Temperature in decikelvin.</returns>
        public static Temperature dA(this Temperature a)
        {
            if (a.Unit == SiTemperatureUnits.decikelvin)
                return a;
            double value = a.GetValueBy(SiTemperatureUnits.decikelvin);
            return new Temperature(value, a.Degree, SiTemperatureUnits.decikelvin);
        }
        /// <summary>
        /// Converts Temperature unit into kilokelvin.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Temperature is not kilokelvin, returns a new Temperature in kilokelvin.</returns>
        public static Temperature kA(this Temperature a)
        {
            if (a.Unit == SiTemperatureUnits.kilokelvin)
                return a;
            double value = a.GetValueBy(SiTemperatureUnits.kilokelvin);
            return new Temperature(value, a.Degree, SiTemperatureUnits.kilokelvin);
        }
        /// <summary>
        /// Converts Temperature unit into specified unit.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Temperature is specified unit, returns a new Temperature in specified unit.</returns>
        public static Temperature Temperature(this Temperature a, SiTemperatureUnits unit)
        {
            if (a.Unit == unit)
                return a;
            double value = a.GetValueBy(unit);
            return new Temperature(value, a.Degree, unit);
        }
    }
}
