using UnityEngine;

namespace FlappyBird
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Bird Props")]
        public float BirdJumpForce;
        public ForceMode2D BirdJumpForceType;
        public float BirdMaxRotation;
        public float BirdMinRotation;
        public float BirdMoveSpeed;
        public float RotationSpeed;

        [Header("Camera Props")]
        public float CameraXOffset;

        [Header("Ground Props")]
        public int GroundPoolSize;

        [Header("Tubes Props")]
        public int TubesPoolSize;
        public float TubesSpawnDistance;
        public float TubesStartSpawnOffset;
        public float MaxYRandom;
        public float MinYRandom;

        [Header("Prefabs")]
        public AudioPlayer AudioPlayerPrefab;
        public UI UIPrefab;
        public GameObject GroundPrefab;
        public GameObject TubesPrefab;

        [Header("Audio Clips")]
        public AudioClip Jump;
        public AudioClip Death;
        public AudioClip Score;
        public AudioClip Hit;
    }
}