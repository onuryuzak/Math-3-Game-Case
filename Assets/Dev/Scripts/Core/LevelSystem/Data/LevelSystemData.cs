using System.Collections.Generic;
using Base.Core.LevelSystem.Loader;
using UnityEngine;

namespace Base.Core.LevelSystem.Data
{
    [CreateAssetMenu(menuName = "Level System/LevelSystemData", fileName = "LevelSystemData")]
    public class LevelSystemData : ScriptableObject
    {
        #region INSPECTOR FIELDS

        [Tooltip("Reloads the main scene when loading new level.")] [SerializeField]
        private bool reloadMainSceneOnLoading = true;

        [Tooltip(
            "Decides whether main scene or level scene is used for active scene(important for lightings and etc.).")]
        [SerializeField]
        protected bool overrideMainSceneLighting = true;

        [SerializeField] private BaseSceneLoader sceneLoader;
        [SerializeField] private SceneFieldAsset mainScene;
        [SerializeField] private List<LevelData> levels;
        [SerializeField] private List<LevelData> exceptedLevelsOnRecycle;

        #endregion

        #region PUBLIC PROPERTIES

        public bool ReloadMainSceneOnLoading => reloadMainSceneOnLoading;
        public bool OverrideMainSceneLighting => overrideMainSceneLighting;
        public BaseSceneLoader SceneLoader => sceneLoader;
        public SceneFieldAsset MainScene => mainScene;
        public int TotalLevelCount => levels.Count;
        public List<LevelData> Levels => levels;
        public List<LevelData> ExceptedLevelsOnRecycle => exceptedLevelsOnRecycle;

        #endregion

        #region PUBLIC METHODS

        public void SetLevels(List<LevelData> levels) => this.levels = levels;
        public void SetExceptedLevelsOnRecycle(List<LevelData> levels) => exceptedLevelsOnRecycle = levels;

        #endregion
    }
}
