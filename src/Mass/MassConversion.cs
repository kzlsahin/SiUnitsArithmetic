using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    internal static class MassConversion
    {
        internal static double GetScaler(SiMassUnits unit)
        {
            return _scalers[unit];
        }
        internal static string GetSymbol(this MetricMass metric)
        {
            return _symbols[metric.Unit];
        }
        private static Dictionary<SiMassUnits, int> _scalers = new Dictionary<SiMassUnits, int> {
            {SiMassUnits.picogram,      -12 },
            {SiMassUnits.nanogram,      -9 },
            {SiMassUnits.microgram,     -6 },
            {SiMassUnits.miligram,      -3 },
            {SiMassUnits.centigram,     -2 },
            {SiMassUnits.decigram,      -1 },
            {SiMassUnits.gram,          0 },
            {SiMassUnits.decagram,      1 },
            {SiMassUnits.hectogram,     2 },
            {SiMassUnits.kilogram,      3 },
            {SiMassUnits.tonne,         6 },
            {SiMassUnits.kilotonne,     9 },
            {SiMassUnits.megatonne,     12 },
            };
        private static Dictionary<SiMassUnits, string> _symbols = new Dictionary<SiMassUnits, string>
        {
            {SiMassUnits.picogram,      "pg" },
            {SiMassUnits.nanogram,      "ng" },
            {SiMassUnits.microgram,     "µg" },
            {SiMassUnits.miligram,      "mg" },
            {SiMassUnits.centigram,     "cg" },
            {SiMassUnits.decigram,      "dg" },
            {SiMassUnits.gram,          "g" },
            {SiMassUnits.decagram,      "dag" },
            {SiMassUnits.hectogram,     "hg" },
            {SiMassUnits.kilogram,      "kg" },
            {SiMassUnits.tonne,         "t" },
            {SiMassUnits.kilotonne,     "kt" },
            {SiMassUnits.megatonne,     "Mt" },
        };
        internal static double GetSecond(this MetricMass mass)
        {
            if (mass.Unit == SiMassUnits.gram) return mass.Value;
            double scaler = _scalers[mass.Unit];
            return mass.Value * Math.Pow(10, scaler * mass.Degree);
        }
        internal static double GetUnitValue(this double value, SiMassUnits unit, int degree)
        {
            if (unit == SiMassUnits.gram) return value;
            double scaler = -1 * _scalers[unit];
            return value * Math.Pow(10, scaler * degree); ;
        }
    }
}
