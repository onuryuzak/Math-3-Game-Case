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
            draggedItem.SetCurrentIndex(dropCell.transform.position);
            board.mergeCount = 0;
            board.matchedMinion.Clear();
            board.DetectAndMergeMinions(draggedItem);
        }

        SetState(new GameBoardIdleState(board));
    }
}