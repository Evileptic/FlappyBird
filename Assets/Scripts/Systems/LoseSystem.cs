using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class LoseSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, LoseEvent> _eventFilter;

        private AudioPlayer _audioPlayer;
        private RuntimeData _runtime;
        private StaticData _static;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                if (_runtime.GameState != GameState.Play)
                {
                    _eventFilter.GetEntity(index).Del<LoseEvent>();
                    return;
                }

                _runtime.GameState = GameState.Lose;

                var birdEntity = _eventFilter.GetEntity(index);
                birdEntity.Del<MoveFlag>();

                ref var bird = ref _eventFilter.Get1(index);
                bird.Rigidbody2D.velocity = new Vector2(0f, bird.Rigidbody2D.velocity.y);

                _audioPlayer.ChannelOne.PlayOneShot(_static.Death);
                _audioPlayer.ChannelOne.PlayOneShot(_static.Hit, 0.7f);

                _eventFilter.GetEntity(index).Del<LoseEvent>();
            }
        }
    }
}