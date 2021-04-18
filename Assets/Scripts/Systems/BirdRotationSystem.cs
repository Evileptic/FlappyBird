using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class BirdRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, RotationFlag> _rotationFilter;

        private StaticData _static;

        public void Run()
        {
            foreach (var index in _rotationFilter)
            {
                var minRotation = Quaternion.Euler(0f, 0f, _static.BirdMinRotation);
                var birdTransform = _rotationFilter.Get1(index).Transform;
                birdTransform.rotation = Quaternion.Lerp(birdTransform.rotation, minRotation, _static.BirdRotationSpeed * Time.deltaTime);
            }
        }
    }
}