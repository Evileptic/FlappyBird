using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyBird.UI
{
    public class LoseScreen : Screen
    {
        public Button RestartLevelButton;

        private void Start()
        {
            RestartLevelButton.onClick.AddListener(RestartLevel);
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}