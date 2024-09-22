using System.Collections.Generic;
using System.IO;
using Ores;
using UnityEngine;

namespace SaveSystem
{
    public static class SavePlayer
    {
        public static void Save(PlayerData player, string name)
        {
            SaveDictionaryToJson(player.inventory.ores, name);
            
            string json = JsonUtility.ToJson(player, true);
            File.WriteAllText(Application.dataPath + "/StreamingAssets/" + name + ".json", json);
        }
        
        public static (PlayerData, Dictionary<OreUnit, int>) Load(string name)
        {
            Dictionary<OreUnit, int> loadedDictionary = LoadDictionaryFromJson(name);
            
            string jsonData = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + name + ".json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            return (playerData, loadedDictionary);
        }
        
        // Save dictionary to JSON
        private static void SaveDictionaryToJson(Dictionary<OreUnit, int> dict, string name)
        {
            SerializableDictionary serializableDict = new ();
            foreach (var pair in dict)
            {
                serializableDict.entries.Add(new SerializableDictionaryEntry { key = pair.Key, value = pair.Value });
            }

            string json = JsonUtility.ToJson(serializableDict, true);
            File.WriteAllText(Application.dataPath + "/StreamingAssets/" + name + "Inventory" + ".json", json);
        }
        
        // Load dictionary from JSON
        private static Dictionary<OreUnit, int> LoadDictionaryFromJson(string fileName)
        {
            string filePath = Application.dataPath + "/StreamingAssets/" + fileName + "Inventory" + ".json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                SerializableDictionary serializableDict = JsonUtility.FromJson<SerializableDictionary>(json);

                Dictionary<OreUnit, int> dict = new Dictionary<OreUnit, int>();
                foreach (var entry in serializableDict.entries)
                {
                    dict[entry.key] = entry.value;
                }
                return dict;
            }
            return new Dictionary<OreUnit, int>();
        }
    }
}