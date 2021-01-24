using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// Main menu class.
    /// </summary>
    public class Menu
    {
        // Enter the game.
        private SetupGame setupGame;
        private Intro intro;
        private SplashScreen splash;

        /// <summary>
        /// Método onde é exposto o menu principal.
        /// </summary>
        public void MainMenu()
        {
            bool retry = false;
            ConsoleKey key = ConsoleKey.Backspace;

            intro.PlayIntro();

            splash.PlaySplashScreen();

            // Mostrar o menu principal
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
                // Variável que contem a opção do jogador
                key = Console.ReadKey(true).Key;
                // Switch para verificar qual opção foi escolhida
                switch (key)
                {
                    case ConsoleKey.P:
                        Console.Clear();
                        // Enter the game.
                        setupGame.SetGame();
                        break;
                    case ConsoleKey.I:
                        Instructions(key, retry);
                        retry = true;
                        break;
                    case ConsoleKey.C:
                        Credits(key, retry);
                        retry = true;
                        break;
                    case ConsoleKey.E:
                        Exit();
                        break;
                    default:
                        retry = true;
                        break;
                }
            } while (retry == true);
        }

        /// <summary>
        /// Páginas das instruções.
        /// </summary>
        /// <param name="key"> Input do jogador. </param>
        /// <param name="retry"> Indicar se pode voltar atrás. </param>
        private void Instructions(ConsoleKey key, bool retry)
        {
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
                // Enquanto o jogador não clicar
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("\tPress ESQ to retreat to the menu.");
                    Thread.Sleep(250);
                    // Posicionar o cursor na linha anterior
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    Console.WriteLine("\tPress     to retreat to the menu.");
                    Thread.Sleep(250);
                    // Posicionar o cursor na linha anterior
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                }
                // Variável que contem a opção do jogador
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape) retry = false;
                else retry = true;
            }
            while (retry == true);
        }

        /// <summary>
        /// Página dos créditos.
        /// </summary>
        /// <param name="key"> Input do jogador. </param>
        /// <param name="retry"> Indicar se pode voltar atrás. </param>
        private void Credits(ConsoleKey key, bool retry)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("\n\t       Made with love by:\n\n");
                Console.WriteLine("\t\tFrancisco Pires;\n");
                Console.WriteLine("\t\tNuno Figueiredo.\n\n");
                // Enquanto o jogador não clicar
                while (!Console.KeyAvailable)
                {
                    Console.WriteLine("\tPress ESQ to retreat to the menu.");
                    Thread.Sleep(250);
                    // Posicionar o cursor na linha anterior
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    Console.WriteLine("\tPress     to retreat to the menu.");
                    Thread.Sleep(250);
                    // Posicionar o cursor na linha anterior
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Apagar a linha anterior
                    Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b" +
                        "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                }
                // Variável que contem a opção do jogador
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape) retry = false;
                else retry = true;
            }
            while (retry == true);
        }

        /// <summary>
        /// Sair do jogo.
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
