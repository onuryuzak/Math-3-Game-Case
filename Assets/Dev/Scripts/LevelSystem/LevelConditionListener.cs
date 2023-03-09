using Base.Core.LevelSystem;
using MyBox;
using UnityEngine;
using UnityEngine.Events;

namespace GameCore.Scripts.LevelSystems
{
    public class LevelConditionListener : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private LevelSystem levelSystem;

        [Header("Settings")] [SerializeField] private MinMaxInt intervals = new MinMaxInt(0, int.MaxValue);

        [Header("Events")] public UnityEvent OnTrueMatchAtAwake;
        public UnityEvent OnFalseMatchAtAwake;
        public UnityEvent OnTrueMatchAtStart;
        public UnityEvent OnFalseMatchAtStart;

        private bool Enabled => levelSystem.CurrentLevelNumber >= intervals.Min &&
                                levelSystem.CurrentLevelNumber <= intervals.Max;

        private void Awake() => TriggerAwakeEvents();

        private void Start() => TriggerStartEvents();

        private void TriggerAwakeEvents()
        {
            if (Enabled)
                OnTrueMatchAtAwake?.Invoke();
            else
                OnFalseMatchAtAwake?.Invoke();
        }

        private void TriggerStartEvents()
        {
            if (Enabled)
                OnTrueMatchAtStart?.Invoke();
            else
                OnFalseMatchAtStart?.Invoke();
        }
    }
}