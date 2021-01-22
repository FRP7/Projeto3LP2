using System;

namespace ConsoleApp
{
    public class GameResult
    {
        // TRUE = ganhou o jogador  FALSE = ganhou o oponente
        public void ShowGameResult(bool hasPlayerWon)
        {
            Console.Clear();
            if(hasPlayerWon)
            {
                Console.WriteLine("Ganhou o jogador");
            }
            else if(!hasPlayerWon)
            {
                Console.WriteLine("Ganhou o oponente");
            }
        }
    }
}
