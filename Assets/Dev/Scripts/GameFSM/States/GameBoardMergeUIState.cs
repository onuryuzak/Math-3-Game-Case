using System;
using Base.Events;
using UnityEngine;

public class GameBoardMergeUIState : GameBoardState
{
    private MinionType mergedMinionType;

    public GameBoardMergeUIState(GameBoard board, MinionType minionType) : base(board)
    {
        mergedMinionType = minionType;
    }

    public override void EnterState()
    {
        GameEvents.UIEvents.OnMinionMerge?.Invoke(mergedMinionType);
        SetState(new GameBoardIdleState(board));
    }

    public override void ExitState()
    {
    }

    public override void Update()
    {
    }
}