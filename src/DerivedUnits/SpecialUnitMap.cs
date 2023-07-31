using System;
using System.Collections.Generic;
using System.Text;

namespace SIUnits
{
    internal class SpecialUnitMap
    {
        static SpecialUnitMap _instance;
        public static SpecialUnitMap Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpecialUnitMap();
                }
                return _instance;
            }
        }
        SpecialUnitMap()
        {
            _constcutorMap = new Dictionary<DerivedDegree, Func<MetricLength, MetricTime, MetricMass, DerivedUnit>>();
            _constcutorMap.Add(Newton.refDegree, Newton.New);
            _constcutorMap.Add(Joule.refDegree, Joule.New);
        }

        Dictionary<DerivedDegree, Func<MetricLength, MetricTime, MetricMass, DerivedUnit>> _constcutorMap;
        public bool RegisterSpecialUnit<T>(DerivedDegree degree, Func<MetricLength, MetricTime, MetricMass, CustomSpecialUnit<T>> constructor) where T : CustomSpecialUnit<T>
        {
            return AddConstructor(degree, constructor);
        }
        internal bool AddConstructor(DerivedDegree degree, Func<MetricLength, MetricTime, MetricMass, DerivedUnit> contructor)
        {
            if (_constcutorMap.ContainsKey(degree))
            {
                return false;
            }
            _constcutorMap.Add(degree, contructor);
            return true;
        }
        internal bool GetSpecialUnitContructor(DerivedDegree degree, out Func<MetricLength, MetricTime, MetricMass, DerivedUnit> contructor)
        {
            if(_constcutorMap.TryGetValue(degree, out contructor))
            {
                return true;
            }
            return false;
        }
    }
}
