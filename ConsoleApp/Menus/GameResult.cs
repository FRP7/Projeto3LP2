using System;

namespace ConsoleApp
{
    public class GameResult
    {
        private SetupGame setupGame;
        private Menu menu;

        bool retry = false;
        ConsoleKey key = ConsoleKey.Backspace;

        // TRUE = ganhou o jogador  FALSE = ganhou o oponente
        public void ShowGameResult(bool hasPlayerWon)
        {
            setupGame = new SetupGame();
            menu = new Menu();

            Console.Clear();
            if (hasPlayerWon)
                Console.WriteLine("\n\tThe player won!");
            else if (!hasPlayerWon)
                Console.WriteLine("\n\tThe opponent won!");

            Console.WriteLine("\n\n\n\t(M)ENU");
            Console.WriteLine("\n\t(R)ETRY");
            Console.WriteLine("\n\t(E)XIT");
            do
            {
                // Variável que contem a opção do jogador
                key = Console.ReadKey(true).Key;
                // Switch para verificar qual opção foi escolhida
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
            } while (retry == true);
        }

        /// <summary>
        /// Sair do jogo.
        /// </summary>
        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
