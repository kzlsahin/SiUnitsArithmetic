using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{

    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
    public class SiSymbolAttribute : System.Attribute
    {
        public string Symbol;

        public SiSymbolAttribute(string symbol)
        {
            Symbol = symbol;
        }
    }
    internal static class SiSymbols
    {

    }
}
