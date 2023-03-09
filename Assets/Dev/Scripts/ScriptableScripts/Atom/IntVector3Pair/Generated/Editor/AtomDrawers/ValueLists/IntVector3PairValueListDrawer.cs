#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `IntVector3Pair`. Inherits from `AtomDrawer&lt;IntVector3PairValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IntVector3PairValueList))]
    public class IntVector3PairValueListDrawer : AtomDrawer<IntVector3PairValueList> { }
}
#endif
