using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdActor : TriggerActor
    {
        public override void ExpandEntity(EcsEntity entity)
        {
            entity.Get<Bird>() = new Bird()
            {
                Transform = transform,
                Rigidbody2D = GetComponent<Rigidbody2D>()
            };
        }
    }
}