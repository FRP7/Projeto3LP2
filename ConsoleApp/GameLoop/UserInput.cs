using System;

namespace ConsoleApp
{
    /// <summary>
    /// Class where is read the user input.
    /// </summary>
    public class UserInput
    {
        /// <summary>
        /// Gets or sets the piece chosen by the player.
        /// </summary>
        public static int Piece { get; set; }

        /// <summary>
        /// Gets or sets the slot chosen by the player.
        /// </summary>
        public static int Slot { get; set; }

        /// <summary>
        /// Check the player's input.
        /// </summary>
        public void CheckUserInput()
        {
            int piece;
            int slot;

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

                    if (int.TryParse(userInput, out piece) && piece <= 12)
                    {
                        isInput1 = true;
                        Piece = piece;
                    }
                }

                // Check the second input.
                while (!isInput2)
                {
                    userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out slot) && slot <= 12)
                    {
                        isInput2 = true;
                        Slot = slot;
                    }
                }
            }
        }
    }
}
