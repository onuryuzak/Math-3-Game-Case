using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Base.Core.GameStates;
using Base.Events;
using UnityEngine;

public class MergeCountMenu : MonoBehaviour
{
    #region INSPECTOR FIELDS

    [SerializeField] private List<CountPanel> countPanels;
    [SerializeField] private GameStateEvents gameStateEvents;

    #endregion

    #region UNITY METHODS

    private void OnEnable()
    {
        GameEvents.UIEvents.OnMinionMerge += OnMinionMerge;
        GameEvents.GameplayEvents.OnCheckPanelsCondition += OnCheckPanelsCondition;
    }


    private void OnDisable()
    {
        GameEvents.UIEvents.OnMinionMerge -= OnMinionMerge;
        GameEvents.GameplayEvents.OnCheckPanelsCondition -= OnCheckPanelsCondition;
    }

    #endregion

    #region PRIVATE METHODS

    private void OnMinionMerge(MinionType minionType)
    {
        var foundedCountPanel = countPanels.Find(x => x.MinionType == minionType);
        GameEvents.GameplayEvents.OnFoundCountPanelForMerge?.Invoke(foundedCountPanel);
    }

    private void OnCheckPanelsCondition()
    {
        var donePanelCounts = countPanels.Count(x => x.isDone);
        if (donePanelCounts < countPanels.Count) return;
        gameStateEvents.OnWin?.Invoke();
    }

    #endregion
}