using Base.Core.LevelSystem.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Base.Core.LevelSystem
{
    public class LevelSystemEventsListener : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [SerializeField] private LevelSystem levelSystem;

        #endregion

        #region PUBLIC EVENTS

        public UnityEvent OnLevelLoadingStarted;
        public UnityEvent OnLevelLoadingEnded;
        public LevelSystem.LevelDataUnityEvent OnLevelLoaded;
        public LevelSystem.LevelDataUnityEvent OnLevelUnloaded;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            levelSystem.onLevelLoadingStarted.AddListener(LevelLoadingStarted);
            levelSystem.onLevelLoadingEnded.AddListener(LevelLoadingEnded);
            levelSystem.onLevelLoaded.AddListener(LevelLoaded);
            levelSystem.onLevelUnloaded.AddListener(LevelUnloaded);
        }

        private void OnDisable()
        {
            levelSystem.onLevelLoadingStarted.RemoveListener(LevelLoadingStarted);
            levelSystem.onLevelLoadingEnded.RemoveListener(LevelLoadingEnded);
            levelSystem.onLevelLoaded.RemoveListener(LevelLoaded);
            levelSystem.onLevelUnloaded.RemoveListener(LevelUnloaded);
        }

        #endregion

        #region PRIVATE METHODS

        private void LevelLoadingStarted() => OnLevelLoadingStarted?.Invoke();
        private void LevelLoadingEnded() => OnLevelLoadingEnded?.Invoke();
        private void LevelLoaded(LevelData levelData) => OnLevelLoaded?.Invoke(levelData);
        private void LevelUnloaded(LevelData levelData) => OnLevelUnloaded?.Invoke(levelData);

        #endregion
    }
}
