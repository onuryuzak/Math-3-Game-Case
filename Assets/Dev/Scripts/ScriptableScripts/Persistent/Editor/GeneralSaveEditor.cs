using PersistentSO;
using UnityEditor;
using UnityEngine;

public class GeneralSaveEditor : EditorWindow
{
    [MenuItem("Tools/GeneralSaveEditor")]
    private static void Init()
    {
        GeneralSaveEditor window =
            (GeneralSaveEditor) GetWindow(typeof(GeneralSaveEditor));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Clear AllPlayerPrefs"))
        {
            ClearAllPlayerPrefs();
        }

        if (GUILayout.Button("Clear PersistentSOs"))
        {
            PersistentSOHelper.ClearAll();
        }

        if (GUILayout.Button("Clear All"))
        {
            ClearAllPlayerPrefs();
            PersistentSOHelper.ClearAll();
        }
    }

    private void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}