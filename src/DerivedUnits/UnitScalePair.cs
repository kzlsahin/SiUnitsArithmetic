using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.DerivedUnits
{
    public class UnitScalePair
    {
        public static UnitScalePair New(Guid unitId, int scaleOrder)
        {
            return new UnitScalePair(unitId, scaleOrder);
        }
        private UnitScalePair(Guid unitId, int scaleOrder)
        {
            this.UnitId = unitId;
            this.ScaleUnit = scaleOrder;
        }
        public Guid UnitId { get; private set; }
        public int ScaleUnit { get; private set; }
    }
}
