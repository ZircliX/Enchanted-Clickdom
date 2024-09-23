using System.IO;
using UnityEngine;

namespace SaveSystem
{
    public static class SavePlayer
    {
        public static void Save(Player player)
        {
            PlayerData playerData = ConvertPlayerData(player);
            
            string json = JsonUtility.ToJson(playerData, true);
            File.WriteAllText(Application.dataPath + "/StreamingAssets/" + playerData.playerName + ".json", json);
        }
        
        public static PlayerData Load(string name)
        {
            string jsonData = File.ReadAllText(Application.dataPath + "/StreamingAssets/" + name + ".json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
            return playerData;
        }
        
        private static PlayerData ConvertPlayerData(Player player)
        {
            DictToList dictToList = new ();
            foreach (var pair in player.inventory.ores)
            {
                dictToList.entries.Add(new ListEntity { key = pair.Key, value = pair.Value });
            }
        
            PlayerData playerData = new ()
            {
                playerName = player.playerName,
                level = player.level,
                oreMined = player.oreMined,
                miningBonus = player.miningBonus,
                oreInventory = dictToList
            };
        
            return playerData;
        }
    }
}