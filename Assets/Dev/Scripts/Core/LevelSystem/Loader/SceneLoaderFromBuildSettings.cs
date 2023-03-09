using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Base.Core.LevelSystem.Loader
{
    [CreateAssetMenu(menuName = "Level System/SceneLoader/SceneLoaderFromBuildSettings",
        fileName = "SceneLoaderFromBuildSettings")]
    public class SceneLoaderFromBuildSettings : BaseSceneLoader
    {
        public override void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive,
            Action onComplete = null)
        {
            CoreSceneManager.LoadSceneAsync(sceneName, mode, onComplete);
        }

        public override void UnloadSceneAsync(string sceneName, Action onComplete = null)
        {
            CoreSceneManager.UnloadSceneAsync(sceneName, onComplete);
        }

        public override Scene GetScene(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            return scene;
        }

        public override void ClearRuntimeData()
        {
        }
    }
}