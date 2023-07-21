using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Conversion
{
    internal interface IConvertor<T, U> where T: Metric<U>
    {
        double GetScaler(SiTimeUnits unit);
        string GetSymbol(this MetricTime metric);
    }
}
