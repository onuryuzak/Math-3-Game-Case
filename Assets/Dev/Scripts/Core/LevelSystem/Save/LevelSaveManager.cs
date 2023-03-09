using UnityEngine;

namespace Base.Core.LevelSystem.Save
{
    public static class LevelSaveManager
    {
        public const string LevelNumberKey = "LevelNumber"; // starts from 1
        public const string LevelIndexKey = "LevelIndex"; // starts from 0
        public const string HighestLevelNumberKey = "HighestLevelNumber"; // starts from 1

        public static void SaveLevel(int levelNumber, int levelIndex)
        {
            SaveLevelNumber(levelNumber);
            SaveLevelIndex(levelIndex);
        }

        public static void SaveLevelNumber(int levelNumber)
        {
            var maxLevelNumber = GetHighestLevelNumber();
            if (levelNumber > maxLevelNumber)
                SaveHighestLevelNumber(levelNumber);

            PlayerPrefs.SetInt(LevelNumberKey, levelNumber);
        }

        public static int GetLevelNumber(int defaultValue = 1) => PlayerPrefs.GetInt(LevelNumberKey, defaultValue);

        public static void SaveLevelIndex(int index) => PlayerPrefs.SetInt(LevelIndexKey, index);

        public static int GetLevelIndex(int defaultValue = 0) => PlayerPrefs.GetInt(LevelIndexKey, defaultValue);

        public static void SaveHighestLevelNumber(int levelNumber) =>
            PlayerPrefs.SetInt(HighestLevelNumberKey, levelNumber);

        public static int GetHighestLevelNumber(int defaultValue = 1) =>
            PlayerPrefs.GetInt(HighestLevelNumberKey, defaultValue);
    }
}

