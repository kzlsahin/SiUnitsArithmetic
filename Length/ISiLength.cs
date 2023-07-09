using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits.Length
{
    public interface ISiLength
    {
        double m_value { get; }
        string symbol { get; }
    }
}
