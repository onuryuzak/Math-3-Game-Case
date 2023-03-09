#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `IntVector3Pair`. Inherits from `AtomDrawer&lt;IntVector3PairConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(IntVector3PairConstant))]
    public class IntVector3PairConstantDrawer : VariableDrawer<IntVector3PairConstant> { }
}
#endif
