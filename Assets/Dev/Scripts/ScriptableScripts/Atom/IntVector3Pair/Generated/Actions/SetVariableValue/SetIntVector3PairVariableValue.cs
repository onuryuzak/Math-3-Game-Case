using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `IntVector3Pair`. Inherits from `SetVariableValue&lt;IntVector3Pair, IntVector3PairPair, IntVector3PairVariable, IntVector3PairConstant, IntVector3PairReference, IntVector3PairEvent, IntVector3PairPairEvent, IntVector3PairVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/IntVector3Pair", fileName = "SetIntVector3PairVariableValue")]
    public sealed class SetIntVector3PairVariableValue : SetVariableValue<
        IntVector3Pair,
        IntVector3PairPair,
        IntVector3PairVariable,
        IntVector3PairConstant,
        IntVector3PairReference,
        IntVector3PairEvent,
        IntVector3PairPairEvent,
        IntVector3PairIntVector3PairFunction,
        IntVector3PairVariableInstancer>
    { }
}
