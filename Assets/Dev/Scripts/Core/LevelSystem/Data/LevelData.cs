using UnityEngine;

namespace Base.Core.LevelSystem.Data
{
    [CreateAssetMenu(menuName = "Level System/New Level", fileName = "Level")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private bool hasScene;
        [SerializeField] private SceneFieldAsset levelScene;
        public bool HasScene => hasScene;
        public SceneFieldAsset LevelScene => levelScene;

        public virtual void Loaded()
        {
        }

        public virtual void Unloaded()
        {
        }
    }
}
