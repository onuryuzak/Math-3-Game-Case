using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `IntVector3Pair`. Inherits from `AtomValueList&lt;IntVector3Pair, IntVector3PairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/IntVector3Pair", fileName = "IntVector3PairValueList")]
    public sealed class IntVector3PairValueList : AtomValueList<IntVector3Pair, IntVector3PairEvent> { }
}
