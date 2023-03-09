using UnityEngine;

namespace PersistentSO
{
    [CreateAssetMenu(fileName = "PersistentVector3Variable",
        menuName = "ScriptableObjects/Persistent/PersistentVector3Variable")]
    public class PersistentVector3Variable : PersistentVariable<Vector3>
    {
    }
}