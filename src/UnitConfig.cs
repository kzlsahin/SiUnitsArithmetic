using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// Global configurations for SIUnitsAritmetic library.
    /// </summary>
    public static class UnitConfig
    {
        /// <summary>
        /// Default is 6
        /// Sets global unit precision as power of ten (if 3, it means 10^-3, 3 digits after seperator) for the metric units of the namespace SIUnits. 
        /// Equality of the units are effected by this precision and 
        /// ToString() method writes unit values by digits as many as the value of the precision.
        /// </summary>
        /// <remarks>This value changes ToString() behavior of the units. For no effect set this value to zero. This value affects the result of equality checks of units.</remarks>
        public static int UnitPrecision { get; set; } = 6;
        /// <summary>
        /// When protection level describes the level of throwing exception for inconcistent situations. When it is zero, some operator will return only boolean false instead of throwing exception. keep it as it is.
        /// </summary>
        public static int Protectionlevel { get; set; } = 2;
    }
}
