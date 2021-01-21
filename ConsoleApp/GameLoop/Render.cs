using System;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the game is rendered.
    /// </summary>
    public class Render
    {
        // Array of gameobjects.
        private readonly GameObject[] gameObjects = { new Board() };

        /// <summary>
        /// Render the game.
        /// </summary>
        public void RenderGame()
        {
            gameObjects[0].Render();
            //Console.WriteLine("Game drawn");
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public Render()
        {
        }
    }
}
