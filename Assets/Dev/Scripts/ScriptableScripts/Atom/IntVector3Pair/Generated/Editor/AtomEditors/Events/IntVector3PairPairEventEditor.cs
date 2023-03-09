#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IntVector3PairPair`. Inherits from `AtomEventEditor&lt;IntVector3PairPair, IntVector3PairPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(IntVector3PairPairEvent))]
    public sealed class IntVector3PairPairEventEditor : AtomEventEditor<IntVector3PairPair, IntVector3PairPairEvent> { }
}
#endif
