using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class TubesSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Init()
        {
            float tubesXPosition = _staticData.TubesStartSpawnOffset;

            for (int i = 0; i < _staticData.TubesPoolSize; i++)
            {
                var tube = Object.Instantiate(_staticData.TubesPrefab);
                tube.transform.position = new Vector2(tubesXPosition,
                    Random.Range(_staticData.TubesMinYRandom, _staticData.TubesMaxYRandom));
                tubesXPosition += _staticData.TubesSpawnDistance;

                _runtimeData.TubesPool.Enqueue(tube);
            }

            _runtimeData.TubesSpawnTrigger = _staticData.TubesSpawnDistance + _staticData.TubesStartSpawnOffset;
        }

        public void Run()
        {
            if (_sceneData.BirdView.transform.position.x >= _runtimeData.TubesSpawnTrigger)
            {
                var tubeForMove = _runtimeData.TubesPool.Dequeue();
                float tubesXPosition = tubeForMove.transform.position.x +
                                       _staticData.TubesSpawnDistance * _staticData.TubesPoolSize;
                tubeForMove.transform.position = new Vector2(tubesXPosition,
                    Random.Range(_staticData.TubesMinYRandom, _staticData.TubesMaxYRandom));

                _runtimeData.TubesPool.Enqueue(tubeForMove);
                _runtimeData.TubesSpawnTrigger += _staticData.TubesSpawnDistance;
            }
        }
    }
}