using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private int maxMergeValue;
    public MinionType MinionType;
    public bool isDone;

    private int mergedValue = 0;

    private void Start()
    {
        SetText();
    }

    public void SetValue()
    {
        if (mergedValue >= maxMergeValue) return;
        mergedValue++;
        SetText();
    }

    private void SetText()
    {
        countText.text = mergedValue + "/" + maxMergeValue;
    }
}