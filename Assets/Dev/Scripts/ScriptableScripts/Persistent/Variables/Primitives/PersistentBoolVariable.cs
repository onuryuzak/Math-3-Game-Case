using UnityEngine;

namespace PersistentSO
{
    [CreateAssetMenu(fileName = "PersistentBoolVariable",
        menuName = "ScriptableObjects/Persistent/PersistentBoolVariable")]
    public class PersistentBoolVariable : PersistentVariable<bool>
    {
    }
}