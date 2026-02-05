using FlappyBird.Comps.Events;
using FlappyBird.Systems;
using FlappyBird.Data;
using FlappyBird.SO;
using FlappyBird.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(SceneData))]
    sealed class GameController : MonoBehaviour
    {
        private EcsWorld _ecsWorld;
        private EcsSystems _systems;

        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private GameWindow _gameWindow;
        
        private readonly RuntimeData _runtimeData = new();

        void Start()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_ecsWorld);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
    
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
                .Add(new BirdCollideSystem())
                .Add(new ScoreCountSystem())
                .Add(new LoseSystem())
                .Add(new RestartGameSystem())
                
                .OneFrame<JumpEvent>()
                .OneFrame<CollideEvent>()
                .OneFrame<ScoreCountEvent>()
                .OneFrame<LoseEvent>()
                
                .Inject(_runtimeData)
                .Inject(_gameConfig)
                .Inject(_sceneData)
                .Inject(_gameWindow)
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

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