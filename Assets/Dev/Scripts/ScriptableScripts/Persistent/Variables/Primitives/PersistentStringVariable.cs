using UnityEngine;

namespace PersistentSO
{
    [CreateAssetMenu(fileName = "PersistentStringVariable",
        menuName = "ScriptableObjects/Persistent/PersistentStringVariable")]
    public class PersistentStringVariable : PersistentVariable<string>
    {
    }
}