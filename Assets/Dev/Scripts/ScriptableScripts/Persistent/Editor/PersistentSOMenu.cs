using UnityEditor;
using UnityEngine;

namespace PersistentSO.Editor
{
    public class PersistentSOMenu : MonoBehaviour
    {
        [MenuItem("Tools/PersistentSO/Clear All")]
        static void ClearAll() => PersistentSOHelper.ClearAll();
    }
}