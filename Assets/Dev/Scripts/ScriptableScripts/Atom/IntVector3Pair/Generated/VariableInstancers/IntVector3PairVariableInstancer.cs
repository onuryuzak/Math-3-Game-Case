using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `IntVector3Pair`. Inherits from `AtomVariableInstancer&lt;IntVector3PairVariable, IntVector3PairPair, IntVector3Pair, IntVector3PairEvent, IntVector3PairPairEvent, IntVector3PairIntVector3PairFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/IntVector3Pair Variable Instancer")]
    public class IntVector3PairVariableInstancer : AtomVariableInstancer<
        IntVector3PairVariable,
        IntVector3PairPair,
        IntVector3Pair,
        IntVector3PairEvent,
        IntVector3PairPairEvent,
        IntVector3PairIntVector3PairFunction>
    { }
}
