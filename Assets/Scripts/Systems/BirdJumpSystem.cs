using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class BirdJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, JumpEvent> _eventFilter;

        private StaticData _static;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                ref var bird = ref _eventFilter.Get1(index);

                bird.Rigidbody2D.velocity = new Vector2(bird.Rigidbody2D.velocity.x, 0f);
                bird.Rigidbody2D.AddForce(Vector2.up * _static.BirdJumpForce, _static.BirdJumpForceType);
                bird.Transform.rotation = Quaternion.Euler(0f, 0f, _static.BirdMaxRotation);

                _eventFilter.GetEntity(index).Del<JumpEvent>();
            }
        }
    }
}