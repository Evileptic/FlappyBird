using UnityEngine;

namespace FlappyBird
{
    public enum TriggerEventType { Enter, Stay, Exit }

    public struct TriggerEvent
    {
        public Collider Collider;
        public TriggerEventType EventType;
    }
}