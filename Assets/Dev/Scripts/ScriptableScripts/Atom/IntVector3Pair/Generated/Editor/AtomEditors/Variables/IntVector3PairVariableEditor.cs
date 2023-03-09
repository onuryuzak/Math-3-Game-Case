using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `IntVector3Pair`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(IntVector3PairVariable))]
    public sealed class IntVector3PairVariableEditor : AtomVariableEditor<IntVector3Pair, IntVector3PairPair> { }
}
