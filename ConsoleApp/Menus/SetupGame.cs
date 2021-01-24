using System;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the player chooses his color.
    /// </summary>
    public class SetupGame
    {
        // Checks whether the player is white.
        private bool isPlayerWhite;

        /// <summary>
        /// Set the game.
        /// </summary>
        public void SetGame()
        {
            isPlayerWhite = PickColor();
            GameLoop gameLoop = new GameLoop(isPlayerWhite);
            Console.Clear();
            gameLoop.Game();
        }

        /// <summary>
        /// Choose a color.
        /// </summary>
        /// <returns> Checks whether the white color was chosen. </returns>
        private bool PickColor()
        {
            ConsoleKey key = ConsoleKey.Backspace;
            bool isDone = false;

            while (!isDone)
            {
                Console.WriteLine("\n\tChoose your color: ");
                Console.WriteLine("\tW = white,  B = black.");
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.W | key == ConsoleKey.B)
                    isDone = true;
            }

            if (key == ConsoleKey.W) return true;
            else return false;
        }
    }
}
