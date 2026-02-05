using FlappyBird.Monos.Views;
using UnityEngine;

namespace FlappyBird.SO
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Flappy Bird/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [Header("Bird")]
        public float BirdJumpForce;
        public ForceMode2D BirdJumpForceType;
        public float BirdMaxRotation;
        public float BirdMinRotation;
        public float BirdMoveSpeed;
        public float BirdRotationSpeed;

        [Header("Camera")]
        public float CameraXOffset;

        [Header("Ground")]
        public int GroundPoolSize = 3;

        [Header("Tubes")]
        public int TubesPoolSize = 3;
        public float TubesSpawnDistance;
        public float TubesStartSpawnOffset;
        public float TubesMaxYRandom;
        public float TubesMinYRandom;

        [Header("Prefabs")]
        public GroundView GroundPrefab;
        public GameObject TubesPrefab;

        [Header("Audio Clips")]
        public AudioClip Death;
        public AudioClip Score;
        public AudioClip Jump;
        public AudioClip Hit;
    }
}