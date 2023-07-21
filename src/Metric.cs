using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public interface Metric<T> where T : Enum
    {
        double Value { get; }
        int Degree { get; }
        T Unit { get; }
        Metric<T> NewInstance(double value, int degree, T unit);
    }
}
