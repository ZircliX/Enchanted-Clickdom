using System.Collections.Generic;
using Ores;
using SaveSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public string playerName;
    public int level;
    public int money;
    
    public int oreMined;
    public float miningBonus;
    
    public Inventory inventory;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadPlayer();
    }
    
    private void LoadPlayer()
    {
        string loadedPlayerName = PlayerPrefs.GetString("Name", "Default");

        try
        {
            var loadedData = SavePlayer.Load(loadedPlayerName);
            PlayerData playerData = loadedData;
            
            Dictionary<OreUnit, int> oreInv = new Dictionary<OreUnit, int>();
            foreach (var entry in playerData.oreInventory.entries)
            {
                oreInv[entry.key] = entry.value;
            }

            playerName = playerData.playerName;
            money = playerData.level;
            money = playerData.money;
            oreMined = playerData.oreMined;
            miningBonus = playerData.miningBonus;
            inventory.ores = oreInv;
        }
        catch
        {
            // If no save data exists, initialize with default values
            playerName = loadedPlayerName;
            level = 1;
            money = 0;
            oreMined = 0;
            miningBonus = 0;
            inventory = new Inventory();

            SavePlayer.Save(this);
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    
    public int level;
    public int money;
    public int oreMined;
    public float miningBonus;

    public DictToList oreInventory;
}

[System.Serializable]
public class Inventory
{
    public Dictionary<OreUnit, int> ores = new();

    public void AddToOre(OreUnit ore)
    {
        if (ores.ContainsKey(ore))
        {
            ores[ore]++;
            return;
        }
        ores[ore] = 1;
    }
}

[System.Serializable]
public class ListEntity
{
    public OreUnit key;
    public int value;
}

[System.Serializable]
public class DictToList
{
    public List<ListEntity> entries = new ();
}