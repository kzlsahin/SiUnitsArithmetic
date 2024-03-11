using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIUnits
{
    /// <summary>
    /// Defines the composite degree identity of a unit
    /// </summary>
    public struct DerivedDegree
    {
        /// <summary>
        /// Degrees for each unit id
        /// </summary>
        public Dictionary<Guid, int> Degrees { get; private set; }
        /// <summary>
        /// Returns new DerivedUnit instance
        /// </summary>
        /// <param name="MemberUnits"></param>
        public DerivedDegree(Dictionary<Guid, IBasicUnit> MemberUnits)
        {
            Degrees = new Dictionary<Guid, int>();
            foreach(var MemberUnit in MemberUnits.Values)
            {
                Degrees.Add(MemberUnit.Id, MemberUnit.Degree);
            }
        }
        /// <summary>
        /// Returns new DerivedUnit instance
        /// </summary>
        /// <param name="degrees"></param>
        public DerivedDegree(params KeyValuePair<Guid, int>[] degrees)
        {
            Degrees = new Dictionary<Guid, int>();
            foreach (var MemberUnit in degrees)
            {
                Degrees.Add(MemberUnit.Key, MemberUnit.Value);
            }
        }
        /// <summary>
        /// two derived units are equal if the degrees of all of the unit components in the derived unit are equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is null)) return false;
            DerivedDegree other = (DerivedDegree)obj;
            foreach (var MemberDegree in Degrees)
            {
                if (other.Degrees.TryGetValue(MemberDegree.Key, out int degree))
                {
                    if( MemberDegree.Value != degree)
                    {
                        return false;
                    }
                }
                else
                {
                    if(MemberDegree.Value != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// returns hashcode of the DerivedUnit. If all the degrees of each unit components are equal, the hashcode is also equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
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
