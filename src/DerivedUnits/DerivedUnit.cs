using SIUnits.Length;
using SIUnits.Mass;
using SIUnits.Time;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SIUnits
{
    public sealed class DerivedUnit
    {
        readonly MetricLength l_unit;
        readonly MetricTime t_unit;
        readonly MetricMass m_unit;
        public DerivedUnit(MetricLength l) : this(l, new MetricTime(1,0,SiTimeUnits.second), new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        public DerivedUnit(MetricTime t) : this(new MetricLength(1, 0, SiMetricUnits.metre), t, new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        public DerivedUnit(MetricMass m) : this(new MetricLength(1, 0, SiMetricUnits.metre), new MetricTime(1, 0, SiTimeUnits.second), m)
        {

        }
        DerivedUnit() : this(new MetricLength(1, 0, SiMetricUnits.metre), new MetricTime(1, 0, SiTimeUnits.second), new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        DerivedUnit(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            l_unit = lengthUnit;
            t_unit = timeUnit;
            m_unit = massUnit;
            Degree = new DerivedDegree(l_unit.Degree, t_unit.Degree, m_unit.Degree);
        }

        public double Value { get { return l_unit.Value * t_unit.Value * m_unit.Value; } }
        public string Symbol { get; }
        public DerivedDegree Degree { get; private set; }

        #region operators
        public static DerivedUnit operator *(DerivedUnit a, DerivedUnit b) => DerivedUnit.Multiply(a, b);
        public static DerivedUnit operator *(DerivedUnit a, MetricLength b) => DerivedUnit.Multiply(a, b);
        public static DerivedUnit operator *(DerivedUnit a, double b) => DerivedUnit.Multiply(a, b);
        public static DerivedUnit operator *(double a, DerivedUnit b) => DerivedUnit.Multiply(b, a);
        public static DerivedUnit operator /(DerivedUnit a, DerivedUnit b) => DerivedUnit.Divide(a, b);
        public static DerivedUnit operator /(DerivedUnit a, double b) => DerivedUnit.Divide(a, b);
        public static DerivedUnit operator /(double a, DerivedUnit b) => DerivedUnit.Divide(a, b);
        public static DerivedUnit operator +(DerivedUnit a, DerivedUnit b) => DerivedUnit.Sum(a, b);
        public static DerivedUnit operator -(DerivedUnit a, DerivedUnit b) => DerivedUnit.Subtract(a, b);

        #endregion

        #region conversions

        public static implicit operator DerivedUnit(MetricLength l)
        {
            return new DerivedUnit(l);
        }
        public static implicit operator DerivedUnit(MetricTime t)
        {
            return new DerivedUnit(t);
        }
        public static implicit operator DerivedUnit(MetricMass m)
        {
            return new DerivedUnit(m);
        }
        #endregion

        public static DerivedUnit Multiply(DerivedUnit a, DerivedUnit b)
        {
            MetricLength newL = a.l_unit * b.l_unit;
            MetricTime newT = a.t_unit * b.t_unit;
            MetricMass newM = a.m_unit * b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }

        public static DerivedUnit Multiply(DerivedUnit a, double b)
        {
            MetricLength newL = a.l_unit * b;
            MetricTime newT = a.t_unit * b;
            MetricMass newM = a.m_unit * b;
            return new DerivedUnit(newL, newT, newM);
        }

        public static DerivedUnit Sum(DerivedUnit a, DerivedUnit b)
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
        public static DerivedUnit Subtract(DerivedUnit a, DerivedUnit b)
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
        public static DerivedUnit Divide(DerivedUnit a, DerivedUnit b)
        {
            MetricLength newL = a.l_unit / b.l_unit;
            MetricTime newT = a.t_unit / b.t_unit;
            MetricMass newM = a.m_unit / b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }
        public static DerivedUnit Divide(DerivedUnit a, double b)
        {
            MetricLength newL = a.l_unit / b;
            MetricTime newT = a.t_unit / b;
            MetricMass newM = a.m_unit / b;
            return new DerivedUnit(newL, newT, newM);
        }
        public static DerivedUnit Divide(double a, DerivedUnit b)
        {
            MetricLength newL = a / b.l_unit;
            MetricTime newT = a / b.t_unit;
            MetricMass newM = a / b.m_unit;
            return new DerivedUnit(newL, newT, newM);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Value.ToString());
            sb.Append(" ");
            bool preceded = false;
            if(l_unit.Degree > 0)
            {
                sb.Append($"{l_unit.Symbol}({l_unit.Degree})");
                preceded = true;
            }
            if(t_unit.Degree > 0)
            {
                if (preceded) sb.Append(".");
                sb.Append($"{t_unit.Symbol}({t_unit.Degree})");
                preceded = true;
            }
            if(m_unit.Degree > 0)
            {
                if (preceded) sb.Append(".");
                sb.Append($"{m_unit.Symbol}({m_unit.Degree})");
            }
            bool subproceded = false;
            if (l_unit.Degree < 0)
            {
                if (preceded) sb.Append("/");
                sb.Append($"{l_unit.Symbol}({-1 * l_unit.Degree})");
                subproceded = true;
                preceded=false;
            }
            if (t_unit.Degree < 0)
            {
                if (preceded) sb.Append("/");
                if (subproceded) sb.Append(".");
                sb.Append($"{t_unit.Symbol}({-1 * t_unit.Degree})");
                subproceded = true;
                preceded = false;
            }
            if (m_unit.Degree < 0)
            {
                if (preceded) sb.Append("/");
                if (subproceded) sb.Append(".");
                sb.Append($"{m_unit.Symbol}({-1 * m_unit.Degree})");
            }
            return sb.ToString();
        }
    }
}
