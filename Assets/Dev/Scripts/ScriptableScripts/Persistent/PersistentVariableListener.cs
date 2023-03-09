using UnityEngine;
using UnityEngine.Events;

namespace PersistentSO
{
    public class PersistentVariableListener<T> : MonoBehaviour
    {
        [SerializeField] private PersistentVariable<T> variable;

        public UnityEvent<T> OnChanged;

        private void OnEnable() => variable.OnChanged.AddListener(OnValueChanged);

        private void OnDisable() => variable.OnChanged.RemoveListener(OnValueChanged);

        private void OnValueChanged(T value) => OnChanged?.Invoke(value);
    }
}