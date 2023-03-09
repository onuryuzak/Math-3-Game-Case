using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `IntVector3Pair`. Inherits from `AtomEvent&lt;IntVector3Pair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/IntVector3Pair", fileName = "IntVector3PairEvent")]
    public sealed class IntVector3PairEvent : AtomEvent<IntVector3Pair>
    {
    }
}
