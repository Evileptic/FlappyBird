using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class InputSystem : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private SceneData _sceneData;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0) && _runtimeData.GameState == GameState.Play)
                _sceneData.BirdView.Entity.Get<JumpEvent>();
        }
    }
}