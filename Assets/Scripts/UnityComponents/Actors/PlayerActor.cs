using Leopotam.Ecs;

namespace FlappyBird
{
    public class PlayerActor : Actor
    {
        public override void ExpandEntity(EcsEntity entity)
        {
            entity.Get<Player>().ActorRef = this;
        }
    }
}