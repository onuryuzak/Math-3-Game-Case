using UnityEngine;

namespace GameCore.Extensions
{
    public static class ComponentExtensions
    {
        public static T GetOrAddComponent<T>(this Component c) where T : Component =>
            c.gameObject.GetOrAddComponent<T>();

        public static Renderer GetRenderer(this Component c) => c.GetComponent<Renderer>();
        public static MeshRenderer GetMeshRenderer(this Component c) => c.GetComponent<MeshRenderer>();
        public static Rigidbody GetRigidbody(this Component c) => c.GetComponent<Rigidbody>();
        public static Rigidbody GetOrAddRigidbody(this Component c) => c.GetOrAddComponent<Rigidbody>();
        public static Material GetMaterial(this Component c) => c.GetRenderer().material;
        public static Collider GetCollider(this Component c) => c.GetComponent<Collider>();
        public static MeshCollider GetMeshCollider(this Component c) => c.GetComponent<MeshCollider>();
        public static MeshCollider GetOrAddMeshCollider(this Component c) => c.GetOrAddComponent<MeshCollider>();
        public static MeshFilter GetMeshFilter(this Component c) => c.GetComponent<MeshFilter>();
        public static Mesh GetMesh(this Component c) => c.GetMeshFilter().mesh;
        public static void SetMesh(this Component c, Mesh mesh) => c.GetMeshFilter().mesh = mesh;
        public static Vector3 GetPosition(this Component c) => c.transform.position;
        public static void SetPosition(this Component c, Vector3 position) => c.transform.position = position;
        public static Quaternion GetRotation(this Component c) => c.transform.rotation;
        public static void SetRotation(this Component c, Quaternion rotation) => c.transform.rotation = rotation;
        public static Vector3 GetLocalScale(this Component c) => c.transform.localScale;

        public static void SetLocalScale(this Component c, Vector3 localScale) =>
            c.transform.localScale = localScale;

        public static Vector3 GetLossyScale(this Component c) => c.transform.lossyScale;

        public static void SetLayerRecursively(this Component c, int layer) => c.gameObject.SetLayerRecursively(layer);
    }
}
