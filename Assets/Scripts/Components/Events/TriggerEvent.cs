using UnityEngine;

namespace FlappyBird
{
    public enum TriggerEventType { ENTER, STAY, EXIT }

    public struct TriggerEvent
    {
        public Collider Collider;
        public TriggerEventType EventType;
    }
}