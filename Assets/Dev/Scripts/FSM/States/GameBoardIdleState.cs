
using UnityEngine;

public class GameBoardIdleState : GameBoardState 
{
    // private GameItem draggedItem;


    public GameBoardIdleState(GameBoard board) : base(board)
    {
    }

    public override void EnterState() {
        // foreach (var item in board.Items) {
        //     item.enabled = true;
        // }
    }

    public override void ExitState() {
        // foreach (var item in board.Items) {
        //     item.enabled = false;
        // }
    }

    public override void Update() {
        // if (Input.GetMouseButtonDown(0)) {
        //     var item = FindItemAtMousePosition();
        //     if (item != null) {
        //         draggedItem = item;
        //         SetState(new GameBoardDragItemState(board, draggedItem));
        //     }
        // }
    }

    // private GameItem FindItemAtMousePosition() {
    //     var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     return Physics.Raycast(ray, out var hit) ? hit.collider.gameObject.GetComponent<GameItem>() : null;
    // }
}