using System;
using System.Collections.Generic;
using System.Linq;
using Base.Core.LevelSystem.Data;
using Base.Core.LevelSystem.Loader;
using Base.Core.LevelSystem.Save;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Base.Core.LevelSystem
{
    [CreateAssetMenu(menuName = "Level System/New Level System", fileName = "LevelSystem")]
    public class LevelSystem : ScriptableObject
    {
        #region INSPECTOR PROPERTIES

        [SerializeField] private LevelSystemData data;

        #endregion

        #region PRIVATE FIELDS

        private bool isLoading;

        #endregion

        #region PUBLIC PROPERTIES

        public int CurrentLevelIndex
        {
            get => LevelSaveManager.GetLevelIndex();
            set => LevelSaveManager.SaveLevelIndex(value);
        }

        public int CurrentLevelNumber
        {
            get => LevelSaveManager.GetLevelNumber();
            set => LevelSaveManager.SaveLevelNumber(value);
        }

        public int HighestLevelNumber => LevelSaveManager.GetHighestLevelNumber();

        public List<LevelData> AvailableLevels =>
            !IsRecyclingLevels
                ? data.Levels
                : data.Levels.Except(data.ExceptedLevelsOnRecycle).ToList();

        public int AvailableLevelCount => AvailableLevels.Count;
        public LevelData CurrentLevelData { get; private set; }
        public LevelData PreviousLevelData { get; private set; }
        public bool IsRecyclingLevels => CurrentLevelNumber > data.TotalLevelCount;
        public bool IsLoading => isLoading;

        public LevelSystemData Data => data;

        #endregion

        #region PUBLIC EVENTS

        [Serializable]
        public class LevelDataUnityEvent : UnityEvent<LevelData>
        {
        }

        public UnityEvent onLevelLoadingStarted;
        public UnityEvent onLevelLoadingEnded;
        public LevelDataUnityEvent onLevelLoaded;
        public LevelDataUnityEvent onLevelUnloaded;

        #endregion

        #region PROTECTED METHODS

        protected virtual void OnLevelLoaded(LevelData levelData)
        {
        }

        protected virtual void OnLevelUnloaded(LevelData levelData)
        {
        }

        #endregion

        #region PRIVATE METHODS

        private void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive,
            Action onComplete = null)
        {
            data.SceneLoader.LoadSceneAsync(sceneName, mode, onComplete);
        }

        private void UnloadSceneAsync(string sceneName, Action onComplete = null)
        {
            data.SceneLoader.UnloadSceneAsync(sceneName, onComplete);
        }

        private Scene GetScene(string sceneName)
        {
            return data.SceneLoader.GetScene(sceneName);
        }

        /// <summary>
        /// Loads a random level.
        /// </summary>
        private void LoadRandomLevel()
        {
            var randomLevelIndex = Random.Range(0, AvailableLevelCount);
            if (AvailableLevels[randomLevelIndex] == CurrentLevelData)
                randomLevelIndex += Random.Range(0, 1) == 0 && randomLevelIndex > 0 ? -1 : 1;

            LoadLevelInternal(randomLevelIndex % AvailableLevelCount);
        }

        /// <summary>
        /// Loads the desired level.
        /// </summary>
        /// <param name="index">Level index</param>
        private void LoadLevelInternal(int index)
        {
            if (isLoading)
                return;

            if (index < 0)
            {
                Debug.LogError("Level index must be valid!");
                return;
            }

            if (AvailableLevelCount == 0)
            {
                Debug.LogError("At least one level is needed to load!");
                return;
            }

            PreviousLevelData = CurrentLevelData;
            CurrentLevelIndex = index % AvailableLevelCount;
            CurrentLevelData = AvailableLevels[CurrentLevelIndex];

            OnLevelLoadingStarted();
            HandleLevelLoading(OnLevelLoadingEnded);
        }

        private void HandleLevelLoading(Action onCompleted = null)
        {
            SaveCurrentLevel();
            UnloadPreviousLevelAsync(() => { LoadMainSceneAsync(() => { LoadCurrentLevelAsync(onCompleted); }); });
        }

        private void UnloadPreviousLevelAsync(Action onComplete = null)
        {
            if (!PreviousLevelData)
            {
                onComplete?.Invoke();
                return;
            }

            PreviousLevelData.Unloaded();
            if (PreviousLevelData.HasScene)
            {
                if (IsSceneLoaded(PreviousLevelData.LevelScene))
                {
                    UnloadSceneAsync(PreviousLevelData.LevelScene, () =>
                    {
                        onComplete?.Invoke();
                        PerformLevelUnloaded();
                    });
                }
            }
            else
            {
                PerformLevelUnloaded();
                onComplete?.Invoke();
            }
        }

        private void LoadCurrentLevelAsync(Action onComplete = null)
        {
            CurrentLevelData.Loaded();
            if (CurrentLevelData.HasScene)
            {
                if (IsSceneLoaded(CurrentLevelData.LevelScene))
                {
                    UnloadSceneAsync(CurrentLevelData.LevelScene);
                }

                LoadSceneAsync(CurrentLevelData.LevelScene, LoadSceneMode.Additive, () =>
                {
                    PerformLevelLoaded();
                    SetActiveScene(data.OverrideMainSceneLighting
                        ? CurrentLevelData.LevelScene
                        : data.MainScene);
                    onComplete?.Invoke();
                });
            }
            else
            {
                PerformLevelLoaded();
                onComplete?.Invoke();
            }
        }

        private void SetActiveScene(string sceneName)
        {
            var scene = GetScene(sceneName);
            SceneManager.SetActiveScene(scene);
        }

        private void OnLevelLoadingStarted()
        {
            isLoading = true;
            onLevelLoadingStarted?.Invoke();
        }

        private void OnLevelLoadingEnded()
        {
            isLoading = false;
            onLevelLoadingEnded?.Invoke();
        }

        private void SaveCurrentLevel() => LevelSaveManager.SaveLevel(CurrentLevelNumber, CurrentLevelIndex);

        private void PerformLevelLoaded()
        {
            OnLevelLoaded(CurrentLevelData);
            onLevelLoaded?.Invoke(CurrentLevelData);
        }

        private void PerformLevelUnloaded()
        {
            OnLevelUnloaded(PreviousLevelData);
            onLevelUnloaded?.Invoke(PreviousLevelData);
        }

        private void LoadMainSceneAsync(LoadSceneMode mode = LoadSceneMode.Additive,
            Action onComplete = null)
        {
            LoadSceneAsync(data.MainScene, mode, onComplete);
        }

        private void UnloadMainSceneAsync(Action onComplete = null)
        {
            UnloadSceneAsync(data.MainScene, onComplete);
        }

        private void LoadMainSceneAsync(Action onCompleted)
        {
            if (!IsMainSceneLoaded() || data.ReloadMainSceneOnLoading)
                LoadMainSceneAsync(LoadSceneMode.Single, onCompleted);
            else
                onCompleted?.Invoke();
        }

        #endregion

        #region PUBLIC METHODS

        public virtual void LoadLevel(int levelNumber, bool randomizeOnRecycle = false)
        {
            CurrentLevelNumber = Mathf.Clamp(levelNumber, 1, HighestLevelNumber);
            var loadIndex = CurrentLevelNumber - 1;
            if (IsRecyclingLevels)
            {
                loadIndex -= data.TotalLevelCount;
                if (randomizeOnRecycle)
                {
                    LoadRandomLevel();
                    return;
                }
            }

            LoadLevelInternal(loadIndex);
        }

        /// <summary>
        /// Loads the next level.
        /// </summary>
        /// <param name="randomizeOnRecycle">Decide whether load random levels when all are finished using existing levels.</param>
        public virtual void LoadNextLevel(bool randomizeOnRecycle = false)
        {
            CurrentLevelNumber++;
            LoadLevel(CurrentLevelNumber, randomizeOnRecycle);
        }

        public virtual void LoadPreviousLevel(bool randomizeOnRecycle = false)
        {
            CurrentLevelNumber--;
            LoadLevel(CurrentLevelNumber, randomizeOnRecycle);
        }

        public virtual void LoadLastSavedLevel()
        {
            CurrentLevelNumber = HighestLevelNumber;
            LoadLevelInternal(CurrentLevelIndex);
        }

        public virtual void LoadHighestLevel() => LoadLevelInternal(HighestLevelNumber);

        public virtual void RestartLevel() => LoadLevelInternal(CurrentLevelIndex);

        public virtual void SaveNextLevel() =>
            LevelSaveManager.SaveLevel(HighestLevelNumber + 1, CurrentLevelIndex + 1);

        public virtual void SaveLevel(int levelNumber, int levelIndex) =>
            LevelSaveManager.SaveLevel(levelNumber, levelIndex);

        public bool IsMainSceneLoaded() => IsSceneLoaded(data.MainScene);
        public bool IsSceneLoaded(string sceneName) => CoreSceneManager.IsSceneLoaded(sceneName);

        public virtual void ClearRuntimeData()
        {
            CurrentLevelData = null;
            PreviousLevelData = null;
            isLoading = false;
        }

        public void UpdateLevelSystemData(LevelSystemData data) => this.data = data;

        #endregion
    }
}