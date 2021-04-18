using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class TubesSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RuntimeData _runtime;
        private StaticData _static;
        private SceneData _scene;

        public void Init()
        {
            float tubesXPosition = _static.TubesStartSpawnOffset;

            for (int i = 0; i < _static.TubesPoolSize; i++)
            {
                var tube = Object.Instantiate(_static.TubesPrefab);
                tube.transform.position = new Vector2(tubesXPosition, Random.Range(_static.MinYRandom, _static.MaxYRandom));
                tubesXPosition += _static.TubesSpawnDistance;

                _runtime.TubesPool.Enqueue(tube);
            }

            _runtime.TubesSpawnTrigger = _static.TubesSpawnDistance + _static.TubesStartSpawnOffset;
        }

        public void Run()
        {
            if (_scene.Bird.transform.position.x >= _runtime.TubesSpawnTrigger)
            {
                var tubeForMove = _runtime.TubesPool.Dequeue();
                float tubesXPosition = tubeForMove.transform.position.x + _static.TubesSpawnDistance * _static.TubesPoolSize;
                tubeForMove.transform.position = new Vector2(tubesXPosition, Random.Range(_static.MinYRandom, _static.MaxYRandom));

                _runtime.TubesPool.Enqueue(tubeForMove);
                _runtime.TubesSpawnTrigger += _static.TubesSpawnDistance;
            }
        }
    }
}