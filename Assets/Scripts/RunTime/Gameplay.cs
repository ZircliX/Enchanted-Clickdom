using Ores;
using UnityEngine;

namespace RunTime
{
    public class Gameplay : MonoBehaviour
    {
        private OreUnit[] ores;

        public OreShow oreShow;
    
        private void Start()
        {
            ores = Resources.LoadAll<OreUnit>("Ores");
        }
    
        public void Mine()
        {
            Debug.Log("Player is mining ores.");

            OreUnit oreMined = GetRandomOreByRarity();
        
            AddToPlayer(oreMined);
            oreShow.oreData = oreMined;
        }

        private OreUnit GetRandomOreByRarity()
        {
            // Total weight
            float totalWeight = 0f;
            foreach (OreUnit ore in ores)
            {
                totalWeight += 1f / ore.baseRarity;
            }
            
            float randomValue = Random.Range(0f, totalWeight);

            // Picks ore based on weight values
            float cumulativeWeight = 0f;
            foreach (OreUnit ore in ores)
            {
                cumulativeWeight += 1f / ore.baseRarity;
                
                if (randomValue < cumulativeWeight)
                {
                    return ore;
                }
            }
            
            return ores[0];
        }

        private void AddToPlayer(OreUnit ore)
        {
            Player.Instance.oreMined++;
            Player.Instance.inventory.AddToOre(ore);
        }
    }
}