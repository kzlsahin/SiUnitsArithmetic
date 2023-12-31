﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public static class AmpereExtensions
    {
        /// <summary>
        /// Creates a length unit in amperes from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere A(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.ampere);
        }
        /// <summary>
        /// creates a length unit in milimeters from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere mA(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.miliampere);
        }
        /// <summary>
        /// creates length unit in centiampere from integer values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere cA(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.centiampere);
        }
        /// <summary>
        /// creates length unit in deciampere from integer value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere dA(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.deciampere);
        }
        /// <summary>
        /// creates length unit in kiloamperes from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere kA(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.kiloampere);
        }
        /// <summary>
        /// creates length unit in specified metric unit and specified degree from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="unit"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Ampere Ampere(this int a, SiAmpereUnits unit, int degree)
        {
            return new Ampere(a, degree, unit);
        }
        /// <summary>
        /// Creates a length unit in amperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere A(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.ampere);
        }
        /// <summary>
        /// Creates a length unit in miliamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere mA(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.miliampere);
        }
        /// <summary>
        /// Creates a length unit in centiamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere cA(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.centiampere);
        }
        /// <summary>
        /// Creates a length unit in deciamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere dA(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.deciampere);
        }
        /// <summary>
        /// Creates a length unit in kiloamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere kA(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.kiloampere);
        }
        /// <summary>
        /// creates length unit in specified metric unit and specified degree from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="unit"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static Ampere Ampere(this double a, SiAmpereUnits unit, int degree)
        {
            return new Ampere(a, degree, unit);
        }
        /// <summary>
        /// Converts Ampere unit into ampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not ampere, returns a new Ampere in ampere.</returns>
        public static Ampere A(this Ampere a)
        {
            if (a.Unit == SiAmpereUnits.ampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.ampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.ampere);
        }
        /// <summary>
        /// Converts Ampere unit into miliampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not miliampere, returns a new Ampere in miliampere.</returns>
        public static Ampere mA(this Ampere a)
        {
            if (a.Unit == SiAmpereUnits.miliampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.miliampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.miliampere);
        }
        /// <summary>
        /// Converts Ampere unit into centiampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not centiampere, returns a new Ampere in centiampere.</returns>
        public static Ampere cA(this Ampere a)
        {
            if (a.Unit == SiAmpereUnits.centiampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.centiampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.centiampere);
        }
        /// <summary>
        /// Converts Ampere unit into deciampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not deciampere, returns a new Ampere in deciampere.</returns>
        public static Ampere dA(this Ampere a)
        {
            if (a.Unit == SiAmpereUnits.deciampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.deciampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.deciampere);
        }
        /// <summary>
        /// Converts Ampere unit into kiloampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not kiloampere, returns a new Ampere in kiloampere.</returns>
        public static Ampere kA(this Ampere a)
        {
            if (a.Unit == SiAmpereUnits.kiloampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.kiloampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.kiloampere);
        }
        /// <summary>
        /// Converts Ampere unit into specified unit.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is specified unit, returns a new Ampere in specified unit.</returns>
        public static Ampere Ampere(this Ampere a, SiAmpereUnits unit)
        {
            if (a.Unit == unit)
                return a;
            double value = a.GetValueBy(unit);
            return new Ampere(value, a.Degree, unit);
        }
    }
}
