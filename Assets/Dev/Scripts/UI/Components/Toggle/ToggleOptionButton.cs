using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleOptionButton : MonoBehaviour
{
    #region INSPECTOR PROPERTIES

    [Header("References")]
    [SerializeField] private Image buttonImage;
    [SerializeField] private TextMeshProUGUI buttonText;

    [Header("Settings")]
    [SerializeField] private ToggleOptionTypeGroup optionTypeGroup;
    [SerializeField] private List<Sprite> buttonSprites;

    [Header("Events")]
    [SerializeField] private UnityEvent OnToggled;
    
    #endregion

    #region PRIVATE PROPERTIES

    #endregion

    #region PUBLIC PROPERTIES

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        optionTypeGroup.OnToggled.AddListener(UpdateButton);
        UpdateButton();
    }

    private void OnDisable()
    {
        optionTypeGroup.OnToggled.RemoveListener(UpdateButton);
    }

    #endregion

    #region PRIVATE METHODS

    private void UpdateButton(ToggleOptionType _ = null)
    {
        var option = optionTypeGroup.GetCurrentOptionType();
        
        buttonImage.sprite = buttonSprites[optionTypeGroup.CurrentIndex % buttonSprites.Count];
        buttonText.SetText(option.optionName);
    }

    #endregion

    #region PUBLIC METHODS

    public void ToggleNextOption()
    {
        optionTypeGroup.ToggleCurrentOptionType(true);
        UpdateButton();
        OnToggled?.Invoke();
    }

    #endregion
}