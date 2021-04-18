using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class Screen : MonoBehaviour
    {
        public EcsWorld World;

        public void InjectWorld(EcsWorld world) => World = world;

        public virtual void Show() => gameObject.SetActive(true);

        public virtual void Hide() => gameObject.SetActive(false);
    }
}