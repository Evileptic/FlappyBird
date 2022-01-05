using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(SceneData))]
    sealed class Game : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _systems;

        [SerializeField] private StaticData _staticData;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private RuntimeData _runtimeData;

        void Start()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_ecsWorld);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _runtimeData = new RuntimeData();
            _sceneData = GetComponent<SceneData>();

            UI _ui = Instantiate(_staticData.UIPrefab);

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
                .Inject(_runtimeData)
                .Inject(_staticData)
                .Inject(_sceneData)
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
                _ecsWorld.Destroy();
                _ecsWorld = null;
            }
        }
    }
}