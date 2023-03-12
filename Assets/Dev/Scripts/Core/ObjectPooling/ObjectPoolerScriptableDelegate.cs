using UnityEngine;

namespace Base.Core.Pooling
{
    [CreateAssetMenu(menuName = "Pooling/ObjectPoolerScriptableDelegate",
        fileName = "ObjectPoolerScriptableDelegate")]
    public class ObjectPoolerScriptableDelegate : ScriptableObject, IObjectPooler
    {
        #region INSPECTOR FIELDS

        [SerializeField] private GameObjectPooler.PoolItem poolItem;

        #endregion

        #region PRIVATE FIELDS

        private ObjectPoolerBehaviour objectPoolerBehaviour;

        #endregion

        #region PUBLIC FIELDS

        public GameObjectPooler.PoolItem PoolItem => poolItem;
        public GameObject Prefab => PoolItem.prefab;

        #endregion

        #region PRIVATE METHODS

        private bool CheckIfNotInitialized()
        {
            if (objectPoolerBehaviour == null)
            {
                Debug.LogError("Object Pooler Not initialized!");
                return false;
            }

            return false;
        }

        #endregion

        #region PUBLIC METHODS

        public void SetData(ObjectPoolerBehaviour poolerBehaviour)
        {
            objectPoolerBehaviour = poolerBehaviour;
        }

        public GameObject Spawn()
        {
            if (CheckIfNotInitialized()) return null;
            return objectPoolerBehaviour.Spawn();
        }

        public T Spawn<T>() where T : Component
        {
            if (CheckIfNotInitialized()) return null;
            return objectPoolerBehaviour.Spawn<T>();
        }

        public GameObject SpawnWithAutoDespawn(float? despawnDuration = null)
        {
            if (CheckIfNotInitialized()) return null;
            return objectPoolerBehaviour.SpawnWithAutoDespawn(despawnDuration);
        }

        public void Despawn(GameObject spawnedObject)
        {
            if (CheckIfNotInitialized()) return;
            objectPoolerBehaviour.Despawn(spawnedObject);
        }

        public void Despawn<T>(T spawnedObject) where T : Component
        {
            if (CheckIfNotInitialized()) return;
            objectPoolerBehaviour.Despawn(spawnedObject);
        }

        public void DespawnAll()
        {
            if (CheckIfNotInitialized()) return;
            objectPoolerBehaviour.DespawnAll();
        }

        #endregion
    }
}