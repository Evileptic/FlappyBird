using FlappyBird.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class InitializeSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private SceneData _sceneData;

        public void Init()
        {
            // Cache camera reference
            _sceneData.MainCamera = Camera.main;
            
            // Find all actors in the scene and initialize them
            var actors = Object.FindObjectsByType<Actor>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var actor in actors)
                actor.Init(_ecsWorld);
        }
    }
}