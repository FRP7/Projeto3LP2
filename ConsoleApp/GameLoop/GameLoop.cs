using System;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the game loop happens.
    /// </summary>
    public class GameLoop
    {
        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        public static bool IsGameOver { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is won.
        /// </summary>
        public static bool IsGameWon { get; set; }

        // Access Update class.
        private Update update;

        // Access Render class.
        private Render render;

        // Access UserInput class.
        private UserInput userInput;

        // Access GameOver class.
        private GameOver gameOver;

        // Access GameWon class.
        private GameWon gameWon;

        // Array of gameobjects.
        private readonly GameObject[] gameObjects = { new Board() };

        /// <summary>
        /// The game loop.
        /// </summary>
        public void Game()
        {
            Start();
            Update();
        }

        /// <summary>
        /// First frame of the game (similar to Unity).
        /// </summary>
        private void Start()
        {
            update = new Update();
            render = new Render();
            userInput = new UserInput();
            gameOver = new GameOver();
            gameWon = new GameWon();

            gameObjects[0].Start();

            Console.WriteLine("Game initialized.");
        }

        /// <summary>
        /// Update each frame while the game isn't over (similar do Unity).
        /// </summary>
        private void Update()
        {
            while(!IsGameOver | !IsGameWon)
            {
                userInput.CheckUserInput();
                update.UpdateGame();
                render.RenderGame();
            }

            // If the player loses.
            if(IsGameOver)
            {
                gameOver.GameOverMenu();
            }

            // If the player wins.
            if(IsGameWon)
            {
                gameWon.GameWonMenu();
            }
        }
    }
}
