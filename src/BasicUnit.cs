﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public interface IBasicUnit
    {
        double Value { get; }
        int Degree { get; }
        String Symbol { get; }
        int UnitOrder { get; }
        double GetValueBy(int unitOrder);
        IBasicUnit NewInstance(double value, int degree, int unitOrder);
        DerivedUnit ToCompositeUnit();
    }
}
