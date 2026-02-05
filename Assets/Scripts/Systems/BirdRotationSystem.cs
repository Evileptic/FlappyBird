using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Flags;
using FlappyBird.Comps.Refs;
using FlappyBird.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class BirdRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, TransformRef, RotationFlag> _birdRotationFilter;

        private GameConfig _gameConfig;

        public void Run()
        {
            foreach (var index in _birdRotationFilter)
            {
                var minRotation = Quaternion.Euler(0f, 0f, _gameConfig.BirdMinRotation);
                var birdTransform = _birdRotationFilter.Get2(index).Value;
                birdTransform.rotation = Quaternion.Lerp(
                    birdTransform.rotation,
                    minRotation,
                    _gameConfig.BirdRotationSpeed * Time.deltaTime);
            }
        }
    }
}