using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Adds Variable Instancer's Variable of type IntVector3Pair to a Collection or List on OnEnable and removes it on OnDestroy. 
    /// </summary>
    [AddComponentMenu("Unity Atoms/Sync Variable Instancer to Collection/Sync IntVector3Pair Variable Instancer to Collection")]
    [EditorIcon("atom-icon-delicate")]
    public class SyncIntVector3PairVariableInstancerToCollection : SyncVariableInstancerToCollection<IntVector3Pair, IntVector3PairVariable, IntVector3PairVariableInstancer> { }
}
