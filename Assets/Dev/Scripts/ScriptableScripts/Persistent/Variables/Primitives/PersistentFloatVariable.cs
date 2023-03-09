using UnityEngine;

namespace PersistentSO
{
    [CreateAssetMenu(fileName = "PersistentFloatVariable",
        menuName = "ScriptableObjects/Persistent/PersistentFloatVariable")]
    public class PersistentFloatVariable : PersistentVariable<float>
    {
    }
}