using UnityEngine;

namespace PersistentSO
{
    [CreateAssetMenu(fileName = "PersistentIntVariable",
        menuName = "ScriptableObjects/Persistent/PersistentIntVariable")]
    public class PersistentIntVariable : PersistentVariable<int>
    {
    }
}