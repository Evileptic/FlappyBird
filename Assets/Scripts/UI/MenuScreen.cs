﻿using UnityEngine.UI;

namespace FlappyBird
{
    public class MenuScreen : Screen
    {
        public Button StartGameButton;

        private void Start()
        {
            StartGameButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            Hide();
        }
    }
}