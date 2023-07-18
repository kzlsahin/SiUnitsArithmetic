using SIUnits.Length;
using SIUnits.Mass;
using SIUnits.Time;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SIUnits
{
    public sealed class CompositeUnit
    {
        readonly MetricLength l_unit;
        readonly MetricTime t_unit;
        readonly MetricMass m_unit;
        public CompositeUnit(MetricLength l) : this(l, new MetricTime(1,0,SiTimeUnits.second), new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        public CompositeUnit(MetricTime t) : this(new MetricLength(1, 0, SiMetricUnits.metre), t, new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        public CompositeUnit(MetricMass m) : this(new MetricLength(1, 0, SiMetricUnits.metre), new MetricTime(1, 0, SiTimeUnits.second), m)
        {

        }
        CompositeUnit() : this(new MetricLength(1, 0, SiMetricUnits.metre), new MetricTime(1, 0, SiTimeUnits.second), new MetricMass(1, 0, SiMassUnits.kilogram))
        {

        }
        CompositeUnit(MetricLength lengthUnit, MetricTime timeUnit, MetricMass massUnit)
        {
            l_unit = lengthUnit;
            t_unit = timeUnit;
            m_unit = massUnit;
            Degree = new CompositeDegree(l_unit.Degree, t_unit.Degree, m_unit.Degree);
        }

        public double Value { get { return l_unit.Value * t_unit.Value * m_unit.Value; } }
        public string Symbol { get; }
        public CompositeDegree Degree { get; private set; }

        #region operators
        public static CompositeUnit operator *(CompositeUnit a, CompositeUnit b) => CompositeUnit.Multiply(a, b);
        public static CompositeUnit operator *(CompositeUnit a, MetricLength b) => CompositeUnit.Multiply(a, b);
        public static CompositeUnit operator *(CompositeUnit a, double b) => CompositeUnit.Multiply(a, b);
        public static CompositeUnit operator *(double a, CompositeUnit b) => CompositeUnit.Multiply(b, a);
        public static CompositeUnit operator /(CompositeUnit a, CompositeUnit b) => CompositeUnit.Divide(a, b);
        public static CompositeUnit operator /(CompositeUnit a, double b) => CompositeUnit.Divide(a, b);
        public static CompositeUnit operator /(double a, CompositeUnit b) => CompositeUnit.Divide(a, b);
        public static CompositeUnit operator +(CompositeUnit a, CompositeUnit b) => CompositeUnit.Sum(a, b);
        public static CompositeUnit operator -(CompositeUnit a, CompositeUnit b) => CompositeUnit.Subtract(a, b);

        #endregion

        #region conversions

        public static implicit operator CompositeUnit(MetricLength l)
        {
            return new CompositeUnit(l);
        }
        public static implicit operator CompositeUnit(MetricTime t)
        {
            return new CompositeUnit(t);
        }
        public static implicit operator CompositeUnit(MetricMass m)
        {
            return new CompositeUnit(m);
        }
        #endregion

        public static CompositeUnit Multiply(CompositeUnit a, CompositeUnit b)
        {
            MetricLength newL = a.l_unit * b.l_unit;
            MetricTime newT = a.t_unit * b.t_unit;
            MetricMass newM = a.m_unit * b.m_unit;
            return new CompositeUnit(newL, newT, newM);
        }

        public static CompositeUnit Multiply(CompositeUnit a, double b)
        {
            MetricLength newL = a.l_unit * b;
            MetricTime newT = a.t_unit * b;
            MetricMass newM = a.m_unit * b;
            return new CompositeUnit(newL, newT, newM);
        }

        public static CompositeUnit Sum(CompositeUnit a, CompositeUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            MetricLength newL = a.l_unit + b.l_unit;
            MetricTime newT = a.t_unit + b.t_unit;
            MetricMass newM = a.m_unit + b.m_unit;
            return new CompositeUnit(newL, newT, newM);
        }
        public static CompositeUnit Subtract(CompositeUnit a, CompositeUnit b)
        {
            if (a.Degree != b.Degree)
            {
                throw new ArgumentException("various degrees of SiUnits cannot be summed");
            }
            MetricLength newL = a.l_unit - b.l_unit;
            MetricTime newT = a.t_unit - b.t_unit;
            MetricMass newM = a.m_unit - b.m_unit;
            return new CompositeUnit(newL, newT, newM);
        }
        public static CompositeUnit Divide(CompositeUnit a, CompositeUnit b)
        {
            MetricLength newL = a.l_unit / b.l_unit;
            MetricTime newT = a.t_unit / b.t_unit;
            MetricMass newM = a.m_unit / b.m_unit;
            return new CompositeUnit(newL, newT, newM);
        }
        public static CompositeUnit Divide(CompositeUnit a, double b)
        {
            MetricLength newL = a.l_unit / b;
            MetricTime newT = a.t_unit / b;
            MetricMass newM = a.m_unit / b;
            return new CompositeUnit(newL, newT, newM);
        }
        public static CompositeUnit Divide(double a, CompositeUnit b)
        {
            MetricLength newL = a / b.l_unit;
            MetricTime newT = a / b.t_unit;
            MetricMass newM = a / b.m_unit;
            return new CompositeUnit(newL, newT, newM);
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
