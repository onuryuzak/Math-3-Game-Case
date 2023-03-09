using Base.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base.Scriptables
{
    public abstract class PrefabContaierSO :GameSOBase
    {
        public abstract IEnumerable<TypePrefabRegisterMap> GetRegisterMaps();
    }

}
