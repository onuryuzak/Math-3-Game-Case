using UnityEngine;

public class GameBoardDragItemState : GameBoardState
{
    private readonly MinionBase draggedItem;

    public GameBoardDragItemState(GameBoard board, MinionBase draggedItem) : base(board)
    {
        this.draggedItem = draggedItem;
    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public override void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggedItem.transform.position = mousePos;

        if (!Input.GetMouseButtonUp(0)) return;
        var dropCell = board.GetDropPosition(draggedItem.transform);
        if (dropCell != null && !dropCell.isFull)
        {
            draggedItem.MoveToCell(dropCell.transform.position);
            draggedItem.minionSprite.sortingOrder = 2;
            draggedItem.currentCell = dropCell;
            draggedItem.currentCell.isFull = true;
            // var mergeItems = board.FindMergeItems(dropPosition);
            // if (mergeItems.Count >= 2)
            // {
            //     board.MergeItems(mergeItems);
            // }
        }

        SetState(new GameBoardIdleState(board));
    }
}