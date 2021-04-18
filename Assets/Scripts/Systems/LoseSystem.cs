using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class LoseSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, LoseEvent> _eventFilter;

        private RuntimeData _runtime;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                _runtime.GameState = GameState.Lose;

                var birdEntity = _eventFilter.GetEntity(index);
                birdEntity.Del<MoveFlag>();

                ref var bird = ref _eventFilter.Get1(index);
                bird.Rigidbody2D.velocity = new Vector2(0f, bird.Rigidbody2D.velocity.y);

                _eventFilter.GetEntity(index).Del<LoseEvent>();
            }
        }
    }
}