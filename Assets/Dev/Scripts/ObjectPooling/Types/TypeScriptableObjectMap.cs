using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Base.Scriptables;

namespace Base.ObjectPooling
{
    public class TypeScriptableObjectMap
    {
        public readonly Type type;
        public readonly GameSOBase gameSO;
        public readonly string variation;

        public TypeScriptableObjectMap(Type type, GameSOBase gameSO,string variation)
        {
            this.type = type;
            this.gameSO = gameSO;
            this.variation = variation;
        }
    }
}
