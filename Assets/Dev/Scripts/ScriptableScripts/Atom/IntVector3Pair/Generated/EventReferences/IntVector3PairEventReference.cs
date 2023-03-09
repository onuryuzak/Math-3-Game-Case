using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `IntVector3Pair`. Inherits from `AtomEventReference&lt;IntVector3Pair, IntVector3PairVariable, IntVector3PairEvent, IntVector3PairVariableInstancer, IntVector3PairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IntVector3PairEventReference : AtomEventReference<
        IntVector3Pair,
        IntVector3PairVariable,
        IntVector3PairEvent,
        IntVector3PairVariableInstancer,
        IntVector3PairEventInstancer>, IGetEvent 
    { }
}
