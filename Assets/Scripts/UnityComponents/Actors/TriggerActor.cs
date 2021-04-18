using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public abstract class TriggerActor : Actor
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!Entity.IsAlive() || Entity.Has<TriggerEvent>()) return;
            Entity.Get<TriggerEvent>() = new TriggerEvent()
            {
                Collider = other,
                EventType = TriggerEventType.ENTER
            };
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (!Entity.IsAlive() || Entity.Has<TriggerEvent>()) return;
            Entity.Get<TriggerEvent>() = new TriggerEvent()
            {
                Collider = other,
                EventType = TriggerEventType.STAY
            };
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (!Entity.IsAlive() || Entity.Has<TriggerEvent>()) return;
            Entity.Get<TriggerEvent>() = new TriggerEvent()
            {
                Collider = other,
                EventType = TriggerEventType.EXIT
            };
        }
    }
}