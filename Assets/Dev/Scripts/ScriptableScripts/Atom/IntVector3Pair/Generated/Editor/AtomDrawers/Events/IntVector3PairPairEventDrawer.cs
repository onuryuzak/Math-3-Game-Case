#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `IntVector3PairPair`. Inherits from `AtomDrawer&lt;IntVector3PairPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IntVector3PairPairEvent))]
    public class IntVector3PairPairEventDrawer : AtomDrawer<IntVector3PairPairEvent> { }
}
#endif
