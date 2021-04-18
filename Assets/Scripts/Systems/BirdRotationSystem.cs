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
                ref var bird = ref _rotationFilter.Get1(index);
                var minRotation = Quaternion.Euler(0f, 0f, _static.BirdMinRotation);
                bird.Transform.rotation = Quaternion.Lerp(bird.Transform.rotation, minRotation, _static.RotationSpeed * Time.deltaTime);
            }
        }
    }
}