using Leopotam.Ecs;

namespace FlappyBird
{
    public class LoseSystem : IEcsRunSystem
    {
        private EcsFilter<LoseEvent> _eventFilter;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {

                _eventFilter.GetEntity(index).Destroy();
            }
        }
    }
}