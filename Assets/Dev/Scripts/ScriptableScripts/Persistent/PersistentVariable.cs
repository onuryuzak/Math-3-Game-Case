using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PersistentSO
{
    public abstract class PersistentVariable<T> : ScriptableObject
    {
        #region GUID

        [SerializeField] private Guid guid;
        private bool guidInitialized;

        public Guid Guid
        {
            get
            {
                if (!guidInitialized)
                    UpdateGuid();

                return guid;
            }
        }

        public string SaveKey => Guid.ToHexString();

        #endregion

        #region INSPECTOR PROPERTIES

        [Header("Settings")] [SerializeField] private T initialValue;

        [SerializeField] [OnValueChanged("OnVariableValueChanged")]
        private T value;

        [Header("Events")] public UnityEvent<T> OnChanged;

        #endregion

        #region PRIVATE PROPERTIES

        #endregion

        #region PUBLIC PROPERTIES

        public T Value
        {
            get
            {
                value = PersistentSOHelper.Load<T>(SaveKey, initialValue);
                return value;
            }
            set
            {
                this.value = PersistentSOHelper.Save<T>(SaveKey, value);
                OnChanged?.Invoke(value);
            }
        }

        #endregion

        #region ODIN METHODS

        private void OnVariableValueChanged() => Value = value;

        #endregion

        #region PROTECTED METHODS

        [Button]
        protected virtual void ClearPersistentData() => Value = initialValue;

        #endregion

        #region UNITY METHODS

        private void OnValidate() => UpdateGuid();

        #endregion

        #region PRIVATE METHODS

        private void UpdateGuid()
        {
#if UNITY_EDITOR
            var path = AssetDatabase.GetAssetPath(this);
            guid = new Guid(AssetDatabase.AssetPathToGUID(path));
#endif
        }

        #endregion

        #region OPERATOR OVERLOADING

        public static implicit operator T(PersistentVariable<T> variable) => variable.Value;

        #endregion
    }
}