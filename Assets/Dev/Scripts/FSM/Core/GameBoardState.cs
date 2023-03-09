public abstract class GameBoardState {
    protected GameBoard board;

    public GameBoardState(GameBoard board) {
        this.board = board;
    }

    public abstract void EnterState();

    public abstract void ExitState();

    public abstract void Update();

    protected void SetState(GameBoardState state) {
        board.SetState(state);
    }
}