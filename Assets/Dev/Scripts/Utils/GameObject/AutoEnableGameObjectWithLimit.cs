using UnityEngine;
using UnityEngine.Events;

public class AutoEnableGameObjectWithLimit : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [Header("Settings")]
    [SerializeField] private int autoShowLimit = 2;
    
    [Header("Events")]
    [SerializeField] private UnityEvent OnEnabled;
    [SerializeField] private UnityEvent OnDisabled;
    [SerializeField] private UnityEvent OnAutoShowLimitReached;
    
    #endregion

    #region PRIVATE PROPERTIES

    private string SaveKey => $"AutoEnable_{name}";

    private int ShowCount
    {
        get => PlayerPrefs.GetInt(SaveKey, 0);
        set => PlayerPrefs.SetInt(SaveKey, value);
    }

    private int initialShowCount;
    
    #endregion

    #region PUBLIC PROPERTIES

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        initialShowCount = ShowCount;
    }

    #endregion

    #region PRIVATE METHODS

    #endregion

    #region PUBLIC METHODS

    public void TryToEnable()
    {
        if (ShowCount >= autoShowLimit)
        {
            OnAutoShowLimitReached?.Invoke();
            return;
        }
        ShowCount += 1;
        Enable();
    }

    public void Enable()
    {
        OnEnabled?.Invoke();
    }

    public void Disable(bool takeBackCount)
    {
        if (takeBackCount) 
            ShowCount = ShowCount - 1 < initialShowCount 
                ? initialShowCount 
                : ShowCount - 1;

        OnDisabled?.Invoke();
    }
    
    #endregion
}