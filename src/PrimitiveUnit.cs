using SIUnits.Length;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    public abstract class PrimitiveUnit<T> : SiUnit
        where T : PrimitiveUnit<T>
    {
        private static int _dimension = 1;        
        internal override int Dimension { get { return _dimension; } }
        public double Value { get; internal set; }
        public const double MinValue = Double.MinValue;
        public const double MaxValue = Double.MaxValue;
        public PrimitiveUnit()
        {
            Value = 0;
        }
        public PrimitiveUnit(double value)
        {
            Value = value;
        }

        public static implicit operator PrimitiveUnit<T>(double value)
        {
            T newT =  (T)Activator.CreateInstance(typeof(T));
            newT.Value = value;
            return newT;
        }
        public static implicit operator PrimitiveUnit<T>(float value)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = value;
            return newT;
        }
        public static implicit operator PrimitiveUnit<T>(int value)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = value;
            return newT;
        }

        public static T operator +(PrimitiveUnit<T> a) => (T)a;
        public static T operator -(PrimitiveUnit<T> a) => (-1d) * a;

        public static PrimitiveUnit<T> operator +(double d, PrimitiveUnit<T> a)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = d + a.Value;
            return newT;
        }
        public static PrimitiveUnit<T> operator +(PrimitiveUnit<T> a, double d)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = d + a.Value;
            return newT;
        }

        public static PrimitiveUnit<T> operator -(double d, PrimitiveUnit<T> a)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = d - a.Value;
            return newT;
        }
        public static PrimitiveUnit<T> operator -(PrimitiveUnit<T> a, double d)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = d - a.Value;
            return newT;
        }
        public static T operator *(PrimitiveUnit<T> a, double b)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = a.Value * b;
            return newT;
        }
        public static T operator *(double a, PrimitiveUnit<T> b)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = a * b.Value;
            return newT;
        }

        public static PrimitiveUnit<T> operator /(double d, PrimitiveUnit<T> a)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = d / a.Value;
            return newT;
        }
        public static PrimitiveUnit<T> operator /(PrimitiveUnit<T> a, double d)
        {
            T newT = (T)Activator.CreateInstance(typeof(T));
            newT.Value = a.Value / d;
            return newT;
        }
    }
}
