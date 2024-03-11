﻿using System;
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
        /// <typeparam name="T"></typeparam>
        /// <param name="refdegree"></param>
        /// <param name="constructor"></param>
        /// <returns></returns>
        public bool RegisterSpecialUnit<T>(DerivedDegree refdegree, Func<Dictionary<Guid, IBasicUnit>, CustomSpecialUnit<T>> constructor) where T : CustomSpecialUnit<T>
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
