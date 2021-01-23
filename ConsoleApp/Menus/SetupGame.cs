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
            string userInput = "";
            bool isDone = false;

            while(!isDone)
            {
                Console.WriteLine("Choose a color: ");
                Console.WriteLine("W = white,  B = black.");
                userInput = Console.ReadLine().ToUpper();
                if (userInput == "W" | userInput == "B")
                {
                    isDone = true;
                }
            }

            if(userInput == "W")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
