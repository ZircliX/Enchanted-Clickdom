using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainCanvas : MonoBehaviour
    {
        public GameObject[] panels;
        public GameObject eventSystem;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(eventSystem);
        }

        public void LoadScene(int index)
        {
            panels[SceneManager.GetActiveScene().buildIndex].SetActive(false);
            SceneManager.LoadScene(index);
            panels[index].SetActive(true);
        }
    }
}