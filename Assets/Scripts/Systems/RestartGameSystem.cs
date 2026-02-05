using UnityEngine.SceneManagement;
using FlappyBird.UI;
using Leopotam.Ecs;

namespace FlappyBird.Systems
{
    public class RestartGameSystem : IEcsInitSystem
    {
        private GameWindow _gameWindow;
        
        public void Init()
        {
            _gameWindow.LoseScreen.RestartLevelButton.onClick.AddListener(RestartLevel);
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}