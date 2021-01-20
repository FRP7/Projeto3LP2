using System;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the logic of the game is updated.
    /// </summary>
    public class Update
    {
        // Array of gameobjects.
        private readonly GameObject[] gameObjects = { new Board() };

        /// <summary>
        /// Update the logic of the game.
        /// </summary>
        public void UpdateGame()
        {
            gameObjects[0].Update();
            Console.WriteLine("Game updated");
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public Update()
        {
        }
    }
}
