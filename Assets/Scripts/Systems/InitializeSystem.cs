using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class InitializeSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private RuntimeData _runtimeData;

        public void Init()
        {
            _runtimeData.MainCamera = Camera.main;

            var actors = Object.FindObjectsOfType<View>();
            foreach (var actor in actors)
                actor.Init(_ecsWorld);

            var screens = Object.FindObjectsOfType<Screen>();
            foreach (var screen in screens)
                screen.InjectWorld(_ecsWorld);
        }
    }
}