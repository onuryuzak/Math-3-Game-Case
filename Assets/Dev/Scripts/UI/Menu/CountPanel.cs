using System;
using System.Collections;
using System.Collections.Generic;
using Base.Events;
using TMPro;
using UnityEngine;

public class CountPanel : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private int maxMergeValue;

    #endregion

    #region PUBLIC FIELDS

    public MinionType MinionType;
    public bool isDone;

    #endregion

    #region PRIVATE FIELDS

    private int mergedValue = 0;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        SetText();
    }

    #endregion

    #region PUBLIC METHODS

    public void SetValue()
    {
        mergedValue++;
        if (mergedValue >= maxMergeValue)
        {
            isDone = true;
            GameEvents.GameplayEvents.OnCheckPanelsCondition?.Invoke();
        }

        if (mergedValue > maxMergeValue) return;
        SetText();
    }

    #endregion

    #region PRIVATE METHODS

    private void SetText()
    {
        countText.text = mergedValue + "/" + maxMergeValue;
    }

    #endregion
}