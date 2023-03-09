using System.Collections.Generic;
using Base.Core.LevelSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameCore.Scripts.LevelSystems
{
    public abstract class LevelNumberSettings<TData> : ScriptableObject where TData : ILevelNumberSettingsData, new()
    {
        #region INSPECTOR PROPERTIES

        [SerializeField] protected LevelSystem levelSystem;
        [SerializeField] protected bool ignoreLevelStartEndAndLoop;

        [Space] [SerializeField] [ListDrawerSettings(CustomAddFunction = "AddNewSettingsData")]
        protected List<TData> settingsByLevel;

        #endregion

        #region PUBLIC METHODS

        public virtual TData GetSettingsByCurrentLevelNumber()
        {
            var levelNumber = levelSystem.CurrentLevelNumber;
            var data =
                ignoreLevelStartEndAndLoop
                    ? settingsByLevel[levelNumber % settingsByLevel.Count]
                    : settingsByLevel
                        .Find(data =>
                            levelNumber >= data.LevelStartEnd.x && levelNumber <= data.LevelStartEnd.y);

            return data;
        }

        #endregion

        #region ODIN METHODS

        protected virtual TData AddNewSettingsData()
        {
            return new TData();
        }

        #endregion
    }

    public interface ILevelNumberSettingsData
    {
        Vector2Int LevelStartEnd { get; }
    }
    
}
