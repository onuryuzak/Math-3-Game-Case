#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IntVector3Pair`. Inherits from `AtomEventEditor&lt;IntVector3Pair, IntVector3PairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(IntVector3PairEvent))]
    public sealed class IntVector3PairEventEditor : AtomEventEditor<IntVector3Pair, IntVector3PairEvent> { }
}
#endif
