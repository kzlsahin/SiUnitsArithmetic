using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.BasicUnits.ElectricCurrency
{
    public static class AmpereExtensions
    {
        /// <summary>
        /// Converts into a derived unit type
        /// </summary>
        /// <param name="l">the length unit to be converted</param>
        /// <returns></returns>
        public static DerivedUnit ToCompositeUnit(this Ampere l)
        {
            return DerivedUnit.New(l);
        }
        /// <summary>
        /// Creates a length unit in amperes from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere m(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.ampere);
        }
        /// <summary>
        /// creates a length unit in milimeters from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere mm(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.miliampere);
        }
        /// <summary>
        /// creates length unit in centiampere from integer values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere cm(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.centiampere);
        }
        /// <summary>
        /// creates length unit in deciampere from integer value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere dm(this int a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.deciampere);
        }
        /// <summary>
        /// creates length unit in kiloamperes from integer value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere km(this int a, int degree = 1)
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
        public static Ampere m(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.ampere);
        }
        /// <summary>
        /// Creates a length unit in miliamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere mm(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.miliampere);
        }
        /// <summary>
        /// Creates a length unit in centiamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere cm(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.centiampere);
        }
        /// <summary>
        /// Creates a length unit in deciamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere dm(this double a, int degree = 1)
        {
            return new Ampere(a, degree, SiAmpereUnits.deciampere);
        }
        /// <summary>
        /// Creates a length unit in kiloamperes from double value.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="degree">determines the degree (exponent) of the unit. default value is 1.</param>
        /// <returns></returns>
        public static Ampere km(this double a, int degree = 1)
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
        public static Ampere m(this Ampere a)
        {
            if (a.UnitOrder == SiAmpereUnits.ampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.ampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.ampere);
        }
        /// <summary>
        /// Converts Ampere unit into miliampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not miliampere, returns a new Ampere in miliampere.</returns>
        public static Ampere mm(this Ampere a)
        {
            if (a.UnitOrder == SiAmpereUnits.miliampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.miliampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.miliampere);
        }
        /// <summary>
        /// Converts Ampere unit into centiampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not centiampere, returns a new Ampere in centiampere.</returns>
        public static Ampere cm(this Ampere a)
        {
            if (a.UnitOrder == SiAmpereUnits.centiampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.centiampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.centiampere);
        }
        /// <summary>
        /// Converts Ampere unit into deciampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not deciampere, returns a new Ampere in deciampere.</returns>
        public static Ampere dm(this Ampere a)
        {
            if (a.UnitOrder == SiAmpereUnits.deciampere)
                return a;
            double value = a.GetValueBy(SiAmpereUnits.deciampere);
            return new Ampere(value, a.Degree, SiAmpereUnits.deciampere);
        }
        /// <summary>
        /// Converts Ampere unit into kiloampere.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>if the unit of Ampere is not kiloampere, returns a new Ampere in kiloampere.</returns>
        public static Ampere km(this Ampere a)
        {
            if (a.UnitOrder == SiAmpereUnits.kiloampere)
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
            if (a.UnitOrder == unit)
                return a;
            double value = a.GetValueBy(unit);
            return new Ampere(value, a.Degree, unit);
        }
    }
}
