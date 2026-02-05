using FlappyBird.Comps.Events;
using FlappyBird.Comps.Flags;
using FlappyBird.Comps.Refs;
using FlappyBird.Data;
using FlappyBird.UI;
using Leopotam.Ecs;
using UnityEngine;

namespace FlappyBird.Systems
{
    public class StartGameSystem : IEcsInitSystem
    {
        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        private GameWindow _gameWindow;

        public void Init()
        {
            _gameWindow.MenuScreen.StartGameButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            // The bird entity can be fetched via a scene data reference (not via an ECS filter)
            var birdEntity = _sceneData.BirdActor.GetEntity;
            birdEntity.Get<JumpEvent>();
            birdEntity.Get<MoveFlag>();
            birdEntity.Get<RotationFlag>();
            birdEntity.Get<Rigidbody2DRef>().Value.bodyType = RigidbodyType2D.Dynamic;
            
            _gameWindow.MenuScreen.Hide();
            _gameWindow.GameScreen.Show();
            _runtimeData.GameState = GameState.Play;
        }
    }
}