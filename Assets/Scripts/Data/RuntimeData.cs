using UnityEngine;

namespace FlappyBird
{
    public enum GameState { Menu, Play, Lose }

    public class RuntimeData
    {
        public GameState GameState;
        public AudioPlayer AudioPlayer;
        public Camera MainCamera;
    }
}