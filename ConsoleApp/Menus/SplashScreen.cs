using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

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
                // Enquanto o jogador não clicar
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("\t\t\t\t\t\tPress ENTER to continue.");
                    Thread.Sleep(250);
                    // Posicionar o cursor na linha anterior
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    Console.WriteLine("\t\t\t\t\t\tPress       to continue.");
                    Thread.Sleep(250);
                    // Posicionar o cursor na linha anterior
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                }
                // Variável que contem a opção do jogador
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter) retry = false;
                else retry = true;
            }
            while (retry == true);
        }
    }
}
