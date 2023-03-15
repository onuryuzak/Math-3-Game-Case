using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Base.Events;
using UnityEngine;

public class MergeCountMenu : MonoBehaviour
{
    [SerializeField] private List<CountPanel> countPanels;

    private void OnEnable()
    {
        GameEvents.UIEvents.OnMinionMerge += OnMinionMerge;
    }


    private void OnDisable()
    {
        GameEvents.UIEvents.OnMinionMerge -= OnMinionMerge;
    }

    private void OnMinionMerge(MinionType minionType)
    {
        var foundedCountPanel = countPanels.Find(x => x.MinionType == minionType);
        foundedCountPanel.SetValue();
        var donePanelCounts = countPanels.Count(x => x.isDone == true);
        if (donePanelCounts <= countPanels.Count) return;
        GameEvents.GameplayEvents.OnGameEnd?.Invoke();
    }
}