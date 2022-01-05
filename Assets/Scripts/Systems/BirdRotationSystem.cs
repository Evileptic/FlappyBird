using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class BirdRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, RotationFlag> _birdRotationFilter;

        private StaticData _staticData;

        public void Run()
        {
            foreach (var index in _birdRotationFilter)
            {
                var minRotation = Quaternion.Euler(0f, 0f, _staticData.BirdMinRotation);
                var birdTransform = _birdRotationFilter.Get1(index).Transform;
                birdTransform.rotation = Quaternion.Lerp(
                    birdTransform.rotation,
                    minRotation,
                    _staticData.BirdRotationSpeed * Time.deltaTime);
            }
        }
    }
}