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
        public float BirdRotationSpeed;

        [Header("Camera Props")]
        public float CameraXOffset;

        [Header("Ground Props")]
        public int GroundPoolSize = 3;

        [Header("Tubes Props")]
        public int TubesPoolSize = 3;
        public float TubesSpawnDistance;
        public float TubesStartSpawnOffset;
        public float TubesMaxYRandom;
        public float TubesMinYRandom;

        [Header("Prefabs")]
        public AudioPlayer AudioPlayerPrefab;
        public GameObject GroundPrefab;
        public GameObject TubesPrefab;
        public UI UIPrefab;

        [Header("Audio Clips")]
        public AudioClip Death;
        public AudioClip Score;
        public AudioClip Jump;
        public AudioClip Hit;
    }
}