using UnityEngine;

namespace Ores
{
    [CreateAssetMenu(menuName = "Ores", fileName = "NewOre")]
    public class OreUnit : ScriptableObject
    {
        public string oreName;
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