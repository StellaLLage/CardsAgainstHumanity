using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveGameManager
    {
        private static SaveData _currentSaveData = new SaveData();
        public static SaveData CurrentSaveData => _currentSaveData;

        private const string _directory = "/SaveData/";
        private const string _fileName = "Cards.csv";

        public static bool Save()
        {
            var directoryCache = Application.persistentDataPath + _directory;
            
            if (!Directory.Exists(directoryCache))
                Directory.CreateDirectory(directoryCache);

            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(directoryCache + _fileName, json);

            GUIUtility.systemCopyBuffer = directoryCache;
            Debug.Log($"Save Completed!");
            Debug.Log($"Directory: {GUIUtility.systemCopyBuffer}");
            return true;
        }

        public static void Load()
        {
            string fullPath = Application.persistentDataPath + _directory + _fileName; 
            SaveData dataTemp = new SaveData();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                dataTemp = JsonUtility.FromJson<SaveData>(json);
                Debug.Log("Load completed!");
                
            }
            else
                Debug.LogError("Save file does not exists!");

            _currentSaveData = dataTemp;
        }
    }
}
