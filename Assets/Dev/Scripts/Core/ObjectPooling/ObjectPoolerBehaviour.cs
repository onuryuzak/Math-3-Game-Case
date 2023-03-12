using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Base.Core.Pooling
{
    [DefaultExecutionOrder(-10000000)]
    public class ObjectPoolerBehaviour : MonoBehaviour, IObjectPooler
    {
        #region INSPECTOR FIELDS

        [SerializeField] private bool hasScriptableDelegate;
        [SerializeField] [ShowIf("hasScriptableDelegate")] [InlineEditor]
        private ObjectPoolerScriptableDelegate scriptableDelegate;
        [SerializeField] [HideIf("hasScriptableDelegate")]
        private GameObjectPooler.PoolItem poolItem;
        [SerializeField] private Transform poolParent;
        [SerializeField] private bool autoInitialize = true;
        [SerializeField] private float defaultAutoDespawnTime = 2f;
        [SerializeField] private bool alwaysAutoDespawn;

        [ShowIf("autoInitialize")] [SerializeField]
        private InitType initType = InitType.Awake;

        public enum InitType
        {
            Awake,
            Start,
            OnEnable
        }

        #endregion

        #region PRIVATE FIELDS

        private GameObjectPooler pooler;

        private GameObjectPooler.PoolItem PoolItem =>
            hasScriptableDelegate
                ? scriptableDelegate.PoolItem
                : poolItem;

        #endregion

        #region PUBLIC FIELDS

        public GameObject Prefab => PoolItem.prefab;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (autoInitialize && initType == InitType.Awake)
                Initialize();
        }

        private void OnEnable()
        {
            if (autoInitialize && initType == InitType.OnEnable)
                Initialize();
        }

        private void Start()
        {
            if (autoInitialize && initType == InitType.Start)
                Initialize();
        }

        #endregion

        #region PRIVATE METHODS

        private void InitPooler() => pooler = new GameObjectPooler(PoolItem, poolParent);

        private void InitScriptableDelegate()
        {
            if (hasScriptableDelegate)
                scriptableDelegate.SetData(this);
        }

        private void DespawnDelayed(GameObject obj, float despawnDuration) =>
            StartCoroutine(DespawnDelayedCoroutine(obj, despawnDuration));

        private IEnumerator DespawnDelayedCoroutine(GameObject obj, float duration)
        {
            yield return new WaitForSeconds(duration);
            pooler.Despawn(obj);
        }

        #endregion

        #region PUBLIC METHODS

        public void Initialize(bool force = false)
        {
            if (pooler == null || force)
            {
                InitScriptableDelegate();
                InitPooler();
            }
        }

        public GameObject Spawn()
        {
            var obj =  pooler.Spawn();
            
            if (alwaysAutoDespawn)
                DespawnDelayed(obj, defaultAutoDespawnTime);
            
            return obj;
        }

        public T Spawn<T>() where T : Component => Spawn().GetComponent<T>();

        public GameObject SpawnWithAutoDespawn(float? despawnDuration = null)
        {
            var dur = despawnDuration ?? defaultAutoDespawnTime;
            var spawned = pooler.Spawn();
            DespawnDelayed(spawned, dur);
            return spawned;
        }

        public void Despawn(GameObject obj) => pooler.Despawn(obj);
        public void Despawn<T>(T obj) where T : Component => Despawn(obj.gameObject);
        public void DespawnAll() => pooler.DespawnAll();

        #endregion
    }
}