using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Flags;
using FlappyBird.Comps.Refs;
using FlappyBird.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class BirdMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, Rigidbody2DRef, MoveFlag> _moveFilter;

        private GameConfig _gameConfig;

        public void Run()
        {
            foreach (var index in _moveFilter)
            {
                var birdRigidBody = _moveFilter.Get2(index).Value;
                birdRigidBody.linearVelocity = new Vector2(_gameConfig.BirdMoveSpeed, birdRigidBody.linearVelocity.y);
            }
        }
    }
}