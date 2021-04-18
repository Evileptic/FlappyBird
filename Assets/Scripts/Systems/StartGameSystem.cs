using Leopotam.Ecs;

namespace FlappyBird
{
    public class StartGameSystem : IEcsRunSystem
    {
        private EcsFilter<StartGameEvent> _eventFilter;
        private EcsFilter<Bird> _birdFilter;

        private RuntimeData _runtime;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                foreach (var idx in _birdFilter)
                {
                    ref var bird = ref _birdFilter.Get1(idx);
                    bird.Rigidbody2D.isKinematic = false;

                    var birdEntity = _birdFilter.GetEntity(idx);
                    birdEntity.Get<JumpEvent>();
                    birdEntity.Get<MoveFlag>();
                    birdEntity.Get<RotationFlag>();

                    _ui.GameScreen.Show();

                    _runtime.GameState = GameState.Play;
                }

                _eventFilter.GetEntity(index).Destroy();
            }
        }
    }
}