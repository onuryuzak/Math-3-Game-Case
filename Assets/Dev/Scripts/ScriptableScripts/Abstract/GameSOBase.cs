
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Base.Scriptables
{
    public abstract class GameSOBase : ScriptableObject
    {
        [ReadOnly] public string UID;

        #if UNITY_EDITOR
        [PropertySpace(SpaceAfter =10)]
        [Button("Reset ID",Style = ButtonStyle.Box)]
        private void ResetID()
        {
            if (EditorUtility.DisplayDialog("Are you sure?","You can lost data","Sure","Nope!"))
            {
                UID = GUID.Generate().ToString();
                EditorUtility.SetDirty(this);
            }
        }
        #endif
    }

}
