using Base.Core.Pooling;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectFactory", menuName = "ScriptableObjects/Factory/GameObjectFactory")]
public class GameObjectFactory : ScriptableObject
{
    [SerializeField] private bool usePooler;
    [SerializeField] [ShowIf("usePooler")] [RequireInterface(typeof(IObjectPooler))] private Object pooler;
    [SerializeField] [HideIf("usePooler")] private GameObject prefab;

    private IObjectPooler Pooler => pooler as IObjectPooler;
    
    public GameObject Prefab => usePooler ? Pooler.Prefab : prefab;

    public GameObject Create(Vector3? pos = null, Quaternion? rot = null, Vector3? scale = null, Transform parent = null)
    {
        GameObject obj;
        if (usePooler)
        {
            obj = Pooler.Spawn();
            obj.transform.SetParent(parent);

            if (pos.HasValue)
                obj.transform.position = pos.Value;

            if (rot.HasValue)
                obj.transform.rotation = rot.Value;

            if (scale.HasValue)
                obj.transform.localScale = scale.Value;
        }
        else
        {
            obj = Instantiate(prefab, parent);

            if (pos.HasValue)
                obj.transform.position = pos.Value;

            if (rot.HasValue)
                obj.transform.rotation = rot.Value;

            if (scale.HasValue)
                obj.transform.localScale = scale.Value;
        }

        return obj;
    }

    public TComponent Create<TComponent>(Vector3? pos = null, Quaternion? rot = null, Vector3? scale = null, Transform parent = null)
        where TComponent : Component =>
        Create(pos, rot, scale, parent).GetComponent<TComponent>();
}

public abstract class GameObjectFactory<TComponent> : ScriptableObject where TComponent : Component
{
    [SerializeField] private TComponent prefab;
}