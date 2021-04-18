using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private RuntimeData _runtime;
        private StaticData _static;
        private SceneData _scene;

        public void Run()
        {
            var camera = _runtime.MainCamera;
            var bird = _scene.Bird;
            var cameraPosition = new Vector3(bird.transform.position.x - _static.CameraXOffset, camera.transform.position.y, camera.transform.position.z);
            camera.transform.position = cameraPosition;
        }
    }
}