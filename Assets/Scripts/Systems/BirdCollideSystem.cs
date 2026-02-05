using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Events;
using FlappyBird.Comps.Flags;
using FlappyBird.Data;
using Leopotam.Ecs;

namespace FlappyBird.Systems
{
    public class BirdCollideSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, CollideEvent>.Exclude<DeadFlag> _birdCollideFilter;

        private EcsWorld _ecsWorld;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (var eventIndex in _birdCollideFilter)
            {
                var collision = _birdCollideFilter.Get2(eventIndex).Collision;
                
                if (collision.TryGetComponent<ScoreZoneView>(out _))
                    _ecsWorld.NewEntity().Get<ScoreCountEvent>();
                else
                    _sceneData.BirdActor.GetEntity.Get<LoseEvent>();
            }
        }
    }
}