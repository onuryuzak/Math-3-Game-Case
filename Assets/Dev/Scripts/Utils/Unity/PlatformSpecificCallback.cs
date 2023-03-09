using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class PlatformSpecificCallback : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [FoldoutGroup("Awake Events")] public UnityEvent OnIOSOnAwake;
    [FoldoutGroup("Awake Events")] public UnityEvent OnAndroidOnAwake;
    
    [FoldoutGroup("Start Events")] public UnityEvent OnIOSOnStart;
    [FoldoutGroup("Start Events")] public UnityEvent OnAndroidOnStart;

    #endregion

    #region PRIVATE PROPERTIES

    private bool IsIOS => Application.platform == RuntimePlatform.IPhonePlayer;
    private bool IsAndroid => Application.platform == RuntimePlatform.Android;

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        if (IsIOS) OnIOSOnAwake?.Invoke();
        else if (IsAndroid) OnAndroidOnAwake?.Invoke();
    }
    
    private void Start()
    {
        if (IsIOS) OnIOSOnStart?.Invoke();
        else if (IsAndroid) OnAndroidOnStart?.Invoke();
    }

    #endregion
}