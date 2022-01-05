using Leopotam.Ecs;

namespace FlappyBird
{
    public class ScoreCountSystem : IEcsRunSystem
    {
        private EcsFilter<ScoreCountEvent> _scoreCountFilter;

        private RuntimeData _runtimeData;
        private StaticData _staticData;
        private SceneData _sceneData;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _scoreCountFilter)
            {
                _ui.GameScreen.ScoresText.text = (++_runtimeData.Scores).ToString();
                _sceneData.AudioSource.PlayOneShot(_staticData.Score);

                _scoreCountFilter.GetEntity(index).Destroy();
            }
        }
    }
}