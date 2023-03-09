using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameData/Type/ToggleOptionTypeGroup", fileName = "ToggleOptionTypeGroup")]
public class ToggleOptionTypeGroup : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] private List<ToggleOptionType> optionTypes;

    [Header("Events")]
    public UnityEvent<ToggleOptionType> OnToggled;
    
    private string DataKeyPref => $"ToggleOption_{name}";

    public int CurrentIndex
    {
        get => PlayerPrefs.GetInt(DataKeyPref, 0);
        set => PlayerPrefs.SetInt(DataKeyPref, value);
    }

    public ToggleOptionType GetCurrentOptionType()
    {
        return optionTypes[CurrentIndex];
    }

    public void SwitchToNextOption()
    {
        CurrentIndex = (CurrentIndex + 1) % optionTypes.Count;
    }

    public void ToggleOptionType(ToggleOptionType optionType)
    {
        CurrentIndex = optionTypes.IndexOf(optionType);
        ToggleCurrentOptionType(false);
    }
    
    public void ToggleCurrentOptionType(bool switchToNext)
    {
        if (switchToNext) SwitchToNextOption();
        var optionType = optionTypes[CurrentIndex];
        optionType.TriggerToggledEvent();
        OnToggled?.Invoke(optionType);
    }
}