#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `IntVector3Pair`. Inherits from `AtomDrawer&lt;IntVector3PairVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IntVector3PairVariable))]
    public class IntVector3PairVariableDrawer : VariableDrawer<IntVector3PairVariable> { }
}
#endif
