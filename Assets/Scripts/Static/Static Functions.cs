using UnityEngine.SceneManagement;

namespace Static
{
    public static class StaticFunctions
    {
        public static void SwitchScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}
