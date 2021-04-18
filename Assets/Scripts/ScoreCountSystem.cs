using Leopotam.Ecs;

namespace FlappyBird
{
    public class ScoreCountSystem : IEcsRunSystem
    {
        private EcsFilter<ScoreCountEvent> _eventFilter;

        private RuntimeData _runtime;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                _ui.GameScreen.ScoresText.text = (++_runtime.Scores).ToString();
                _eventFilter.GetEntity(index).Destroy();
            }
        }
    }
}