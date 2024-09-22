using Static;
using UnityEngine;

namespace UI
{
    public class Tavern : MonoBehaviour
    {
        public GameObject[] panels;
        private int currentIndex;
        
        public void GoToMine()
        {
            StaticFunctions.SwitchScene(1);
        }

        public void SwitchPanel(int index)
        {
            panels[currentIndex].SetActive(false);
            panels[index].SetActive(true);
            currentIndex = index;
        }
    }
}