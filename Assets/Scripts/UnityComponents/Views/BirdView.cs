using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdView : View
    {
        protected override void ExpandEntity(EcsEntity entity)
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

            if (collision.TryGetComponent(out ScoreZoneView scoreZone))
                World.NewEntity().Get<ScoreCountEvent>();
            else
                Entity.Get<LoseEvent>();
        }
    }
}