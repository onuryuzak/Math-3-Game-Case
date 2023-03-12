using Base.Core.Pooling;
using UnityEngine;

public interface IPooledObject
{
    public GameObjectPooler Pooler { get; set; }
}