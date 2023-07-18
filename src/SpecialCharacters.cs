using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIUnits
{
    public static class SpecialCharacters
    {
        /// <summary>
        /// super scripts
        /// </summary>
        public static string ToSupStr(this int a)
        {
            string exp = a.ToString().Aggregate("", (acc, c) => acc + supDigitChars[(int)char.GetNumericValue(c)]);
            return exp;
        }
        /// <summary>
        /// super scripts
        /// </summary>
        public static string ToSubStr(this int a)
        {
            string exp = a.ToString().Aggregate("", (acc, c) => acc + subDigitChars[(int)char.GetNumericValue(c)]);
            return exp;
        }
        /// <summary>
        /// super scripts
        /// </summary>
        static Dictionary<int, char> supDigitChars = new Dictionary<int, char>
        {
            {0, (char)0X2070},
            {1, (char)0X00B9},
            {2, (char)0X00B2},
            {3, (char)0X00B3},
            {4, (char)0X2074},
            {5, (char)0X2075},
            {6, (char)0X2076},
            {7, (char)0X2077},
            {8, (char)0X2078},
            {9, (char)0X2079},
        };
        /// <summary>
        /// Subscripts
        /// </summary>
        static Dictionary<int, char> subDigitChars = new Dictionary<int, char>
        {
            {0, (char)0X2090},
            {1, (char)0X2091},
            {2, (char)0X0092},
            {3, (char)0X0093},
            {4, (char)0X2094},
            {5, (char)0X2095},
            {6, (char)0X2096},
            {7, (char)0X2097},
            {8, (char)0X2098},
            {9, (char)0X2099},
        };
    }
}
