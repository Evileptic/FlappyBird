using Leopotam.Ecs;

namespace FlappyBird
{
    public class StartGameSystem : IEcsRunSystem
    {
        private EcsFilter<StartGameEvent> _startGameEventFilter;

        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _startGameEventFilter)
            {
                var birdEntity = _sceneData.BirdView.Entity;
                birdEntity.Get<JumpEvent>();
                birdEntity.Get<MoveFlag>();
                birdEntity.Get<RotationFlag>();
                _sceneData.BirdView.Entity.Get<Bird>().Rigidbody2D.isKinematic = false;
                _ui.GameScreen.Show();
                _runtimeData.GameState = GameState.Play;

                _startGameEventFilter.GetEntity(index).Destroy();
            }
        }
    }
}