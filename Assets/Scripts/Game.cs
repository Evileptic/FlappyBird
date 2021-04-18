using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(SceneData))]
    sealed class Game : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;
        EcsSystems _fixedSystems;

        public StaticData _static;
        public SceneData _scene;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedSystems);
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

                .Add(new LoseSystem())

                .Inject(_audioPlayer)
                .Inject(_runtime)
                .Inject(_static)
                .Inject(_scene)
                .Inject(_ui)
                .Init();

            _fixedSystems
                .Add(new BirdTriggerSystem())
                .Init();
        }

        void Update() => _systems?.Run();
        void FixedUpdate() => _fixedSystems?.Run();

        void OnDestroy()
        {
            if (_fixedSystems != null)
            {
                _fixedSystems.Destroy();
                _fixedSystems = null;
            }

            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }

            _world.Destroy();
            _world = null;
        }
    }
}