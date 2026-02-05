using System;
using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Events;
using FlappyBird.Comps.Refs;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdActor : Actor
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        protected override void ExpandEntity(EcsEntity entity)
        {
            entity.Get<Bird>();
            entity.Get<Rigidbody2DRef>().Value = _rigidbody2D;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Entity.Get<CollideEvent>().Collision = other;
        }
    }
}