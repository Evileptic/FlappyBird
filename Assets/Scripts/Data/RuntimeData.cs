using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public enum GameState { Menu, Play, Lose }

    [Serializable]
    public class RuntimeData
    {
        public GameState GameState;
        public Camera MainCamera;

        public Queue<GameObject> GroundPool = new Queue<GameObject>();
        public Queue<GameObject> TubesPool = new Queue<GameObject>();
        public float GroundWidth;
        public float GroundSpawnTrigger;
        public float TubesSpawnTrigger;

        public int Scores;
    }
}