using SIUnits.Length;
using SIUnits.Mass;
using SIUnits.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    internal sealed class CompositeUnit
    {
        readonly MetricLength l_unit;
        readonly MetricTime t_unit;
        readonly MetricMass m_unit;

        CompositeUnit() :this(new MetricLength(), new MetricTime(), new MetricMass())
        {

        }
        CompositeUnit(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            l_unit = lengthUnit;
            t_unit = timeUnit;
            m_unit = massUnit;
        }

        public double Value { get; }
        public string Symbol { get; }


    }
}
