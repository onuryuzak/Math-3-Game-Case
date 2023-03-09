using System;
using UnityEngine;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;IntVector3Pair&gt;`. Inherits from `IPair&lt;IntVector3Pair&gt;`.
    /// </summary>
    [Serializable]
    public struct IntVector3PairPair : IPair<IntVector3Pair>
    {
        public IntVector3Pair Item1 { get => _item1; set => _item1 = value; }
        public IntVector3Pair Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private IntVector3Pair _item1;
        [SerializeField]
        private IntVector3Pair _item2;

        public void Deconstruct(out IntVector3Pair item1, out IntVector3Pair item2) { item1 = Item1; item2 = Item2; }
    }
}