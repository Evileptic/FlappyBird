using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public abstract class View : MonoBehaviour
    {
        public EcsEntity Entity;
        protected EcsWorld World;

        public void Init(EcsWorld world)
        {
            World = world;
            Entity = World.NewEntity();
            ExpandEntity(Entity);
        }

        protected abstract void ExpandEntity(EcsEntity entity);
    }
}