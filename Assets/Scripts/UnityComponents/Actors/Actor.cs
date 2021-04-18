using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace FlappyBird
{
    public abstract class Actor : MonoBehaviour
    {
        public EcsEntity Entity;

        protected EcsWorld World;

        public void Init(EcsWorld world)
        {
            World = world;
            Entity = World.NewEntity();
            ExpandEntity(Entity);
        }

        public abstract void ExpandEntity(EcsEntity entity);

        public void SelfDestroy(float delay = 0f) => StartCoroutine(SelfDestroyCoroutine(delay));

        public IEnumerator SelfDestroyCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Entity.Destroy();
            Destroy(gameObject);
        }
    }
}