using UnityEngine.Events;

namespace UnityEngine.MonoUtils
{
    public class GameObjectEventsListener : MonoBehaviour
    {
        public UnityEvent OnAwake;
        public UnityEvent OnStart;
        public UnityEvent OnEnabled;
        public UnityEvent OnDisabled;

        private void Awake() => OnAwake?.Invoke();
        private void Start() => OnStart?.Invoke();
        private void OnEnable() => OnEnabled?.Invoke();
        private void OnDisable() => OnDisabled?.Invoke();
    }
}