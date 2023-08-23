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
            _constructorMap = new Dictionary<DerivedDegree, Func<MetricLength, MetricTime, MetricMass, Ampere, DerivedUnit>>();
            _constructorMap.Add(Newton.refDegree, Newton.New);
            _constructorMap.Add(Joule.refDegree, Joule.New);
        }

        Dictionary<DerivedDegree, Func<MetricLength, MetricTime, MetricMass, Ampere, DerivedUnit>> _constructorMap;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="refdegree"></param>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public bool RegisterSpecialUnit<T>(DerivedDegree refdegree, Func<MetricLength, MetricTime, MetricMass, Ampere, CustomSpecialUnit<T>> constructor) where T : CustomSpecialUnit<T>
        {
            bool res = AddConstructor(refdegree, constructor);
            if (UnitConfig.Protectionlevel < 1)
            {
                return res;
            }
            else
            {
                if(res == false)
                {
                    throw new InvalidOperationException("The special unit you have been trying to register has the same combination of unit degrees with an existing special unit.");
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="refDegree"></param>
        /// <param name="contructor"></param>
        /// <returns></returns>
        internal bool AddConstructor(DerivedDegree refDegree, Func<MetricLength, MetricTime, MetricMass, Ampere, DerivedUnit> contructor)
        {
            if (_constructorMap.ContainsKey(refDegree))
            {
                return false;
            }
            _constructorMap.Add(refDegree, contructor);
            return true;
        }
        internal bool GetSpecialUnitContructor(DerivedDegree degree, out Func<MetricLength, MetricTime, MetricMass, Ampere, DerivedUnit> contructor)
        {
            if(_constructorMap.TryGetValue(degree, out contructor))
            {
                return true;
            }
            return false;
        }
    }
}
