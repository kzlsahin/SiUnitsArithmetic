using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Length
{
    internal static class Conversion
    {
        internal static int GetScaler(SiMetricUnits unit)
        {
            return _scalers[unit];
        }
        internal static string GetSymbol(this MetricLength metric)
        {
            return _symbols[metric.Unit];
        }
        private static Dictionary<SiMetricUnits, int> _scalers = new Dictionary<SiMetricUnits, int> {
            { SiMetricUnits.yoktometre, -24 },
            {SiMetricUnits.zeptometre,-21},
            {SiMetricUnits.attometre, -18},
            {SiMetricUnits.femtometre,-15},
            {SiMetricUnits.picometre, -12},
            {SiMetricUnits.nanometre, -9},
            {SiMetricUnits.micrometre,-6},
            {SiMetricUnits.milimetre, -3},
            {SiMetricUnits.centimetre,-2},
            {SiMetricUnits.decimetre, -1},
            {SiMetricUnits.metre,     0},
            {SiMetricUnits.decametre, 1},
            {SiMetricUnits.hectometre,2},
            {SiMetricUnits.kilometre, 3},
            {SiMetricUnits.megametre, 6},
            {SiMetricUnits.gigametre, 9},
            {SiMetricUnits.terametre, 12},
            {SiMetricUnits.petametre, 15},
            {SiMetricUnits.exametre, 18},
            {SiMetricUnits.zettametre,21},
            {SiMetricUnits.yottametre,24}
            };
        private static Dictionary<SiMetricUnits, string> _symbols = new Dictionary<SiMetricUnits, string> {
            {SiMetricUnits.yoktometre, "ym"},
            {SiMetricUnits.zeptometre,"zm"},
            {SiMetricUnits.attometre, "am"},
            {SiMetricUnits.femtometre,"fm"},
            {SiMetricUnits.picometre, "pm"},
            {SiMetricUnits.nanometre, "nm"},
            {SiMetricUnits.micrometre,"µm"},
            {SiMetricUnits.milimetre, "mm"},
            {SiMetricUnits.centimetre,"cm"},
            {SiMetricUnits.decimetre, "dm"},
            {SiMetricUnits.metre,     "m"},
            {SiMetricUnits.decametre, "dam"},
            {SiMetricUnits.hectometre, "hm"},
            {SiMetricUnits.kilometre, "km"},
            {SiMetricUnits.megametre, "Mm"},
            {SiMetricUnits.gigametre, "Gm"},
            {SiMetricUnits.terametre, "Tm"},
            {SiMetricUnits.petametre, "Pm"},
            {SiMetricUnits.exametre, "Em"},
            {SiMetricUnits.zettametre,"Zm"},
            {SiMetricUnits.yottametre,"Ym"}
            };
        internal static double GetMetre(this MetricLength metric)
        {
            if(metric.Unit == SiMetricUnits.metre) return metric.Value;
            int scaler = _scalers[metric.Unit];
            return metric.Value * Math.Pow(10, scaler * metric.Degree);
        }
        internal static double GetUnitValue(this double value, SiMetricUnits unit, int degree)
        {
            if (unit == SiMetricUnits.metre) return value;
            int scaler = -1 * _scalers[unit];
            return value * Math.Pow(10, scaler*degree);
        }

#if BENCHMARK
        internal static double GetMetre(this MetricLengthClass metric)
        {
            if (metric.Unit == SiMetricUnits.metre) return metric.Value;
            int scaler = _scalers[metric.Unit];
            return metric.Value * Math.Pow(10, scaler * metric.Degree);
        }
        internal static string GetSymbol(this MetricLengthClass metric)
        {
            return _symbols[metric.Unit];
        }
#endif
    }
}
