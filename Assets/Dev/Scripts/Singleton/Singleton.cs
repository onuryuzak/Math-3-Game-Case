using UnityEngine;


/// <summary>
/// Inherit from this base class to create a singleton.
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected bool dontDestroyOnLoad = true;
    [SerializeField] protected bool useDestroyImmediate;

    private static object m_Lock = new object();
    private static T m_Instance;

    /// <summary>
    /// Always call it after Awake() is invoked.
    /// Otherwise UnityException might be thrown respecting Script Serialization rules.
    /// </summary>
    public static T Instance
    {
        get
        {
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    // Search for existing instance.
                    m_Instance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";
                    }
                }

                return m_Instance;
            }
        }
    }

    /// <summary>
    /// Always call this when overriding, but does not instantiate any object in it.
    /// If this object is duplicated, it will be destroyed on Start as well.
    /// </summary>
    protected virtual void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this as T;
            if (dontDestroyOnLoad)
            {
                transform.SetParent(null);
                DontDestroyOnLoad(this);
            }

            OnInstanceCreated();
        }
        else if (m_Instance != this)
        {
            if (useDestroyImmediate)
                DestroyImmediate(gameObject);
            else
                Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called when the instance is created.
    /// </summary>
    protected virtual void OnInstanceCreated()
    {
    }

    protected virtual void OnInstanceDestroyed()
    {
    }

    protected virtual void OnDestroy()
    {
        if (this == m_Instance)
            OnInstanceDestroyed();
    }
}