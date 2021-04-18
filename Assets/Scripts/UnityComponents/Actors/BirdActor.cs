using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdActor : Actor
    {
        public override void ExpandEntity(EcsEntity entity)
        {
            entity.Get<Bird>() = new Bird()
            {
                Transform = transform,
                Rigidbody2D = GetComponent<Rigidbody2D>()
            };
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!Entity.IsAlive()) return;
            Entity.Get<LoseEvent>();
        }
    }
}