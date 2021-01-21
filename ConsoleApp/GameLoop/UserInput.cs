using System;
using System.Collections.Generic;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where is read the user input. 
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Gets input from the player.
        /// </summary>
        public static int Piece
        {
            get => piece;
            set => piece = value;
        }

        public static int Slot
        {
            get => slot;
            set => slot = value;
        }

        private static int piece;
        private static int slot;

        /// <summary>
        /// Check the player's input.
        /// </summary>
        public void CheckUserInput()
        {
            string userInput;
            bool isInput1 = false;
            bool isInput2 = false;

            if (Console.KeyAvailable)
            {
                while (!isInput1)
                {
                    userInput = Console.ReadLine();

                    if(Int32.TryParse(userInput, out piece))
                    {
                        if(piece <= 12)
                        {
                            isInput1 = true;
                        }
                        else
                        {
                            Console.WriteLine("Número errado.");
                        }
                    }
                }

                while (!isInput2)
                {
                    userInput = Console.ReadLine();

                    if (Int32.TryParse(userInput, out slot))
                    {
                        if (piece <= 12)
                        {
                            isInput2 = true;
                        }
                        else
                        {
                            Console.WriteLine("Número errado.");
                        }
                    }
                }
            }
        }

        public UserInput()
        {
            piece = -1;
            slot = -1;
        }
    }
}
