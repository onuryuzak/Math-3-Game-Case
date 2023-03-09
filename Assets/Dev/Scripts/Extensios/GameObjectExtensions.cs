using UnityEngine;

namespace GameCore.Extensions
{
    public static class GameObjectExtensions
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        var component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }

    public static Renderer GetRenderer(this GameObject go) => go.GetComponent<Renderer>();
    public static MeshRenderer GetMeshRenderer(this GameObject go) => go.GetComponent<MeshRenderer>();
    public static Rigidbody GetRigidbody(this GameObject go) => go.GetComponent<Rigidbody>();
    public static Rigidbody GetOrAddRigidbody(this GameObject go) => go.GetOrAddComponent<Rigidbody>();
    public static Material GetMaterial(this GameObject go) => go.GetRenderer().material;
    public static Collider GetCollider(this GameObject go) => go.GetComponent<Collider>();
    public static MeshCollider GetMeshCollider(this GameObject go) => go.GetComponent<MeshCollider>();
    public static MeshCollider GetOrAddMeshCollider(this GameObject go) => go.GetOrAddComponent<MeshCollider>();
    public static MeshFilter GetMeshFilter(this GameObject go) => go.GetComponent<MeshFilter>();
    public static Mesh GetMesh(this GameObject go) => go.GetMeshFilter().mesh;
    public static void SetMesh(this GameObject go, Mesh mesh) => go.GetMeshFilter().mesh = mesh;
    public static Vector3 GetPosition(this GameObject go) => go.transform.position;
    public static void SetPosition(this GameObject go, Vector3 position) => go.transform.position = position;
    public static Quaternion GetRotation(this GameObject go) => go.transform.rotation;
    public static void SetRotation(this GameObject go, Quaternion rotation) => go.transform.rotation = rotation;
    public static Vector3 GetLocalScale(this GameObject go) => go.transform.localScale;

    public static void SetLocalScale(this GameObject go, Vector3 localScale) =>
        go.transform.localScale = localScale;

    public static Vector3 GetLossyScale(this GameObject go) => go.transform.lossyScale;

    public static void SetLayerRecursively(this GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
            SetLayerRecursively(child.gameObject, layer);
    }
}
}
