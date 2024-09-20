using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public static class SavePlayer
    {
        public static void Save(string name, Player player)
        {
            string json = JsonUtility.ToJson(player, true);
            File.WriteAllText(Application.dataPath + "/StreamingAssets/" + name + ".json", json);
        }
        
        public static Player Load(string name)
        {
            string jsonData = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + name + ".json");
            Player playerData = JsonUtility.FromJson<Player>(jsonData);
            return playerData;
        }
    }
}