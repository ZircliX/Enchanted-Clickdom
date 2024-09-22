using System.Collections.Generic;
using Ores;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Profile : MonoBehaviour
    {
        public TMP_Text[] oreTexts;
        
        private void OnEnable()
        {
            Dictionary<OreUnit, int> playerInv = Player.Instance.inventory.ores;
            OreUnit[] ores = Resources.LoadAll<OreUnit>("Ores");

            for (int i = 0; i < ores.Length; i++)
            {
                oreTexts[i].text = playerInv[ores[i]].ToString();
            }
        }
    }
}