using System;
using System.Collections.Generic;
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
        internal DerivedUnit Multiply(DerivedUnit a, DerivedUnit b)
        {
            MetricLength newL = a.l_unit * b.l_unit;
            MetricTime newT = a.t_unit * b.t_unit;
            MetricMass newM = a.m_unit * b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }

        internal DerivedUnit Multiply(DerivedUnit a, double b)
        {
            MetricLength newL = a.l_unit * b;
            MetricTime newT = a.t_unit * b;
            MetricMass newM = a.m_unit * b;
            return new DerivedUnit(newL, newT, newM);
        }

        internal DerivedUnit Sum(DerivedUnit a, DerivedUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            MetricLength newL = a.l_unit + b.l_unit;
            MetricTime newT = a.t_unit + b.t_unit;
            MetricMass newM = a.m_unit + b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }
        internal DerivedUnit Subtract(DerivedUnit a, DerivedUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            MetricLength newL = a.l_unit - b.l_unit;
            MetricTime newT = a.t_unit - b.t_unit;
            MetricMass newM = a.m_unit - b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }
        internal DerivedUnit Divide(DerivedUnit a, DerivedUnit b)
        {
            MetricLength newL = a.l_unit / b.l_unit;
            MetricTime newT = a.t_unit / b.t_unit;
            MetricMass newM = a.m_unit / b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }
        internal DerivedUnit Divide(DerivedUnit a, double b)
        {
            MetricLength newL = a.l_unit / b;
            MetricTime newT = a.t_unit / b;
            MetricMass newM = a.m_unit / b;
            return new DerivedUnit(newL, newT, newM);
        }
        internal DerivedUnit Divide(double a, DerivedUnit b)
        {
            MetricLength newL = a / b.l_unit;
            MetricTime newT = a / b.t_unit;
            MetricMass newM = a / b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }
        internal bool IsEqual(DerivedUnit a, DerivedUnit b)
        {
            return a.l_unit == b.l_unit
                && a.m_unit == b.m_unit
                && a.t_unit == b.t_unit;
        }
    }
}
