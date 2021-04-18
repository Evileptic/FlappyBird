using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class InitializeSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private RuntimeData _runtime;

        public void Init()
        {
            // MainCamera reference cache
            _runtime.MainCamera = Camera.main;

            // Initialize Actors
            var actors = Object.FindObjectsOfType<Actor>();
            foreach (var actor in actors)
                actor.Init(_world);

            // Inject EcsWorld to UI screens
            var screens = Object.FindObjectsOfType<Screen>();
            foreach (var screen in screens)
                screen.InjectWorld(_world);
        }
    }
}