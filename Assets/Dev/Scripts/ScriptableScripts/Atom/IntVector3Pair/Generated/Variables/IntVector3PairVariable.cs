using UnityEngine;
using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `IntVector3Pair`. Inherits from `AtomVariable&lt;IntVector3Pair, IntVector3PairPair, IntVector3PairEvent, IntVector3PairPairEvent, IntVector3PairIntVector3PairFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/IntVector3Pair", fileName = "IntVector3PairVariable")]
    public sealed class IntVector3PairVariable : AtomVariable<IntVector3Pair, IntVector3PairPair, IntVector3PairEvent, IntVector3PairPairEvent, IntVector3PairIntVector3PairFunction>
    {
        protected override bool ValueEquals(IntVector3Pair other)
        {
            throw new NotImplementedException();
        }
    }
}
