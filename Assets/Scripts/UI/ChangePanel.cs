using UnityEngine;

namespace UI
{
    public class ChangePanel : MonoBehaviour
    {
        public GameObject[] panels;
        private int currentIndex;
        
        public void SwitchPanel(int index)
        {
            panels[currentIndex].SetActive(false);
            panels[index].SetActive(true);
            currentIndex = index;
        }
    }
}