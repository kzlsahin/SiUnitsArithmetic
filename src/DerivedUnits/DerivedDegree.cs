using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public struct DerivedDegree
    {
        public DerivedDegree(int lengthDegree, int timeDegree, int massDegree )
        {
            l_degree = lengthDegree;
            t_degree = timeDegree;
            m_degree = massDegree;
        }
        public readonly int l_degree;
        public readonly int t_degree;
        public readonly int m_degree;

        public override bool Equals(object obj)
        {
            
            if (obj is DerivedDegree)
            {
                var rival = (DerivedDegree)obj;
                return l_degree == rival.l_degree &&
                    t_degree == rival.t_degree &&
                    m_degree == rival.m_degree;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(DerivedDegree a, DerivedDegree b) => a.Equals(b);
        public static bool operator !=(DerivedDegree a, DerivedDegree b) => !a.Equals(b);
    }
}
