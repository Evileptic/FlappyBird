using Leopotam.Ecs;

namespace FlappyBird
{
    public class StartGameSystem : IEcsRunSystem
    {
        private EcsFilter<StartGameEvent> _eventFilter;
        private EcsFilter<Bird> _birdFilter;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                foreach (var idx in _birdFilter)
                {
                    var birdEntity = _birdFilter.GetEntity(idx);
                    birdEntity.Get<MoveFlag>();
                    birdEntity.Get<RotationFlag>();
                }

                _eventFilter.GetEntity(index).Destroy();
            }
        }
    }
}