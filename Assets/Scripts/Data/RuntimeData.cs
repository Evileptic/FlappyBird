namespace FlappyBird
{
    public enum GameState { Play, Lose }

    public class RuntimeData
    {
        public GameState GameState;
        public AudioPlayer AudioPlayer;
    }
}