using System.Collections.Generic;
using FlappyBird.Monos.Views;
using FlappyBird.Data;
using FlappyBird.SO;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public sealed class GroundSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private GameConfig _gameConfig;
        private SceneData _sceneData;

        private readonly Queue<GroundView> _groundPool = new();
        private float _groundWidth;
        private float _groundSpawnTrigger;
        
        public void Init()
        {
            _groundWidth = CalculateGroundWidth(_gameConfig.GroundPrefab);
            InitializeGroundPool(_gameConfig.GroundPrefab, _gameConfig.GroundPoolSize, _groundWidth);
            _groundSpawnTrigger = _groundWidth;
        }

        public void Run()
        {
            if (!IsNeedSpawn(_sceneData.BirdActor.transform.position.x, _groundSpawnTrigger))
                return;

            MoveOldestTileToEnd();
            _groundSpawnTrigger += _groundWidth;
        }

        private static float CalculateGroundWidth(GroundView groundPrefab)
        {
            var collider = groundPrefab.BoxCollider;
            return collider.size.x * groundPrefab.transform.localScale.x;
        }

        private void InitializeGroundPool(GroundView groundPrefab, int poolSize, float tileWidth)
        {
            _groundPool.Clear();

            float x = 0f;
            for (int i = 0; i < poolSize; i++)
            {
                var tile = Object.Instantiate(groundPrefab);
                SetX(tile.transform, x);
                x += tileWidth;

                _groundPool.Enqueue(tile);
            }
        }

        private static bool IsNeedSpawn(float birdX, float triggerX) => birdX >= triggerX;

        private void MoveOldestTileToEnd()
        {
            var tile = _groundPool.Dequeue();
            float newX = tile.transform.position.x + _groundWidth * _gameConfig.GroundPoolSize;
            SetX(tile.transform, newX);

            _groundPool.Enqueue(tile);
        }

        private static void SetX(Transform transform, float x)
        {
            var pos = transform.position;
            pos.x = x;
            transform.position = pos;
        }
    }
}