using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `IntVector3Pair`. Inherits from `AtomReference&lt;IntVector3Pair, IntVector3PairPair, IntVector3PairConstant, IntVector3PairVariable, IntVector3PairEvent, IntVector3PairPairEvent, IntVector3PairIntVector3PairFunction, IntVector3PairVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IntVector3PairReference : AtomReference<
        IntVector3Pair,
        IntVector3PairPair,
        IntVector3PairConstant,
        IntVector3PairVariable,
        IntVector3PairEvent,
        IntVector3PairPairEvent,
        IntVector3PairIntVector3PairFunction,
        IntVector3PairVariableInstancer>, IEquatable<IntVector3PairReference>
    {
        public IntVector3PairReference() : base() { }
        public IntVector3PairReference(IntVector3Pair value) : base(value) { }
        public bool Equals(IntVector3PairReference other) { return base.Equals(other); }
        protected override bool ValueEquals(IntVector3Pair other)
        {
            throw new NotImplementedException();
        }
    }
}
