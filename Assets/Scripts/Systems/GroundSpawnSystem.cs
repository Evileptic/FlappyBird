using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class GroundSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Init()
        {
            var groundPrefab = _staticData.GroundPrefab;

            _runtimeData.GroundWidth = groundPrefab.GetComponent<BoxCollider2D>().size.x * groundPrefab.transform.localScale.x;

            float groundXPosition = 0f;

            for (int i = 0; i < _staticData.GroundPoolSize; i++)
            {
                var ground = Object.Instantiate(_staticData.GroundPrefab);
                ground.transform.position = new Vector2(groundXPosition, ground.transform.position.y);
                groundXPosition += _runtimeData.GroundWidth;

                _runtimeData.GroundPool.Enqueue(ground);
            }

            _runtimeData.GroundSpawnTrigger = _runtimeData.GroundWidth;
        }

        public void Run()
        {
            if (_sceneData.BirdView.transform.position.x >= _runtimeData.GroundSpawnTrigger)
            {
                var groundForMove = _runtimeData.GroundPool.Dequeue();
                float groundXPosition = groundForMove.transform.position.x + _runtimeData.GroundWidth * _staticData.GroundPoolSize;
                groundForMove.transform.position = new Vector2(groundXPosition, groundForMove.transform.position.y);

                _runtimeData.GroundPool.Enqueue(groundForMove);
                _runtimeData.GroundSpawnTrigger += _runtimeData.GroundWidth;
            }
        }
    }
}