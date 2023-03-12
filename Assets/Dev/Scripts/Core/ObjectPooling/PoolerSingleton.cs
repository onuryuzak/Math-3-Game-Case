using System.Collections.Generic;
using Base.Core.Pooling;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PoolerSingleton : Singleton<PoolerSingleton>
{
    [SerializeField] private List<ObjectPoolerBehaviour> poolers;

    protected override void OnInstanceCreated()
    {
        base.OnInstanceCreated();
        foreach (var pooler in poolers)
            pooler.Initialize(true);
    }

    public void DespawnAll()
    {
        foreach (var objectPoolerBehaviour in poolers)
        {
            objectPoolerBehaviour.DespawnAll();
        }
    }
}