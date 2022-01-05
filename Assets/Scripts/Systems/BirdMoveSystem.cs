using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class BirdMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, MoveFlag> _moveFilter;

        private StaticData _staticData;

        public void Run()
        {
            foreach (var index in _moveFilter)
            {
                var birdRigidBody = _moveFilter.Get1(index).Rigidbody2D;
                birdRigidBody.velocity = new Vector2(_staticData.BirdMoveSpeed, birdRigidBody.velocity.y);
            }
        }
    }
}