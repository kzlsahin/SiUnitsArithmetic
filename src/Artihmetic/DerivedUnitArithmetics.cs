using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIUnits.Artihmetic
{
    internal class DerivedUnitArithmetics
    {
        static DerivedUnitArithmetics _instance;
        DerivedUnitArithmetics()
        {

        }
        internal static DerivedUnitArithmetics Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DerivedUnitArithmetics();
                }
                return _instance;
            }
        }
        internal ArithmeticOperations basicOps = ArithmeticOperations.Instance;
        internal DerivedUnit Multiply(DerivedUnit a, DerivedUnit b)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            foreach(var unit in a.MemberUnits)
            {
                var id = unit.Key;
                memberUnits.Add(id, basicOps.Multiply(a.MemberUnits[id], b.MemberUnits[id]));
            }   
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }

        internal DerivedUnit Multiply(DerivedUnit a, double b)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            bool multiplied = false;
            foreach (var unit in a.MemberUnits)
            {
                var id = unit.Key;
                if (!multiplied)
                {
                    memberUnits.Add(id, basicOps.Multiply(b, unit.Value));
                }
                else
                {
                    memberUnits.Add(id, a.MemberUnits[id]);
                }
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }

        internal DerivedUnit Sum(DerivedUnit a, DerivedUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            double value_a = a.GetValueByRef(b);
            double value_b = b.Value;
            double value = value_a + value_b;
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            bool isSet = false;
            foreach (var unit in a.MemberUnits)
            {
                var id = unit.Key;
                var u = unit.Value;
                if (!isSet)
                {                    
                    memberUnits.Add(id, u.NewInstance(value, u.Degree, u.UnitOrder));
                }
                else
                {
                    memberUnits.Add(id, u.NewInstance(1, u.Degree, u.UnitOrder));
                }
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }
        internal DerivedUnit Subtract(DerivedUnit a, DerivedUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            double value_a = a.GetValueByRef(b);
            double value_b = b.Value;
            double value = value_a - value_b;
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            bool isSet = false;
            foreach (var unit in a.MemberUnits)
            {
                var id = unit.Key;
                var u = unit.Value;
                if (!isSet)
                {
                    memberUnits.Add(id, u.NewInstance(value, u.Degree, u.UnitOrder));
                }
                else
                {
                    memberUnits.Add(id, u.NewInstance(1, u.Degree, u.UnitOrder));
                }
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }
        internal DerivedUnit Divide(DerivedUnit a, DerivedUnit b)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            foreach (var unit in a.MemberUnits)
            {
                var id = unit.Key;
                memberUnits.Add(id, basicOps.Divide(a.MemberUnits[id], b.MemberUnits[id]));
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }
        internal DerivedUnit Divide(DerivedUnit a, double b)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            bool multiplied = false;
            foreach (var unit in a.MemberUnits)
            {
                var id = unit.Key;
                if (!multiplied)
                {
                    memberUnits.Add(id, basicOps.Divide(unit.Value, b));
                }
                else
                {
                    memberUnits.Add(id, unit.Value);
                }
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }
        internal DerivedUnit Divide(double a, DerivedUnit b)
        {
            var memberUnits = new Dictionary<Guid, IBasicUnit>();
            bool multiplied = false;
            foreach (var unit in b.MemberUnits)
            {
                var id = unit.Key;
                if (!multiplied)
                {
                    memberUnits.Add(id, basicOps.Divide(a, unit.Value));
                }
                else
                {
                    memberUnits.Add(id, basicOps.Divide(1, unit.Value));
                }
            }
            DerivedUnit newUnit = DerivedUnit.New(memberUnits);
            return newUnit;
        }
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        internal bool IsLessThen(DerivedUnit a, DerivedUnit b)
        {
            bool isEqual = a.Degree == b.Degree;
            bool lessThen;
            if (isEqual)
            {
                double value_a = a.GetValueByRef(b);
                lessThen = value_a < b.Value;
            }
            else
            {
                throw new ArgumentException("Degrees of units are different.");
            }
            return lessThen;
        }
        /// <summary>
        /// Checks if the value of a is less then value of b. Degrees of both units shall be equal.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">throws exception if degrees are not equal.</exception>
        internal bool IsGreaterThen(DerivedUnit a, DerivedUnit b)
        {
            bool isEqual = a.Degree == b.Degree;
            bool greaterThen;
            if (isEqual)
            {
                double value_a = a.GetValueByRef(b);
                greaterThen = value_a > b.Value;
            }
            else
            {
                throw new ArgumentException("Degrees of units are different.");
            }
            return greaterThen;
        }
        internal bool IsEqual(DerivedUnit a, DerivedUnit b)
        {
            double value_a = a.GetValueByRef(b);
            if (UnitConfig.UnitPrecision == 0)
            {
                return value_a == b.Value;
            }
            else 
            {
                return Math.Abs(value_a - b.Value) < Math.Pow(10, -1 * UnitConfig.UnitPrecision);
            }
        }
    }
}
