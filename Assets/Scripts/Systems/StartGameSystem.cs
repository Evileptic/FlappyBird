using Leopotam.Ecs;

namespace FlappyBird
{
    public class StartGameSystem : IEcsRunSystem
    {
        private EcsFilter<StartGameEvent> _eventFilter;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {

                _eventFilter.GetEntity(index).Destroy();
            }
        }
    }
}