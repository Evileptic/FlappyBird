using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Events;
using FlappyBird.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private EcsFilter<Bird> _birdFilter;
        
        private RuntimeData _runtimeData;
        private SceneData _sceneData;

        public void Run()
        {
            if (_runtimeData.GameState != GameState.Play)
                return;
            
            // Add a jump event to the bird entity when mouse or space is pressed
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                foreach (var birdEntity in _birdFilter)
                    _birdFilter.GetEntity(birdEntity).Get<JumpEvent>();
        }
    }
}