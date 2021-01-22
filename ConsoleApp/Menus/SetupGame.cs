using System;
using Common;

namespace ConsoleApp
{
    public class SetupGame
    {
        private bool isPlayerWhite;

        public void SetGame()
        {
            isPlayerWhite = PickColor();
            GameLoop gameLoop = new GameLoop(isPlayerWhite);
            Console.Clear();
            gameLoop.Game();
        }

        private bool PickColor()
        {
            string userInput = "";
            bool isDone = false;

            while(!isDone)
            {
                Console.WriteLine("Escolha uma cor: ");
                Console.WriteLine("W = branco,  B = preto.");
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
