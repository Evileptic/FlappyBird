using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird
{
    public class LoseSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, LoseEvent> _loseEventFilter;

        private RuntimeData _runtimeData;
        private StaticData _staticData;
        private SceneData _sceneData;
        private UI _ui;

        public void Run()
        {
            foreach (var index in _loseEventFilter)
            {
                if (_runtimeData.GameState != GameState.Play)
                {
                    _loseEventFilter.GetEntity(index).Del<LoseEvent>();
                    return;
                }

                _runtimeData.GameState = GameState.Lose;

                var birdEntity = _loseEventFilter.GetEntity(index);
                birdEntity.Del<MoveFlag>();

                var birdRigidBody = _loseEventFilter.Get1(index).Rigidbody2D;
                birdRigidBody.velocity = new Vector2(0f, birdRigidBody.velocity.y);

                var audioSource = _sceneData.AudioSource;
                audioSource.PlayOneShot(_staticData.Death);
                audioSource.PlayOneShot(_staticData.Hit);

                _ui.GameScreen.Hide();
                _ui.LoseScreen.Show();

                _loseEventFilter.GetEntity(index).Del<LoseEvent>();
            }
        }
    }
}