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
            return _symbols[metric.UnitOrder];
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
            {SiAmpereUnits.yoktoampere,"ym"},
            {SiAmpereUnits.zeptoampere,"zm"},
            {SiAmpereUnits.attoampere, "am"},
            {SiAmpereUnits.femtoampere,"fm"},
            {SiAmpereUnits.picoampere, "pm"},
            {SiAmpereUnits.nanoampere, "nm"},
            {SiAmpereUnits.microampere,"µm"},
            {SiAmpereUnits.miliampere, "mm"},
            {SiAmpereUnits.centiampere,"cm"},
            {SiAmpereUnits.deciampere, "dm"},
            {SiAmpereUnits.ampere,     "m"},
            {SiAmpereUnits.decaampere, "dam"},
            {SiAmpereUnits.hectoampere,"hm"},
            {SiAmpereUnits.kiloampere, "km"},
            {SiAmpereUnits.megaampere, "Mm"},
            {SiAmpereUnits.gigaampere, "Gm"},
            {SiAmpereUnits.teraampere, "Tm"},
            {SiAmpereUnits.petaampere, "Pm"},
            {SiAmpereUnits.exaampere,  "Em"},
            {SiAmpereUnits.zettaampere,"Zm"},
            {SiAmpereUnits.yottaampere,"Ym"}
            };
        internal static double GetUnitValue(this Ampere l, SiAmpereUnits unit, int degree)
        {
            if (unit == l.UnitOrder) return l.Value;
            double baseScaler = Math.Pow(Math.Pow(10, _scalers[l.UnitOrder]), degree);
            double targetScaler = Math.Pow(Math.Pow(10, _scalers[unit]), degree);
            return l.Value * baseScaler / targetScaler;
        }
    }
}
