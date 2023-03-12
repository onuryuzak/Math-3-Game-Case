using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private GameBoardState _currentState;

    public void SetState(GameBoardState newState) {
        if (_currentState != null) {
            _currentState.ExitState();
        }

        _currentState = newState;

        if (_currentState != null) {
            _currentState.EnterState();
        }
    }

    public void Update() {
        if (_currentState != null) {
            _currentState.Update();
        }
    }
}
