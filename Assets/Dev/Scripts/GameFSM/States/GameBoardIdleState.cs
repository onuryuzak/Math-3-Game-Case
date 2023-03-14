using UnityEngine;

public class GameBoardIdleState : GameBoardState
{
    private Minion draggedItem;
    private RaycastHit2D hit;


    public GameBoardIdleState(GameBoard board) : base(board)
    {
    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public override void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var item = FindItemAtMousePosition();
        if (item == null) return;
        draggedItem = item;
        draggedItem.minionSprite.sortingOrder = 3;
        draggedItem.currentCell.isFull = false;
        draggedItem.SetCurrentCell(null);
        draggedItem.SetCurrentIndex(Vector2.zero);

        SetState(new GameBoardDragItemState(board, draggedItem));
    }

    private Minion FindItemAtMousePosition()
    {
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(ray, Vector2.zero);
        return hit ? hit.collider.gameObject.GetComponent<Minion>() : null;
    }
}