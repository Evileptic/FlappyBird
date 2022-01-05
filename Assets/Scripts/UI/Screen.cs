using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class Screen : MonoBehaviour
    {
        protected EcsWorld World;

        public void InjectWorld(EcsWorld world) => World = world;

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}