using UnityEngine;

public class GameBoardDragItemState : GameBoardState
{
    // private readonly GameItem draggedItem;
    // private readonly Vector3 initialPosition;
    //
    // public GameBoardDragItemState(GameBoard board,GameItem draggedItem) : base(board)
    // {
    //     this.draggedItem = draggedItem;
    //     initialPosition = draggedItem.transform.position;
    // }
    //
    // public override void EnterState()
    // {
    //     draggedItem.enabled = false;
    // }
    //
    // public override void ExitState()
    // {
    //     draggedItem.enabled = true;
    // }
    //
    // public override void Update()
    // {
    //     var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     draggedItem.transform.position =
    //         new Vector3(mousePosition.x, mousePosition.y, draggedItem.transform.position.z);
    //
    //     if (!Input.GetMouseButtonUp(0)) return;
    //     var dropPosition = board.GetDropPosition();
    //     if (dropPosition != null)
    //     {
    //         draggedItem.MoveToCell(dropPosition);
    //         var mergeItems = board.FindMergeItems(dropPosition);
    //         if (mergeItems.Count >= 2)
    //         {
    //             board.MergeItems(mergeItems);
    //         }
    //     }
    //     else
    //     {
    //         draggedItem.transform.position = initialPosition;
    //     }
    //
    //     SetState(new GameBoardIdleState(board));
    // }
    public GameBoardDragItemState(GameBoard board) : base(board)
    {
    }

    public override void EnterState()
    {
        
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}