using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Base.Scriptables
{
    [CreateAssetMenu(fileName = "Game-AssetReferanceSO", menuName = "Game/" + nameof(AssetReferanceSO))]
    public class AssetReferanceSO : GameSOBase
    {
        [SerializeField]private MonoBehaviour AssetReferanceNative;
        [SerializeField] private AssetReference AssetReferenceBundle;

        public T GetCastedType<T>()
        {
            if(AssetReferanceNative is T t) 
            {
                return t;
            }
            throw new InvalidCastException(AssetReferanceNative.GetType() + " is not " + typeof(T));
        }
        public Type GetAssetType => AssetReferanceNative.GetType();

        public static implicit operator MonoBehaviour(AssetReferanceSO assetReferanceSO)=>assetReferanceSO.AssetReferanceNative;
        public static implicit operator AssetReference(AssetReferanceSO assetReferanceSO) => assetReferanceSO.AssetReferenceBundle;

    }
}
