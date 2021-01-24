using System;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the game result is shown.
    /// </summary>
    public class GameResult
    {
        /// <summary>
        /// Show the game's result.
        /// </summary>
        /// <param name="hasPlayerWon"> Check whether the player has won.
        /// </param>
        public void ShowGameResult(bool hasPlayerWon)
        {
            SetupGame setupGame = new SetupGame();
            Menu menu = new Menu();
            bool retry = false;
            ConsoleKey key;

            Console.Clear();
            if (hasPlayerWon)
                Console.WriteLine("\n\tThe player won!");
            else
                Console.WriteLine("\n\tThe opponent won!");

            Console.WriteLine("\n\n\n\t(M)ENU");
            Console.WriteLine("\n\t(R)ETRY");
            Console.WriteLine("\n\t(E)XIT");
            do
            {
                // The player's choice.
                key = Console.ReadKey(true).Key;

                // Check which option is chosen.
                switch (key)
                {
                    case ConsoleKey.M:
                        Console.Clear();
                        menu.MainMenu();
                        break;
                    case ConsoleKey.R:
                        Console.Clear();

                        // Enter the game.
                        setupGame.SetGame();
                        break;
                    case ConsoleKey.E:
                        Exit();
                        break;
                    default:
                        retry = true;
                        break;
                }
            } while (retry);
        }

        /// <summary>
        /// Exit game.
        /// </summary>
        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
