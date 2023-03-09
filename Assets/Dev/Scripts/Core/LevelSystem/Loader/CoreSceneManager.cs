using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Base.Core.LevelSystem.Loader
{
    public static class CoreSceneManager
{
    #region PUBLIC PROPERTIES

    public static event Action<bool> sceneLoadingEvent;
    public static event Action OnLoadingStarted;
    public static event Action OnLoadingEnded;
    public static event Action OnUnloadingStarted;
    public static event Action OnUnloadingEnded;
    public static float LoadingProgress => CalculateLoadingProgress();
    public static bool IsLoading => _asyncOperations.Count > 0;

    #endregion

    #region PRIVATE PROPERTIES

    private static List<AsyncOperation> _asyncOperations = new List<AsyncOperation>();

    #endregion

    #region PUBLIC METHODS

    public static void LoadSceneAsync(int sceneIndex, LoadSceneMode mode = LoadSceneMode.Single,
        Action onLoaded = null)
    {
        sceneLoadingEvent?.Invoke(true);
        OnLoadingStarted?.Invoke();

        var async = SceneManager.LoadSceneAsync(sceneIndex, mode);
        _asyncOperations.Add(async);
        HandleSceneLoadedDelegation(sceneIndex, onLoaded, async);
    }

    public static void LoadSceneAsync(string name, LoadSceneMode mode = LoadSceneMode.Single,
        Action onLoaded = null)
    {
        sceneLoadingEvent?.Invoke(true);
        OnLoadingStarted?.Invoke();

        var async = SceneManager.LoadSceneAsync(name, mode);
        _asyncOperations.Add(async);
        HandleSceneLoadedDelegation(name, onLoaded, async);
    }

    public static void UnloadSceneAsync(int index, Action onUnloaded = null)
    {
        sceneLoadingEvent?.Invoke(true);
        OnUnloadingStarted?.Invoke();

        var async = SceneManager.UnloadSceneAsync(index);
        _asyncOperations.Add(async);

        HandleSceneUnloadedDelegation(index, onUnloaded, async);
    }

    public static void UnloadSceneAsync(string name, Action onUnloaded = null)
    {
        sceneLoadingEvent?.Invoke(true);
        OnUnloadingStarted?.Invoke();

        var async = SceneManager.UnloadSceneAsync(name);
        _asyncOperations.Add(async);

        HandleSceneUnloadedDelegation(name, onUnloaded, async);
    }

    public static bool IsSceneLoaded(string name) => SceneManager.GetSceneByName(name).IsValid();
    public static bool IsSceneExist(int index) => SceneManager.GetSceneByBuildIndex(index).IsValid();

    #endregion

    #region PRIVATE METHODS

    private static void HandleSceneLoadedDelegation(int index, Action onLoaded, AsyncOperation async)
    {
        if (onLoaded == null)
            return;

        void SceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.buildIndex != index)
                return;

            SceneManager.sceneLoaded -= SceneLoaded;
            onLoaded.Invoke();

            sceneLoadingEvent?.Invoke(false);
            OnLoadingEnded?.Invoke();
            _asyncOperations.Remove(async);
        }

        SceneManager.sceneLoaded += SceneLoaded;
    }

    private static void HandleSceneLoadedDelegation(string sceneName, Action onLoaded, AsyncOperation async)
    {
        var scene = SceneManager.GetSceneByName(sceneName);
        HandleSceneLoadedDelegation(scene.buildIndex, onLoaded, async);
    }

    private static void HandleSceneUnloadedDelegation(string name, Action onUnLoaded, AsyncOperation async)
    {
        if (onUnLoaded == null)
            return;

        void SceneUnLoaded(Scene scene)
        {
            if (scene.name != name)
                return;

            SceneManager.sceneUnloaded -= SceneUnLoaded;
            onUnLoaded.Invoke();
            OnUnloadingEnded?.Invoke();
            _asyncOperations.Remove(async);
        }

        SceneManager.sceneUnloaded += SceneUnLoaded;
    }

    private static void HandleSceneUnloadedDelegation(int index, Action onUnLoaded, AsyncOperation async)
    {
        var scene = SceneManager.GetSceneByBuildIndex(index);
        HandleSceneUnloadedDelegation(scene.name, onUnLoaded, async);
    }

    private static float CalculateLoadingProgress()
    {
        var progress = 0f;
        if (_asyncOperations.Count > 0)
            progress = _asyncOperations.Average(operation => operation.progress);

        return progress;
    }

    #endregion
}
}
