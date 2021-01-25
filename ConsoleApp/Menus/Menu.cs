using System;
using System.Threading;

namespace ConsoleApp
{
    /// <summary>
    /// Main menu class.
    /// </summary>
    public class Menu
    {
        // Enter the game.
        private readonly SetupGame setupGame;
        private readonly Intro intro;
        private readonly SplashScreen splash;

        /// <summary>
        /// Method where the main menu is played.
        /// </summary>
        public void MainMenu()
        {
            bool retry = false;
            ConsoleKey key;
            intro.PlayIntro();

            splash.PlaySplashScreen();

            // Show the main menu.
            do
            {
                Console.Clear();

                Console.WriteLine("\n\t\t\t         _________    _____   " +
                    "_____       _____        _____  ");
                Console.WriteLine("\t\t\t        (_   _____)  / ___/  " +
                    "(_   _)     (_   _)      (_   _) ");
                Console.WriteLine("\t\t\t          ) (___    ( (__      " +
                    "| |         | |          | |   ");
                Console.WriteLine("\t\t\t         (   ___)    ) __)     " +
                    "| |         | |          | |   ");
                Console.WriteLine("\t\t\t          ) (       ( (        " +
                    "| |   __    | |   __     | |   ");
                Console.WriteLine("\t\t\t         (   )       \\ \\___  __| " +
                    "|___) ) __| |___) )   _| |__ ");
                Console.WriteLine("\t\t\t          \\_/         \\____\\ " +
                    "\\________/  \\________/   /_____( ");

                Console.WriteLine("\n\n\t\t\t\t\t\t       (P)LAY");
                Console.WriteLine("\n\t\t\t\t\t\t    (I)NSTRUTIONS");
                Console.WriteLine("\n\t\t\t\t\t\t      (C)REDITS");
                Console.WriteLine("\n\t\t\t\t\t\t       (E)XIT");

                // The player's choice.
                key = Console.ReadKey(true).Key;

                // Check which option is chose.
                switch (key)
                {
                    case ConsoleKey.P:
                        Console.Clear();

                        // Enter the game.
                        setupGame.SetGame();
                        break;
                    case ConsoleKey.I:
                        Instructions();
                        retry = true;
                        break;
                    case ConsoleKey.C:
                        Credits();
                        retry = true;
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
        ///  Instructions page.
        /// </summary>
        private void Instructions()
        {
            bool retry;
            ConsoleKey key;
            do
            {
                Console.Clear();

                Console.WriteLine("\n\tThis is a game for two players.");
                Console.WriteLine("\tEach player has to pick one color, white or black.");
                Console.WriteLine("\tEach player has six pieces on their side of the board.");
                Console.WriteLine("\tEach player can only move one piece per turn.");
                Console.WriteLine("\tPieces may only move according to the board lines.");
                Console.WriteLine("\tPieces can move to an empty spot.");
                Console.WriteLine("\tPieces can capture one enemy piece if they jump across, landing on an empty spot.");
                Console.WriteLine("\tThe game ends when one color has no pieces on the board.");
                Console.WriteLine("\tGood Luck!\n");

                // While the player doesn't click.
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("\tPress ESQ to retreat to the menu.");
                    Thread.Sleep(250);

                    // Set cursor in the line before.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Delete the line before.
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    Console.WriteLine("\tPress     to retreat to the menu.");
                    Thread.Sleep(250);

                    // Set cursor in the line before.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Delete the line before.
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                }

                // The player's choice.
                key = Console.ReadKey(true).Key;

                retry = key != ConsoleKey.Escape;
            }
            while (retry);
        }

        /// <summary>
        /// Página dos créditos.
        /// </summary>
        private void Credits()
        {
            ConsoleKey key;
            bool retry;
            do
            {
                Console.Clear();

                Console.WriteLine("\n\t       Made with love by:\n\n");
                Console.WriteLine("\t\tFrancisco Pires;\n");
                Console.WriteLine("\t\tNuno Figueiredo.\n\n");

                // While the player doesn't click.
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("\tPress ESQ to retreat to the menu.");
                    Thread.Sleep(250);

                    // Set the cursor in the line before.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Delete the line before.
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    Console.WriteLine("\tPress     to retreat to the menu.");
                    Thread.Sleep(250);

                    // Set the cursor in the line before.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Delete the line before.
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                }

                // The player's choice.
                key = Console.ReadKey(true).Key;

                retry = key != ConsoleKey.Escape;
            }
            while (retry);
        }

        /// <summary>
        /// Exit game.
        /// </summary>
        private void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public Menu()
        {
            setupGame = new SetupGame();
            intro = new Intro();
            splash = new SplashScreen();
        }
    }
}
