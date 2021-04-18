using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(SceneData))]
    sealed class Game : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public StaticData _static;
        public SceneData _scene;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            var _runtime = new RuntimeData();

            if (_scene == null)
                _scene = GetComponent<SceneData>();

            UI _ui = Instantiate(_static.UIPrefab);
            AudioPlayer _audioPlayer = Instantiate(_static.AudioPlayerPrefab);

            _systems
                .Add(new InitializeSystem())

                .Add(new InputSystem())
                .Add(new StartGameSystem())

                .Add(new BirdMoveSystem())
                .Add(new BirdJumpSystem())
                .Add(new BirdRotationSystem())

                .Add(new CameraFollowSystem())

                .Add(new GroundSpawnSystem())
                .Add(new TubesSpawnSystem())

                .Add(new ScoreCountSystem())
                .Add(new LoseSystem())

                .Inject(_audioPlayer)
                .Inject(_runtime)
                .Inject(_static)
                .Inject(_scene)
                .Inject(_ui)
                .Init();
        }

        void Update() => _systems?.Run();

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}