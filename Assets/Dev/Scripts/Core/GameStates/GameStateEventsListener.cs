using UnityEngine;
using UnityEngine.Events;


namespace Base.Core.GameStates
{
    public class GameStateEventsListener : MonoBehaviour
    {
        [SerializeField] private GameStateEvents gameStateEvents;

        public UnityEvent OnGameStartedEvent;
        public UnityEvent OnGamePausedEvent;
        public UnityEvent OnGameFinishedEvent;
        public UnityEvent OnGameWinEvent;
        public UnityEvent OnGameOverEvent;

        protected virtual void OnEnable()
        {
            gameStateEvents.OnPlay.AddListener(OnGameStarted);
            gameStateEvents.OnPause.AddListener(OnGamePaused);
            gameStateEvents.OnWin.AddListener(OnGameWin);
            gameStateEvents.OnGameOver.AddListener(OnGameOver);
        }

        protected virtual void OnDisable()
        {
            gameStateEvents.OnPlay.RemoveListener(OnGameStarted);
            gameStateEvents.OnPause.RemoveListener(OnGamePaused);
            gameStateEvents.OnWin.RemoveListener(OnGameWin);
            gameStateEvents.OnGameOver.RemoveListener(OnGameOver);
        }

        protected virtual void OnGameStarted()
        {
            OnGameStartedEvent?.Invoke();
        }

        protected virtual void OnGamePaused()
        {
            OnGamePausedEvent?.Invoke();
        }

        protected virtual void OnGameWin()
        {
            OnGameWinEvent?.Invoke();
            OnGameFinished();
        }

        protected virtual void OnGameOver()
        {
            OnGameOverEvent?.Invoke();
            OnGameFinished();
        }

        protected virtual void OnGameFinished()
        {
            OnGameFinishedEvent?.Invoke();
        }
    }
}