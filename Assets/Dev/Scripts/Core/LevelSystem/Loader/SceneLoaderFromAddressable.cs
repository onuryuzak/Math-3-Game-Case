using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Base.Core.LevelSystem.Loader
{
    [CreateAssetMenu(menuName = "Level System/SceneLoader/SceneLoaderFromAddressable",
        fileName = "SceneLoaderFromAddressable")]

    public class SceneLoaderFromAddressable : BaseSceneLoader
    {
        private List<SceneInstance> loadedScenes = new List<SceneInstance>();

        public override void LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive,
            Action onComplete = null)
        {
            Addressables.LoadSceneAsync(sceneName, mode).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                    loadedScenes.Add(handle.Result);

                onComplete?.Invoke();
            };
        }

        public override void UnloadSceneAsync(string sceneName, Action onComplete = null)
        {
            var sceneInstance = loadedScenes.Find(instance => instance.Scene.name == sceneName);
            Addressables.UnloadSceneAsync(sceneInstance).Completed += handle =>
            {
                loadedScenes.Remove(sceneInstance);
                onComplete?.Invoke();
            };
        }

        public override Scene GetScene(string sceneName)
        {
            var sceneInstance = loadedScenes.Find(instance => instance.Scene.name == sceneName);
            return sceneInstance.Scene;
        }

        public override void ClearRuntimeData()
        {
            loadedScenes.Clear();
            loadedScenes = new List<SceneInstance>();
        }
    }
}
