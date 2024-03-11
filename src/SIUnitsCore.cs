using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    internal class SIUnitsCore
    {
        SIUnitsCore _instance;
        internal SIUnitsCore Instance { get { return _instance ?? new SIUnitsCore(); } }
        internal List<Guid> UnitIdList; 
        internal Dictionary<Guid, Type> UnitDictionary;
        internal SIUnitsCore()
        {
            UnitIdList = new List<Guid>
            {
                MetricLength.ID,
                MetricTime.ID,
                MetricMass.ID,
                Ampere.ID,
                Temperature.ID,
            };
            UnitDictionary = new Dictionary<Guid, Type>
            {
                { MetricLength.ID, typeof(MetricLength)},
                { MetricTime.ID, typeof(MetricTime)},
                { MetricMass.ID, typeof(MetricMass)},
                { Ampere.ID, typeof(Ampere)},
                { Temperature.ID, typeof(Temperature)},
            };
        }
    }
}
