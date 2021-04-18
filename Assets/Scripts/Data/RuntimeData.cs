using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public enum GameState { Menu, Play, Lose }

    public class RuntimeData
    {
        public GameState GameState;
        public AudioPlayer AudioPlayer;
        public Camera MainCamera;

        public Queue<GameObject> GroundPool = new Queue<GameObject>();
        public float GroundWidth;
        public float GroundSpawnTrigger;
    }
}