using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class BirdMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, MoveFlag> _moveFilter;

        private StaticData _static;

        public void Run()
        {
            foreach (var index in _moveFilter)
            {
                ref var bird = ref _moveFilter.Get1(index);

                bird.Rigidbody2D.velocity = new Vector2(_static.BirdMoveSpeed, bird.Rigidbody2D.velocity.y);
            }
        }
    }
}