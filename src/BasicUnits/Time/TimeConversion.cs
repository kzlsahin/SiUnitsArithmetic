using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Time
{
    internal static class TimeConversion
    {
        internal static double GetScaler(SiTimeUnits unit)
        {
            return _scalers[unit];
        }
        internal static string GetSymbol(this MetricTime metric)
        {
            return _symbols[metric.UnitOrder];
        }
        private static Dictionary<SiTimeUnits, double> _scalers = new Dictionary<SiTimeUnits, double> {
            {SiTimeUnits.picosecond,   Math.Pow(10, -12)},
            {SiTimeUnits.nanosecond,   Math.Pow(10, -9) },
            {SiTimeUnits.microsecond,  Math.Pow(10, -6) },
            {SiTimeUnits.milisecond,   Math.Pow(10, -3) },
            {SiTimeUnits.second,       1 },
            {SiTimeUnits.minute,       60 },
            {SiTimeUnits.hour,         3600 },
            {SiTimeUnits.day,          24 * 3600},
            };
        private static Dictionary<SiTimeUnits, string> _symbols = new Dictionary<SiTimeUnits, string>
        {
            {SiTimeUnits.picosecond,   "picosec"},
            {SiTimeUnits.nanosecond,   "nanosec"},
            {SiTimeUnits.microsecond,  "microsec"},
            {SiTimeUnits.milisecond,   "milisec" },
            {SiTimeUnits.second,       "sec" },
            {SiTimeUnits.minute,       "min" },
            {SiTimeUnits.hour,         "hour" },
            {SiTimeUnits.day,          "day"},
        };
        internal static double GetSecond(this MetricTime time)
        {
            if (time.UnitOrder == SiTimeUnits.second) return time.Value;
            double scaler = Math.Pow(_scalers[time.UnitOrder], time.Degree);
            return time.Value * scaler;
        }
        internal static double GetUnitValue(this MetricTime t, SiTimeUnits unit, int degree)
        {
            if (unit == t.UnitOrder) return t.Value;
            double baseScaler = Math.Pow(_scalers[t.UnitOrder], degree);
            double targetScaler = Math.Pow(_scalers[unit], degree);
            return t.Value * baseScaler / targetScaler;
        }
    }
}
