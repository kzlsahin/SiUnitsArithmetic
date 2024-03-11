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
            _constructorMap = new Dictionary<DerivedDegree, Func<Dictionary<Guid, IBasicUnit>, DerivedUnit>>
            {
                { Newton.refDegree, Newton.New },
                { Newton.refDegree, Newton.New },
                { Volt.refDegree, Volt.New },
                { Ohm.refDegree, Ohm.New }
            };
        }

        Dictionary<DerivedDegree, Func<Dictionary<Guid, IBasicUnit>, DerivedUnit>> _constructorMap;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refDegree"></param>
        /// <param name="contructor"></param>
        /// <returns></returns>
        internal bool AddConstructor(DerivedDegree refDegree, Func<Dictionary<Guid, IBasicUnit>, DerivedUnit> contructor)
        {
            if (_constructorMap.ContainsKey(refDegree))
            {
                return false;
            }
            _constructorMap.Add(refDegree, contructor);
            return true;
        }
        internal bool GetSpecialUnitContructor(DerivedDegree degree, out Func<Dictionary<Guid, IBasicUnit>, DerivedUnit> contructor)
        {
            if(_constructorMap.TryGetValue(degree, out contructor))
            {
                return true;
            }
            return false;
        }
    }
}
