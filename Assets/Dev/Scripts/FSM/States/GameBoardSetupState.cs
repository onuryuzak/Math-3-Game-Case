using UnityEngine;

public class GameBoardSetupState : GameBoardState
{
    public GameBoardSetupState(GameBoard board) : base(board)
    {
    }

    public override void EnterState()
    {
        board.transform.position = Vector3.zero;
        board.transform.rotation = Quaternion.identity;

        for (int x = 0; x < board.GridSize; x++)
        {
            for (int y = 0; y < board.GridSize; y++)
            {
                
                board.SpawnCell(x,y);
            }
        }

        board.SpawnMinion(7);

        SetState(new GameBoardIdleState(board));
    }

    public override void ExitState()
    {
    }

    public override void Update()
    {
    }
}