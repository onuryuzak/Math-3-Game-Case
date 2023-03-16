using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Base.Events;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class GameBoardMergeUIState : GameBoardState
{
    private MinionType mergedMinionType;
    private CountPanel currentPanel;
    private List<Minion> mergedMinions = new List<Minion>();

    public GameBoardMergeUIState(GameBoard board, MinionType minionType) : base(board)
    {
        mergedMinionType = minionType;
    }

    public override void EnterState()
    {
        GameEvents.GameplayEvents.OnFoundCountPanelForMerge += OnFoundCountPanel;
        GameEvents.UIEvents.OnMinionMerge?.Invoke(mergedMinionType);
        SetState(new GameBoardIdleState(board));
    }

    public override void ExitState()
    {
        GameEvents.GameplayEvents.OnFoundCountPanelForMerge -= OnFoundCountPanel;
    }


    public override void Update()
    {
    }

    private void OnFoundCountPanel(CountPanel foundedCountPanel)
    {
        currentPanel = foundedCountPanel;
        foreach (var minion in board.matchedMinion)
        {
            minion.StartCoroutine(minion.MoveCorrectUIPanel(foundedCountPanel));
            mergedMinions.Add(minion);
        }

        board.matchedMinion.Clear();
        DOVirtual.DelayedCall(mergedMinions[0].moveAnimationTime + 0.8f, (() =>
        {
            var doneCount = mergedMinions.Count(x => x.isDoneMovementToUI);
            if (doneCount < 3) return;
            foundedCountPanel.SetValue();

            currentPanel = null;
        }));
    }
}