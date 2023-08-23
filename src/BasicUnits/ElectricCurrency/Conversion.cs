using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.BasicUnits.ElectricCurrency
{
    internal static class Conversion
    {
        internal static int GetScaler(SiAmpereUnits unit)
        {
            return _scalers[unit];
        }
        internal static string GetSymbol(this Ampere metric)
        {
            return _symbols[metric.Unit];
        }
        private static Dictionary<SiAmpereUnits, int> _scalers = new Dictionary<SiAmpereUnits, int> {
            { SiAmpereUnits.yoktoampere, -24 },
            {SiAmpereUnits.zeptoampere,-21},
            {SiAmpereUnits.attoampere, -18},
            {SiAmpereUnits.femtoampere,-15},
            {SiAmpereUnits.picoampere, -12},
            {SiAmpereUnits.nanoampere, -9},
            {SiAmpereUnits.microampere,-6},
            {SiAmpereUnits.miliampere, -3},
            {SiAmpereUnits.centiampere,-2},
            {SiAmpereUnits.deciampere, -1},
            {SiAmpereUnits.ampere,     0},
            {SiAmpereUnits.decaampere, 1},
            {SiAmpereUnits.hectoampere,2},
            {SiAmpereUnits.kiloampere, 3},
            {SiAmpereUnits.megaampere, 6},
            {SiAmpereUnits.gigaampere, 9},
            {SiAmpereUnits.teraampere, 12},
            {SiAmpereUnits.petaampere, 15},
            {SiAmpereUnits.exaampere, 18},
            {SiAmpereUnits.zettaampere,21},
            {SiAmpereUnits.yottaampere,24}
            };
        private static Dictionary<SiAmpereUnits, string> _symbols = new Dictionary<SiAmpereUnits, string> {
            {SiAmpereUnits.yoktoampere,"yA"},
            {SiAmpereUnits.zeptoampere,"zA"},
            {SiAmpereUnits.attoampere, "aA"},
            {SiAmpereUnits.femtoampere,"fA"},
            {SiAmpereUnits.picoampere, "pA"},
            {SiAmpereUnits.nanoampere, "nA"},
            {SiAmpereUnits.microampere,"µA"},
            {SiAmpereUnits.miliampere, "mA"},
            {SiAmpereUnits.centiampere,"cA"},
            {SiAmpereUnits.deciampere, "dA"},
            {SiAmpereUnits.ampere,      "A"},
            {SiAmpereUnits.decaampere, "daA"},
            {SiAmpereUnits.hectoampere,"hA"},
            {SiAmpereUnits.kiloampere, "kA"},
            {SiAmpereUnits.megaampere, "MA"},
            {SiAmpereUnits.gigaampere, "GA"},
            {SiAmpereUnits.teraampere, "TA"},
            {SiAmpereUnits.petaampere, "PA"},
            {SiAmpereUnits.exaampere,  "EA"},
            {SiAmpereUnits.zettaampere,"ZA"},
            {SiAmpereUnits.yottaampere,"YA"}
            };
        internal static double GetUnitValue(this Ampere l, SiAmpereUnits unit, int degree)
        {
            if (unit == l.Unit) return l.Value;
            double baseScaler = Math.Pow(Math.Pow(10, _scalers[l.Unit]), degree);
            double targetScaler = Math.Pow(Math.Pow(10, _scalers[unit]), degree);
            return l.Value * baseScaler / targetScaler;
        }
    }
}
