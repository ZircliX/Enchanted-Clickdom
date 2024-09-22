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
            
            int oreIndex = Random.Range(0, ores.Length);
            OreUnit oreMined = ores[oreIndex];
            
            AddToPlayer(oreMined);
            oreShow.oreData = oreMined;
        }

        private void AddToPlayer(OreUnit ore)
        {
            if (Player.Instance.inventory.ores.ContainsKey(ore))
            {
                // If the key exists, increment its value
                Player.Instance.inventory.ores[ore]++;
            }
            else
            {
                // If the key does not exist, initialize it with a value of 1
                Player.Instance.inventory.ores[ore] = 1;
            }

            Player.Instance.oreMined++;
        }
    }
}