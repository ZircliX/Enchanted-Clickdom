using Static;
using UnityEngine;

namespace UI
{
    public class Tavern : MonoBehaviour
    {
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
        }
    }
}