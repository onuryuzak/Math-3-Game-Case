using UnityEngine;
using UnityEngine.Events;

public class ToggleOptionTypeListener : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ToggleOptionType toggleOptionType;

    [Header("Events")]
    [SerializeField] private UnityEvent OnToggled;

    private void OnEnable()
    {
        toggleOptionType.OnToggled.AddListener(OnToggledCallback);
    }

    private void OnDisable()
    {
        toggleOptionType.OnToggled.RemoveListener(OnToggledCallback);
    }

    private void OnToggledCallback()
    {
        OnToggled?.Invoke();
    }
}