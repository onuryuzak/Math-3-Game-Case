using UnityEngine;

public class GameBoardSetupState : GameBoardState
{
    public GameBoardSetupState(GameBoard board) : base(board)
    {
    }

    public override void EnterState()
    {
        board.InitializeCell();
        board.InitializeGridMinions();
        SetState(new GameBoardIdleState(board));
    }

    public override void ExitState()
    {
    }

    public override void Update()
    {
    }
}