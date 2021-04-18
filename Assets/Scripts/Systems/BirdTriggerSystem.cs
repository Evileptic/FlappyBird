using Leopotam.Ecs;

namespace FlappyBird
{
    public class BirdTriggerSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, TriggerEvent> _triggerFilter;

        public void Run()
        {
            foreach (var index in _triggerFilter)
            {
                ref var trigger = ref _triggerFilter.Get2(index);
                var collider = trigger.Collider;

                switch (trigger.EventType)
                {
                    case TriggerEventType.Enter:

                        break;
                    case TriggerEventType.Stay:

                        break;
                    case TriggerEventType.Exit:

                        break;
                }
                _triggerFilter.GetEntity(index).Del<TriggerEvent>();
            }
        }
    }
}