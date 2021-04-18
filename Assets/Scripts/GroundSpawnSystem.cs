using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class GroundSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RuntimeData _runtime;
        private StaticData _static;
        private SceneData _scene;

        public void Init()
        {
            var gorundPrefab = _static.GroundPrefab;

            _runtime.GroundWidth = gorundPrefab.GetComponent<BoxCollider2D>().size.x * gorundPrefab.transform.localScale.x;

            float groundXPosition = 0f;

            for (int i = 0; i < _static.GroundPoolSize; i++)
            {
                var ground = Object.Instantiate(_static.GroundPrefab);
                ground.transform.position = new Vector2(groundXPosition, ground.transform.position.y);
                groundXPosition += _runtime.GroundWidth;

                _runtime.GroundPool.Enqueue(ground);
            }

            _runtime.GroundSpawnTrigger = _runtime.GroundWidth;
        }

        public void Run()
        {
            if (_scene.Bird.transform.position.x >= _runtime.GroundSpawnTrigger)
            {
                var groundForMove = _runtime.GroundPool.Dequeue();
                float groundXPosition = groundForMove.transform.position.x + _runtime.GroundWidth * _static.GroundPoolSize;
                groundForMove.transform.position = new Vector2(groundXPosition, groundForMove.transform.position.y);

                _runtime.GroundPool.Enqueue(groundForMove);
                _runtime.GroundSpawnTrigger += _runtime.GroundWidth;
            }
        }
    }
}