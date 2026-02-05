using FlappyBird.Comps.Refs;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public abstract class Actor : MonoBehaviour
    {
        protected EcsEntity Entity;
        protected EcsWorld World;

        public ref EcsEntity GetEntity => ref Entity;
        
        public void Init(EcsWorld world)
        {
            World = world;
            Entity = World.NewEntity();
            Entity.Get<TransformRef>().Value = transform;
            ExpandEntity(Entity);
        }

        protected abstract void ExpandEntity(EcsEntity entity);
    }
}