using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    public struct DerivedDegree
    {
        /// <summary>
        /// initializes a new DerivedDegree mostly needed to check degree of a DerivedUnit.
        /// </summary>
        /// <param name="lengthDegree"></param>
        /// <param name="timeDegree"></param>
        /// <param name="massDegree"></param>
        public DerivedDegree(int lengthDegree, int timeDegree, int massDegree, int ampereDegree )
        {
            l_degree = lengthDegree;
            t_degree = timeDegree;
            m_degree = massDegree;
            a_degree = ampereDegree;
        }
        /// <summary>
        /// degree of the length unit component of the derivedUnit
        /// </summary>
        public readonly int l_degree;
        /// <summary>
        /// degree of the time unit component of the derivedUnit
        /// </summary>
        public readonly int t_degree;
        /// <summary>
        /// degree of the mass unit component of the derivedUnit
        /// </summary>
        public readonly int m_degree;
        /// <summary>
        /// degree of the ampere unit component of the derivedUnit
        /// </summary>
        public readonly int a_degree;
        public static DerivedDegree operator +(DerivedDegree a, DerivedDegree b)
        {
            DerivedDegree newDegree = new DerivedDegree(a.l_degree + b.l_degree, a.t_degree + b.t_degree, a.m_degree + b.m_degree, a.a_degree + b.a_degree);
            return newDegree;
        }
        public static DerivedDegree operator -(DerivedDegree a, DerivedDegree b)
        {
            DerivedDegree newDegree = new DerivedDegree(a.l_degree - b.l_degree, a.t_degree - b.t_degree, a.m_degree - b.m_degree, a.a_degree - b.a_degree);
            return newDegree;
        }
        /// <summary>
        /// two derived units are equal if the degrees of all of the unit components in the derived unit are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            
            if (obj is DerivedDegree)
            {
                var rival = (DerivedDegree)obj;
                return l_degree == rival.l_degree &&
                    t_degree == rival.t_degree &&
                    m_degree == rival.m_degree &&
                    a_degree == rival.a_degree;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// returns hashcode of the DerivedUnit. If all the degrees of each unit components are equal, the hashcode is also equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (new Tuple<int,int,int,int>(l_degree, t_degree, m_degree,a_degree)).GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        /// <summary>
        /// two derived units are equal if the degrees of all of the unit components in the derived unit are equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(DerivedDegree a, DerivedDegree b) => a.Equals(b);
        /// <summary>
        /// two derived units are not equal if degree of any of the unit components in the derived unit is not equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(DerivedDegree a, DerivedDegree b) => !a.Equals(b);
    }
}
