using UnityEditor;
using UnityEngine;

namespace PersistentSO.Editor
{
    public class PersistentSOManagerWindow : EditorWindow
    {
        #region PRIVATE FIELDS

        private bool showAllPersistents;

        #endregion

        #region PUBLIC MENU METHODS

        [MenuItem("Tools/PersistentSO/PersistentSOManager")]
        public static void OpenWindow()
        {
            GetWindow<PersistentSOManagerWindow>("Persistent SO Manager");
        }

        #endregion

        #region UNITY METHODS

        private void OnGUI()
        {
            ListAllPersistents();
            GUILayout.FlexibleSpace();
            ShowClearAllButton();
        }

        #endregion

        private void ShowClearAllButton()
        {
            if (GUILayout.Button("Clear All"))
            {
                PersistentSOHelper.ClearAll();
            }
        }

        private void ListAllPersistents()
        {
            if (!PersistentSOHelper.ExistsAny())
            {
                GUILayout.Label("No Persistent Scriptable Objects found!", EditorStyles.boldLabel);
                return;
            }

            var guids = PersistentSOHelper.GetAllGuids();
            showAllPersistents =
                EditorGUILayout.BeginFoldoutHeaderGroup(showAllPersistents, "Persistent Scriptable Objects");

            if (showAllPersistents)
            {
                foreach (var guid in guids)
                {
                    var guidHexString = guid.ToHexString();
                    var path = AssetDatabase.GUIDToAssetPath(guidHexString);
                    var so = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
                    if (!string.IsNullOrEmpty(path) && so)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.ObjectField(so, so.GetType(), false);
                        if (GUILayout.Button("Clear", GUILayout.Width(100)))
                        {
                            PersistentSOHelper.Clear(guidHexString);
                        }

                        EditorGUILayout.EndHorizontal();
                    }
                }
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}