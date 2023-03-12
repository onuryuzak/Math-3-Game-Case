using UnityEngine;

namespace Base.Core.Pooling
{
    public interface IObjectPooler
    {
        public GameObject Prefab { get; }
        public GameObject Spawn();
        public T Spawn<T>() where T : Component;
        public GameObject SpawnWithAutoDespawn(float? despawnDuration = null);
        public void Despawn(GameObject obj);
        public void Despawn<T>(T obj) where T : Component;
        public void DespawnAll();
    }
}