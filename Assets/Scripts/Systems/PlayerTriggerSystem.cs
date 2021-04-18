using Leopotam.Ecs;

namespace FlappyBird
{
    public class PlayerTriggerSystem : IEcsRunSystem
    {
        private EcsFilter<Player, TriggerEvent> _triggerFilter;

        public void Run()
        {
            foreach (var index in _triggerFilter)
            {
                ref var trigger = ref _triggerFilter.Get2(index);
                var collider = trigger.Collider;

                switch (trigger.EventType)
                {
                    case TriggerEventType.ENTER:

                        break;
                    case TriggerEventType.STAY:

                        break;
                    case TriggerEventType.EXIT:

                        break;
                }
                _triggerFilter.GetEntity(index).Del<TriggerEvent>();
            }
        }
    }
}