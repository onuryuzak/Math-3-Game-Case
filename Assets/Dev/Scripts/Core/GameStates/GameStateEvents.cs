using UnityEngine;
using UnityEngine.Events;


namespace Base.Core.GameStates
{
    [CreateAssetMenu(menuName = "GameStateEvents", fileName = "GameStateEvents")]
    public class GameStateEvents : ScriptableObject
    {
        #region PUBLIC EVENTS

        public UnityEvent OnPlay;
        public UnityEvent OnPause;
        public UnityEvent OnWin;
        public UnityEvent OnGameOver;

        #endregion

        #region PUBLIC METHODS

        public void TriggerPlayEvent() => OnPlay?.Invoke();
        public void TriggerPauseEvent() => OnPause?.Invoke();
        public void TriggerWinEvent() => OnWin?.Invoke();
        public void TriggerGameOverEvent() => OnGameOver?.Invoke();

        #endregion
    }
}