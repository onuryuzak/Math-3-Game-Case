#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IntVector3Pair`. Inherits from `AtomDrawer&lt;IntVector3PairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IntVector3PairEvent))]
    public class IntVector3PairEventDrawer : AtomDrawer<IntVector3PairEvent> { }
}
#endif
