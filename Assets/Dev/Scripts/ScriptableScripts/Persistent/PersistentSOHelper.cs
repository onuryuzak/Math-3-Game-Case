using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PersistentSO
{
    public static class PersistentSOHelper
    {
        #region PRIVATE FIELDS

        private static string SaveFolderPath => Application.persistentDataPath + "/PersistentSO";

        #endregion

        #region PUBLIC METHODS

        public static void CreateDirectoryIfNotExist()
        {
            if (!ExistsAny())
                Directory.CreateDirectory(SaveFolderPath);
        }

        public static bool ExistsAny() => Directory.Exists(SaveFolderPath);

        public static List<Guid> GetAllGuids()
        {
            var guids = new List<Guid>();
            var files = Directory.GetFiles(SaveFolderPath);
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                guids.Add(new Guid(fileName));
            }

            return guids;
        }

        public static void Clear(string name)
        {
            if (FileExists(name))
                File.Delete(CombineSavePath(name));
        }

        public static void ClearAll()
        {
            if (Directory.Exists(SaveFolderPath))
                Directory.Delete(SaveFolderPath, true);
        }

        public static T Save<T>(string name, T value)
        {
            CreateDirectoryIfNotExist();
            var path = CombineSavePath(name);
            var bf = new BinaryFormatter();
            var file = new StreamWriter(path);
            var json = JsonUtility.ToJson(new VariableWrapper<T>(value));
            bf.Serialize(file.BaseStream, json);
            file.Close();
            return value;
        }

        public static T Load<T>(string name, T initialValue)
        {
            CreateDirectoryIfNotExist();
            if (!FileExists(name))
            {
                Save(name, initialValue);
            }

            var path = CombineSavePath(name);
            var bf = new BinaryFormatter();
            var file = new StreamReader(path);
            if (file.BaseStream.Length == 0)
                return initialValue;

            var json = (string) bf.Deserialize(file.BaseStream);

            var value = JsonUtility.FromJson<VariableWrapper<T>>(json).Value;
            file.Close();
            return value;
        }

        public static bool FileExists(string name) => File.Exists(CombineSavePath(name));

        #endregion

        #region PRIVATE METHODS

        private static string CombineSavePath(string name) => SaveFolderPath + $"/{name}.dat";

        #endregion
    }
}