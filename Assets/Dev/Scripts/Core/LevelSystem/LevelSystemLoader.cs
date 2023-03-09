using Base.Core.LevelSystem.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Base.Core.LevelSystem
{
    public class LevelSystemLoader : Singleton<LevelSystemLoader>
{
    #region INSPECTOR FIELDS

    [SerializeField] protected LevelSystem _levelSystem;

    #endregion

    #region PUBLIC EVENTS

    public UnityEvent BeforeLoadingStartedEvent;
    public UnityEvent LevelLoadingStartedEvent;
    public LevelSystem.LevelDataUnityEvent LevelLoadedEvent;
    public LevelSystem.LevelDataUnityEvent LevelUnLoadedEvent;

    #endregion

    #region LIFECYCLE METHODS

    protected override void Awake()
    {
        dontDestroyOnLoad = true;
        base.Awake();
    }

    private void Start() => HandleLevelSystemLoading();

    protected override void OnInstanceCreated()
    {
        base.OnInstanceCreated();
        SubscribeEvents();
        _levelSystem.ClearRuntimeData();
        OnBeforeLoadingStarted();
    }

    protected override void OnInstanceDestroyed()
    {
        base.OnInstanceDestroyed();
        UnSubscribeEvents();
        _levelSystem.ClearRuntimeData();
    }

    #endregion

    #region PROTECTED VIRTUAL METHODS

    protected virtual void OnBeforeLoadingStarted() => BeforeLoadingStartedEvent?.Invoke();

    protected virtual void OnLevelLoadingStarted() => LevelLoadingStartedEvent?.Invoke();

    protected virtual void OnLevelLoaded(LevelData level) => LevelLoadedEvent?.Invoke(level);

    protected virtual void OnLevelUnLoaded(LevelData level) => LevelUnLoadedEvent?.Invoke(level);

    #endregion

    #region PRIVATE METHODS

    private void HandleLevelSystemLoading()
    {
        _levelSystem.LoadLastSavedLevel();
    }

    private void SubscribeEvents()
    {
        _levelSystem.onLevelLoadingStarted.AddListener(OnLevelLoadingStarted);
        _levelSystem.onLevelLoaded.AddListener(OnLevelLoaded);
        _levelSystem.onLevelUnloaded.AddListener(OnLevelUnLoaded);
    }

    private void UnSubscribeEvents()
    {
        _levelSystem.onLevelLoadingStarted.RemoveListener(OnLevelLoadingStarted);
        _levelSystem.onLevelLoaded.RemoveListener(OnLevelLoaded);
        _levelSystem.onLevelUnloaded.RemoveListener(OnLevelUnLoaded);
    }

    #endregion
}
}
