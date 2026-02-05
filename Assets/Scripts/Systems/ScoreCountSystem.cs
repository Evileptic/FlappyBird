using FlappyBird.Comps.Events;
using FlappyBird.Data;
using FlappyBird.SO;
using FlappyBird.UI;
using Leopotam.Ecs;

namespace FlappyBird.Systems
{
    public class ScoreCountSystem : IEcsRunSystem
    {
        private EcsFilter<ScoreCountEvent> _scoreCountEventFilter;

        private RuntimeData _runtimeData;
        private GameConfig _gameConfig;
        private SceneData _sceneData;
        private GameWindow _gameWindow;

        public void Run()
        {
            foreach (var eventIndex in _scoreCountEventFilter)
            {
                _gameWindow.GameScreen.ScoresText.text = (++_runtimeData.Score).ToString();
                _sceneData.AudioSource.PlayOneShot(_gameConfig.Score);
            }
        }
    }
}