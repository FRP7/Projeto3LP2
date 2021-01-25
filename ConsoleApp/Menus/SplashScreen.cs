using System;
using System.Threading;

namespace ConsoleApp
{
    /// <summary>
    /// Class of the splashscreen.
    /// </summary>
    public class SplashScreen
    {
        /// <summary>
        /// Play the splashscreen.
        /// </summary>
        public void PlaySplashScreen()
        {
            bool retry;
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
                    "\\________/  \\________/   /_____( \n");

                // While the player doesn't click.
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("\t\t\t\t\t\tPress ENTER to continue.");
                    Thread.Sleep(250);

                    // Set cursor in the line before.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Delete the line before.
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    Console.WriteLine("\t\t\t\t\t\tPress       to continue.");
                    Thread.Sleep(250);

                    // Set cursor in the line before.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                }

                // The player's choice.
                ConsoleKey key = Console.ReadKey(true).Key;

                retry = key != ConsoleKey.Enter;
            }
            while (retry);
        }
    }
}
