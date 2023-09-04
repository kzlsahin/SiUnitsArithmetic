using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    internal static class Conversion
    {
        internal static int GetScaler(SiTemperatureUnits unit)
        {
            return _scalers[unit];
        }
        internal static string GetSymbol(this Temperature temp)
        {
            return _symbols[temp.Unit];
        }
        private static Dictionary<SiTemperatureUnits, int> _scalers = new Dictionary<SiTemperatureUnits, int> {
            {SiTemperatureUnits.picokelvin, -12},
            {SiTemperatureUnits.nanokelvin, -9},
            {SiTemperatureUnits.microkelvin,-6},
            {SiTemperatureUnits.milikelvin, -3},
            {SiTemperatureUnits.centikelvin,-2},
            {SiTemperatureUnits.decikelvin, -1},
            {SiTemperatureUnits.kelvin,     0},
            {SiTemperatureUnits.decakelvin, 1},
            {SiTemperatureUnits.hectokelvin,2},
            {SiTemperatureUnits.kilokelvin, 3},
            {SiTemperatureUnits.megakelvin, 6},
            {SiTemperatureUnits.gigakelvin, 9},
            {SiTemperatureUnits.terakelvin, 12},
            };
        private static Dictionary<SiTemperatureUnits, string> _symbols = new Dictionary<SiTemperatureUnits, string> {

            {SiTemperatureUnits.picokelvin, "pK"},
            {SiTemperatureUnits.nanokelvin, "nK"},
            {SiTemperatureUnits.microkelvin,"µK"},
            {SiTemperatureUnits.milikelvin, "mK"},
            {SiTemperatureUnits.centikelvin,"cK"},
            {SiTemperatureUnits.decikelvin, "dK"},
            {SiTemperatureUnits.kelvin,     "K"},
            {SiTemperatureUnits.decakelvin, "daK"},
            {SiTemperatureUnits.hectokelvin, "hK"},
            {SiTemperatureUnits.kilokelvin, "kK"},
            {SiTemperatureUnits.megakelvin, "MK"},
            {SiTemperatureUnits.gigakelvin, "GK"},
            {SiTemperatureUnits.terakelvin, "TK"},

            };
        internal static double GetUnitValue(this Temperature k, SiTemperatureUnits unit, int degree)
        {
            if (unit == k.Unit) return k.Value;
            double baseScaler = Math.Pow(Math.Pow(10, _scalers[k.Unit]), degree);
            double targetScaler = Math.Pow(Math.Pow(10, _scalers[unit]), degree);
            return k.Value * baseScaler / targetScaler;
        }
    }
}
