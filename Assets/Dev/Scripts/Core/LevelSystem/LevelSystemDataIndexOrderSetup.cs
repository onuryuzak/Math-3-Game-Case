using System.Collections.Generic;
using System.Linq;
using Base.Core.LevelSystem.Data;
using UnityEngine;

namespace Base.Core.LevelSystem
{
    public class LevelSystemDataIndexOrderSetup : MonoBehaviour
    {
        #region INSPECTOR FIELDS

        [SerializeField] private LevelSystem levelSystem;
        [SerializeField] private LevelSystemData originalData;

        #endregion

        #region UNITY METHODS

        private void OnApplicationQuit() => levelSystem.UpdateLevelSystemData(originalData);

        #endregion

        #region PUBLIC METHODS

        public void Setup(List<int> indexOrders)
        {
            levelSystem.UpdateLevelSystemData(originalData);
            var orders = new List<int>(indexOrders);
            var cloneData = Instantiate(originalData);
            var levels = cloneData.Levels;
            if (levelSystem.IsRecyclingLevels)
            {
                var exceptedLevelsIndexes =
                    originalData.ExceptedLevelsOnRecycle.Select(exceptedLevel => levels.IndexOf(exceptedLevel));
                foreach (var exceptedLevelIndex in exceptedLevelsIndexes)
                {
                    if (orders.Contains(exceptedLevelIndex))
                        orders.RemoveAt(exceptedLevelIndex);
                }
            }

            var orderedLevels = new List<LevelData>(levels.Count);
            foreach (var order in orders)
            {
                if (order < levels.Count)
                    orderedLevels.Add(levels[order]);
            }

            cloneData.SetLevels(orderedLevels);
            levelSystem.UpdateLevelSystemData(cloneData);
        }

        #endregion
    }
}
