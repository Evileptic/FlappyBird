using System.Collections.Generic;
using FlappyBird.Data;
using FlappyBird.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public sealed class TubesSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private GameConfig _gameConfig;
        private SceneData _sceneData;

        private readonly Queue<GameObject> _tubesPool = new();
        private float _spawnTriggerX;

        public void Init()
        {
            InitializePool(
                _gameConfig.TubesPrefab,
                _gameConfig.TubesPoolSize,
                _gameConfig.TubesStartSpawnOffset,
                _gameConfig.TubesSpawnDistance
            );

            _spawnTriggerX = _gameConfig.TubesStartSpawnOffset + _gameConfig.TubesSpawnDistance;
        }

        public void Run()
        {
            if (!IsNeedSpawn(_sceneData.BirdActor.transform.position.x, _spawnTriggerX))
                return;

            MoveOldestTubeToEnd();
            _spawnTriggerX += _gameConfig.TubesSpawnDistance;
        }

        private void InitializePool(GameObject prefab, int poolSize, float startOffsetX, float spawnDistance)
        {
            _tubesPool.Clear();

            float x = startOffsetX;
            for (int i = 0; i < poolSize; i++)
            {
                var tube = Object.Instantiate(prefab);
                SetPosition(tube.transform, x, GetRandomY());

                x += spawnDistance;
                _tubesPool.Enqueue(tube);
            }
        }

        private void MoveOldestTubeToEnd()
        {
            var tube = _tubesPool.Dequeue();
            float newX = tube.transform.position.x + _gameConfig.TubesSpawnDistance * _gameConfig.TubesPoolSize;
            SetPosition(tube.transform, newX, GetRandomY());

            _tubesPool.Enqueue(tube);
        }

        private float GetRandomY() =>
            Random.Range(_gameConfig.TubesMinYRandom, _gameConfig.TubesMaxYRandom);

        private static bool IsNeedSpawn(float birdX, float triggerX) => birdX >= triggerX;

        private static void SetPosition(Transform transform, float x, float y)
        {
            var pos = transform.position;
            pos.x = x;
            pos.y = y;
            transform.position = pos;
        }
    }
}
