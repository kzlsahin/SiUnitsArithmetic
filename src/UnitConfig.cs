using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public static class UnitConfig
    {
        /// <summary>
        /// Sets global unit precision as power of ten (if 3, it means 10^-3, 3 digits after seperator) for the metric units of the namespace SIUnits. 
        /// Equality of the units are effected by this precision and 
        /// ToString() method writes unit values by digits as many as the value of the precision.
        /// </summary>
        /// <remarks>This value changes ToString() behavior of the units. To set back to default behavior, set its value to zero.</remarks>
        public static int UnitPrecision { get; set; } = 0;
        public static int Protectionlevel { get; set; } = 2;
    }
}
