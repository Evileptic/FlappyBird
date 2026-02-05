using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Events;
using FlappyBird.Comps.Refs;
using FlappyBird.Data;
using FlappyBird.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class BirdJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, TransformRef, Rigidbody2DRef, JumpEvent> _jumpEventFilter;
        
        private GameConfig _gameConfig;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _jumpEventFilter)
            {
                var birdTransform = _jumpEventFilter.Get2(index).Value;
                birdTransform.rotation = Quaternion.Euler(0f, 0f, _gameConfig.BirdMaxRotation);

                var birdRigidbody = _jumpEventFilter.Get3(index).Value;
                birdRigidbody.linearVelocity = new Vector2(birdRigidbody.linearVelocity.x, 0f);
                birdRigidbody.AddForce(Vector2.up * _gameConfig.BirdJumpForce, _gameConfig.BirdJumpForceType);
                
                _sceneData.AudioSource.PlayOneShot(_gameConfig.Jump);
            }
        }
    }
}