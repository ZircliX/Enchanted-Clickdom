using System;
using System.Collections.Generic;
using Ores;
using SaveSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    
    public int level;
    public float miningBonus;

    public Inventory inventory;

    private void Start()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        string newPlayerName = PlayerPrefs.GetString("Name");
        
        try
        {
            Player player = SavePlayer.Load(newPlayerName);
            
            playerName = player.playerName;
            level = player.level;
            miningBonus = player.miningBonus;
            inventory = player.inventory;
        }
        catch
        {
            playerName = newPlayerName;
            level = 1;
            miningBonus = 0;
            inventory = new Inventory();

            SavePlayer.Save(playerName, this);
        }
    }
}

[System.Serializable]
public class Inventory
{
    public Dictionary<OreUnit, int> ores;
}