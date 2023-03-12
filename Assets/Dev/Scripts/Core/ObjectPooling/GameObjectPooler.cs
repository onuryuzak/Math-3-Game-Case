using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Base.Core.Pooling
{
    public class GameObjectPooler
    {
        #region PRIVATE FIELDS

        private Queue<GameObject> pool;
        private List<GameObject> spawnedObjects;
        private int currentCapacity;
        
        private PoolItem poolItem;
        private Transform poolParent;

        #endregion

        #region CONSTRUCTORS

        public GameObjectPooler(PoolItem item, Transform parent)
        {
            poolItem = item;
            poolParent = parent;
            Initialize();
        }

        #endregion

        #region PUBLIC METHODS

        public GameObject Spawn()
        {
            GrowIfRequired();
            DespawnOldestIfRequired();

            GameObject spawnedObject = pool.Dequeue();
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
            spawnedObjects.Add(spawnedObject);

            if (spawnedObject.TryGetComponent<IPooledObject>(out var pooledObject))
                pooledObject.Pooler = this;
            
            return spawnedObject;
        }

        public T Spawn<T>() where T : Component => Spawn().GetComponent<T>();

        public void Despawn(GameObject spawnedObject)
        {
            spawnedObject.SetActive(false);
            spawnedObject.transform.SetParent(poolParent);
            pool.Enqueue(spawnedObject);
            spawnedObjects.Remove(spawnedObject);
        }

        public void Despawn<T>(T obj) where T : Component => Despawn(obj.gameObject);

        public void DespawnAll()
        {
            for (var i = spawnedObjects.Count - 1; i >= 0; i--)
            {
                var spawnedObject = spawnedObjects[i];
                Despawn(spawnedObject);
            }
        }
        
        #endregion

        #region PRIVATE METHODS

        private void DespawnOldestIfRequired()
        {
            if (!poolItem.despawnOldest)
                return;

            if (pool.Count == 0 && currentCapacity >= poolItem.maxCapacity)
            {
                GameObject oldest = spawnedObjects[0];
                Despawn(oldest);
            }
        }

        private void GrowIfRequired()
        {
            if (pool.Count == 0 && currentCapacity < poolItem.maxCapacity)
                Grow();
        }

        private void Initialize()
        {
            pool = new Queue<GameObject>(poolItem.initialSize);
            spawnedObjects = new List<GameObject>(poolItem.initialSize);
            Grow(poolItem.initialSize);
        }

        private void Grow(int count)
        {
            for (int i = 0; i < count; i++)
                Grow();
        }

        private void Grow()
        {
            GameObject obj = Object.Instantiate(poolItem.prefab, poolParent);
            obj.SetActive(false);
            pool.Enqueue(obj);
            currentCapacity++;
        }

        #endregion

        [Serializable]
        public struct PoolItem
        {
            public GameObject prefab;
            public int initialSize;
            public int maxCapacity;
            public bool despawnOldest;
        }
    }
}