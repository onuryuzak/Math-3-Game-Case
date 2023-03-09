using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameData/Type/ToggleOptionType", fileName = "ToggleOptionType")]
public class ToggleOptionType : ScriptableObject
{
    [Header("Settings")]
    public string optionName;

    [Header("Events")]
    public UnityEvent OnToggled;

    public void TriggerToggledEvent()
    {
        OnToggled?.Invoke();
    }
}