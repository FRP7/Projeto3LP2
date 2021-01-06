using System;
using Common;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            GameState gameState = new GameState();
            Console.WriteLine(gameState.IsGameOver);
        }
    }
}
