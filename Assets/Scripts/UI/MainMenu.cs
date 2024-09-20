using TMPro;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public TMP_InputField nameInput;

        public void LoadGame()
        {
            PlayerPrefs.SetString("Name", nameInput.text);
        }
        
        public void Quit()
        {
            Application.Quit();
        }
    }
}