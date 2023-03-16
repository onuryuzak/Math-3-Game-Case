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
        UpdateDraggedItemPosition();
        CheckIfMouseButtonUp();
    }

    private void UpdateDraggedItemPosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggedItem.transform.position = mousePos;
    }

    private void CheckIfMouseButtonUp()
    {
        if (!board.playerInputData.Released) return;

        var dropCell = board.GetDropPosition(draggedItem.transform);
        if (dropCell != null && !dropCell.isFull)
        {
            HandleDrop(dropCell);
        }
    }

    private void HandleDrop(Cell dropCell)
    {
        draggedItem.SnapToCell(dropCell.transform.position);
        draggedItem.minionSprite.sortingOrder = 2;
        draggedItem.SetCurrentCell(dropCell);
        draggedItem.currentCell.isFull = true;
        draggedItem.SetCurrentIndex(dropCell.transform.position);

        board.mergeCount = 0;
        
        var (mergeCondition, minionType) = board.DetectAndMergeMinions(draggedItem);

        if (mergeCondition)
        {
            SetState(new GameBoardMergeUIState(board, minionType));
        }
        else
        {
            SetState(new GameBoardIdleState(board));
        }
    }
}