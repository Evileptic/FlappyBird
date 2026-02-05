using FlappyBird.Data;
using FlappyBird.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private GameConfig _gameConfig;
        private SceneData _sceneData;

        public void Run()
        {
            if (_runtimeData.GameState == GameState.Lose) return;

            var camera = _sceneData.MainCamera;
            var bird = _sceneData.BirdActor;
            var cameraTransform = camera.transform;
            var cameraPosition = new Vector3(
                bird.transform.position.x - _gameConfig.CameraXOffset, 
                cameraTransform.position.y, 
                cameraTransform.position.z);
            cameraTransform.position = cameraPosition;
        }
    }
}