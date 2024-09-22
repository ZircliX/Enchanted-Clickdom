using Static;
using UnityEngine;

namespace UI
{
    public class Gameplay : MonoBehaviour
    {
        public void GoToTavern()
        {
            StaticFunctions.SwitchScene(2);
        }

        public void SaveGame()
        {
            Player.Instance.PlayerToPlayerData();
        }
    }
}