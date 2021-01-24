using System;

namespace ConsoleApp
{
    /// <summary>
    /// Class where is read the user input. 
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Gets and sets the piece chosen by the player.
        /// </summary>
        public static int Piece
        {
            get => piece;
            set => piece = value;
        }

        /// <summary>
        /// Gets and sets the slot chosen by the player.
        /// </summary>
        public static int Slot
        {
            get => slot;
            set => slot = value;
        }

        // The piece chosen by the player.
        private static int piece;

        // The slot chosen by the player.
        private static int slot;

        /// <summary>
        /// Check the player's input.
        /// </summary>
        public void CheckUserInput()
        {
            // The user input.
            string userInput;

            // If the the first input is valid.
            bool isInput1 = false;

            // If the second input is valid. 
            bool isInput2 = false;

            // Check the player's input.
            if (Console.KeyAvailable)
            {
                // Check the first input.
                Console.SetCursorPosition(0, 22);
                while (!isInput1)
                {
                    userInput = Console.ReadLine();

                    if(Int32.TryParse(userInput, out piece))
                    {
                        if (piece <= 12)
                        {
                            isInput1 = true;
                        }
                    }
                }

                // Check the second input.
                while (!isInput2)
                {
                    userInput = Console.ReadLine();

                    if (Int32.TryParse(userInput, out slot))
                    {
                        if (piece <= 12)
                        {
                            isInput2 = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public UserInput()
        {
            piece = -1;
            slot = -1;
        }
    }
}
