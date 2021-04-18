using UnityEngine;

namespace FlappyBird
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Prefabs")]
        public AudioPlayer AudioPlayerPrefab;
        public UI UIPrefab;
    }
}