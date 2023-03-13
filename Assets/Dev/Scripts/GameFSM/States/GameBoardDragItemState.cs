using UnityEngine;

public class GameBoardDragItemState : GameBoardState
{
    private readonly Minion draggedItem;

    public GameBoardDragItemState(GameBoard board, Minion draggedItem) : base(board)
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
            draggedItem.SnapToCell(dropCell.transform.position);
            draggedItem.minionSprite.sortingOrder = 2;
            draggedItem.SetCurrentCell(dropCell);
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