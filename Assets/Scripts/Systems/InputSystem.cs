using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class InputSystem : IEcsRunSystem
    {
        private EcsFilter<Bird> _birdFilter;

        private RuntimeData _runtime;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0) && _runtime.GameState == GameState.Play)
                foreach (var index in _birdFilter)
                    _birdFilter.GetEntity(index).Get<JumpEvent>();
        }
    }
}