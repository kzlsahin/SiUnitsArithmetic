using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public abstract class PrimitiveUnit<T>
        where T : PrimitiveUnit<T>
    {
        public abstract string symbol { get; }
        protected abstract int _exponent { get; }

        public double m_value { get; internal set; }
        public const double MinValue = Double.MinValue;
        public const double MaxValue = Double.MaxValue;
        public PrimitiveUnit()
        {
            m_value = 0;
        }
        public PrimitiveUnit(double value)
        {
            m_value = value;
        }

        public static implicit operator PrimitiveUnit<T>(double value)
        {
            T newT =  (T)Activator.CreateInstance(typeof(T));
            newT.m_value = value;
            return newT;
        }
        public static implicit operator PrimitiveUnit<T>(float value)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = value;
            return newT;
        }
        public static implicit operator PrimitiveUnit<T>(int value)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = value;
            return newT;
        }

        public static T operator +(PrimitiveUnit<T> a) => (T)a;
        public static T operator -(PrimitiveUnit<T> a) => (-1d) * a;

        public static PrimitiveUnit<T> operator +(double d, PrimitiveUnit<T> a)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = d + a.m_value;
            return newT;
        }
        public static PrimitiveUnit<T> operator +(PrimitiveUnit<T> a, double d)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = d + a.m_value;
            return newT;
        }

        public static PrimitiveUnit<T> operator -(double d, PrimitiveUnit<T> a)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = d - a.m_value;
            return newT;
        }
        public static PrimitiveUnit<T> operator -(PrimitiveUnit<T> a, double d)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = d - a.m_value;
            return newT;
        }
        public static T operator *(PrimitiveUnit<T> a, double b)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = a.m_value * b;
            return newT;
        }
        public static T operator *(double a, PrimitiveUnit<T> b)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = a * b.m_value;
            return newT;
        }

        public static PrimitiveUnit<T> operator /(double d, PrimitiveUnit<T> a)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = d / a.m_value;
            return newT;
        }
        public static PrimitiveUnit<T> operator /(PrimitiveUnit<T> a, double d)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.m_value = a.m_value / d;
            return newT;
        }
    }
}
