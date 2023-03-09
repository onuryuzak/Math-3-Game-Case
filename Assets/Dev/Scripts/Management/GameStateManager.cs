
using Base.Core.GameStates;
using Base.Core.LevelSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Base.Management
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        #region INSPECTOR FIELDS

        [SerializeField] private GameStateEvents gameStateEvents;
        [SerializeField] private LevelSystem levelSystem;
        [SerializeField] private bool autoStartGame = true;

        #endregion

        #region PRIVATE FIELDS

        private bool _started;
        private bool _finished;
        private bool _won;

        #endregion

        #region PUBLIC PROPERTIES

        public bool Finished => _finished;
        public bool Started => _started;
        public bool Won => _won;

        #endregion

        #region PUBLIC METHODS

        [Button]
        public void Play() => gameStateEvents.TriggerPlayEvent();

        [Button]
        public void Win()
        {
            if (_finished)
                return;

            gameStateEvents.TriggerWinEvent();
        }

        [Button]
        public void GameOver()
        {
            if (_finished)
                return;

            gameStateEvents.TriggerGameOverEvent();
        }

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            gameStateEvents.OnPlay.AddListener(OnPlay);
            gameStateEvents.OnPause.AddListener(OnPause);
            gameStateEvents.OnWin.AddListener(OnWin);
            gameStateEvents.OnGameOver.AddListener(OnGameOver);
        }

        private void OnDisable()
        {
            gameStateEvents.OnPlay.RemoveListener(OnPlay);
            gameStateEvents.OnPause.RemoveListener(OnPause);
            gameStateEvents.OnWin.RemoveListener(OnWin);
            gameStateEvents.OnGameOver.RemoveListener(OnGameOver);
        }

        private void Start()
        {
            if (autoStartGame)
                Play();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (Finished && Won)
                levelSystem.SaveNextLevel();
        }

        private void OnApplicationQuit()
        {
            if (Finished && Won)
                levelSystem.SaveNextLevel();
        }

        #endregion

        #region GAMESTATE CALLBACKS

        private void OnBeginning()
        {
        }

        private void OnPlay()
        {
            _started = true;
        }

        private void OnPause()
        {
        }

        private void OnWin()
        {
            _finished = true;
            _won = true;
        }

        private void OnGameOver()
        {
            _finished = true;
        }

        #endregion
    }
    
}

