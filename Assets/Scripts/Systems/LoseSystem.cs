using FlappyBird.Comps.Actors;
using FlappyBird.Comps.Events;
using FlappyBird.Comps.Flags;
using FlappyBird.Comps.Refs;
using FlappyBird.Data;
using FlappyBird.SO;
using FlappyBird.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class LoseSystem : IEcsRunSystem
    {
        private EcsFilter<Bird, Rigidbody2DRef, LoseEvent> _loseEventFilter;

        private RuntimeData _runtimeData;
        private GameConfig _gameConfig;
        private SceneData _sceneData;
        private GameWindow _gameWindow;

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

                var birdRigidBody = _loseEventFilter.Get2(index).Value;
                birdRigidBody.linearVelocity = new Vector2(0f, birdRigidBody.linearVelocity.y);

                var audioSource = _sceneData.AudioSource;
                audioSource.PlayOneShot(_gameConfig.Death);
                audioSource.PlayOneShot(_gameConfig.Hit);

                _gameWindow.GameScreen.Hide();
                _gameWindow.LoseScreen.Show();
            }
        }
    }
}