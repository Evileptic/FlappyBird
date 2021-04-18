using Leopotam.Ecs;

namespace FlappyBird
{
    public class ScoreCountSystem : IEcsRunSystem
    {
        private EcsFilter<ScoreCountEvent> _eventFilter;

        private AudioPlayer _audioPlayer;
        private RuntimeData _runtime;
        private StaticData _static;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                _ui.GameScreen.ScoresText.text = (++_runtime.Scores).ToString();

                _audioPlayer.ChannelOne.PlayOneShot(_static.Score, 0.5f);

                _eventFilter.GetEntity(index).Destroy();
            }
        }
    }
}