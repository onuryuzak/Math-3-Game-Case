using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnOffSwitch : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image bgImage;
    [SerializeField] private GameObject onSwitch;
    [SerializeField] private GameObject offSwitch;
    [SerializeField] private Sprite onBg;
    [SerializeField] private Sprite offBg;

    [Header("Settings")]
    [SerializeField] private bool defaultValue = true;
    
    [Header("Events")]
    [SerializeField] private UnityEvent OnSwitchedOn;
    [SerializeField] private UnityEvent OnSwitchedOff;

    private string SaveKey => $"OnOffSwitch_{name}";

    private bool IsOn
    {
        get => PlayerPrefs.GetInt(SaveKey, defaultValue ? 1 : 0) == 1;
        set => PlayerPrefs.SetInt(SaveKey, value ? 1 : 0);
    }

    private void Awake() => ApplyCurrentState();

    private void ApplyCurrentState()
    {
        var isOn = IsOn;
        if (isOn) OnSwitchedOn?.Invoke();
        else OnSwitchedOff?.Invoke();

        offSwitch.SetActive(!isOn);
        onSwitch.SetActive(isOn);

        bgImage.sprite = isOn ? onBg : offBg;
    }

    public void Toggle()
    {
        IsOn = !IsOn;
        ApplyCurrentState();
    }
}