using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `IntVector3PairPair`. Inherits from `AtomEventReference&lt;IntVector3PairPair, IntVector3PairVariable, IntVector3PairPairEvent, IntVector3PairVariableInstancer, IntVector3PairPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IntVector3PairPairEventReference : AtomEventReference<
        IntVector3PairPair,
        IntVector3PairVariable,
        IntVector3PairPairEvent,
        IntVector3PairVariableInstancer,
        IntVector3PairPairEventInstancer>, IGetEvent 
    { }
}
