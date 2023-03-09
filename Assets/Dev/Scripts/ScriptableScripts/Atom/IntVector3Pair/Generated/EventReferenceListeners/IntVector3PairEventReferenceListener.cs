using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `IntVector3Pair`. Inherits from `AtomEventReferenceListener&lt;IntVector3Pair, IntVector3PairEvent, IntVector3PairEventReference, IntVector3PairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/IntVector3Pair Event Reference Listener")]
    public sealed class IntVector3PairEventReferenceListener : AtomEventReferenceListener<
        IntVector3Pair,
        IntVector3PairEvent,
        IntVector3PairEventReference,
        IntVector3PairUnityEvent>
    { }
}
