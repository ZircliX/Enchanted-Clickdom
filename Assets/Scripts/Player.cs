using System.Collections.Generic;
using Ores;
using SaveSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    public string playerName;
    public int level;
    public int oreMined;
    public float miningBonus;
    public Inventory inventory;
    
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }

        // Set this instance as the singleton instance
        Instance = this;
        
        // Make sure this object persists between scene loads
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadPlayer();
        DontDestroyOnLoad(this);
    }
    
    // Save the current state of the player to a file
    public void PlayerToPlayerData()
    {
        PlayerData playerData = new ()
        {
            playerName = playerName,
            level = level,
            oreMined = oreMined,
            miningBonus = miningBonus,
            inventory = inventory
        };

        SavePlayer.Save(playerData, playerName); // You will define this method
    }

    // Load the player data from a file and apply it to this MonoBehaviour
    private void LoadPlayer()
    {
        string loadedPlayerName = PlayerPrefs.GetString("Name", "Default");

        try
        {
            var loadedData = SavePlayer.Load(loadedPlayerName);
            PlayerData playerData = loadedData.Item1;
            Dictionary<OreUnit, int> inv = loadedData.Item2;

            this.playerName = playerData.playerName;
            this.level = playerData.level;
            this.oreMined = playerData.oreMined;
            this.miningBonus = playerData.miningBonus;
            this.inventory.ores = inv;
        }
        catch
        {
            // If no save data exists, initialize with default values
            this.playerName = loadedPlayerName;
            this.level = 1;
            this.oreMined = 0;
            this.miningBonus = 0;
            this.inventory = new Inventory();

            PlayerToPlayerData();
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    
    public int level;
    public int oreMined;
    public float miningBonus;

    public Inventory inventory;
}

[System.Serializable]
public class Inventory
{
    public Dictionary<OreUnit, int> ores = new();
}

[System.Serializable]
public class SerializableDictionaryEntry
{
    public OreUnit key;
    public int value;
}

[System.Serializable]
public class SerializableDictionary
{
    public List<SerializableDictionaryEntry> entries = new ();
}