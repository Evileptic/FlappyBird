using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            if (_runtimeData.GameState == GameState.Lose) return;

            var camera = _runtimeData.MainCamera;
            var bird = _sceneData.BirdView;
            var cameraTransform = camera.transform;
            var cameraPosition = new Vector3(
                bird.transform.position.x - _staticData.CameraXOffset, 
                cameraTransform.position.y, 
                cameraTransform.position.z);
            cameraTransform.position = cameraPosition;
        }
    }
}