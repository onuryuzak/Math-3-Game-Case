using System;

namespace UnityEngine.Events
{
    [Serializable]
    public class FloatUnityEvent : UnityEvent<float>
    {
    }

    [Serializable]
    public class IntUnityEvent : UnityEvent<int>
    {
    }

    [Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {
    }

    [Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {
    }

    [Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>
    {
    }

    [Serializable]
    public class ObjectUnityEvent : UnityEvent<object>
    {
    }

    [Serializable]
    public class CollisionUnityEvent : UnityEvent<Collision>
    {
    }


    [Serializable]
    public class ColliderUnityEvent : UnityEvent<Collider>
    {
    }

    [Serializable]
    public class RigidbodyUnityEvent : UnityEvent<Rigidbody>
    {
    }
}