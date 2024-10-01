using Ores;
using Static;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Tavern : MonoBehaviour
    {
        public Slider[] amount;
        private OreUnit[] ores;

        private void Start()
        {
            ores = Resources.LoadAll<OreUnit>("Ores");
            for (int i = 0; i < amount.Length; i++)
            {
                amount[i].maxValue = Player.Instance.inventory.ores[ores[i]];
                amount[i].value = amount[i].maxValue;
            }
        }

        public void GoToMine()
        {
            StaticFunctions.SwitchScene(1);
        }
        
        public void Buy()
        {
            Debug.Log("Player is buying something.");
        }
        
        public void Sell()
        {
            Debug.Log("Player is selling something.");
            for (int i = 0; i < amount.Length; i++)
            {
                amount[i].maxValue = Player.Instance.inventory.ores[ores[i]];
                Player.Instance.money += (int)amount[i].value * (int)ores[i].oreValue;
                Debug.Log(amount[i].value * ores[i].oreValue);
                Player.Instance.inventory.ChangeOres(ores[i], (int)-amount[i].value);
            }
        }
    }
}