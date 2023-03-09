using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `IntVector3PairPair`. Inherits from `AtomEventReferenceListener&lt;IntVector3PairPair, IntVector3PairPairEvent, IntVector3PairPairEventReference, IntVector3PairPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/IntVector3PairPair Event Reference Listener")]
    public sealed class IntVector3PairPairEventReferenceListener : AtomEventReferenceListener<
        IntVector3PairPair,
        IntVector3PairPairEvent,
        IntVector3PairPairEventReference,
        IntVector3PairPairUnityEvent>
    { }
}
