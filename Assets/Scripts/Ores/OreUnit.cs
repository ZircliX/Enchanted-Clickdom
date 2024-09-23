using UnityEngine;

namespace Ores
{
    [CreateAssetMenu(fileName = "NewOre", menuName = "ScriptableObjects/Ores", order = 1)]
    public class OreUnit : ScriptableObject
    {
        public string oreName;
        public Sprite oreImage;
        
        public Rarity oreRarity;
        public float oreValue;

        public float baseRarity;
    }

    [System.Serializable]
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
}