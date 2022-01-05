using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class BirdJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, JumpEvent> _jumpEventFilter;
        
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var index in _jumpEventFilter)
            {
                ref var birdComp = ref _jumpEventFilter.Get1(index);

                birdComp.Rigidbody2D.velocity = new Vector2(birdComp.Rigidbody2D.velocity.x, 0f);
                birdComp.Rigidbody2D.AddForce(Vector2.up * _staticData.BirdJumpForce, _staticData.BirdJumpForceType);
                birdComp.Transform.rotation = Quaternion.Euler(0f, 0f, _staticData.BirdMaxRotation);

                _sceneData.AudioSource.PlayOneShot(_staticData.Jump);

                _jumpEventFilter.GetEntity(index).Del<JumpEvent>();
            }
        }
    }
}