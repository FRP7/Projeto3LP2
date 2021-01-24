using System;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the game is rendered.
    /// </summary>
    public class Render
    {
        /// <summary>
        /// Gets and sets the board slot characters.
        /// </summary>
        public static char[] Slots
        {
            get => slots;
            set => slots = value;
        }

        // The board slot characters.
        private static char[] slots;

        private DoubleBuffer<char> db;

        /// <summary>
        /// Render the game.
        /// </summary>
        public void RenderGame()
        {
            PrintStatic();
            InitDoubleBuffer();
            db.Swap();
            PrintToScreen(db);
            db.Clear();
        }

        /// <summary>
        /// Initialize the double buffer.
        /// </summary>
        private void InitDoubleBuffer()
        {
            db = new DoubleBuffer<char>(22, 20);

            // First half of the board.
            for (int i = 1; i < 21; i++)
            {
                if (i == 2)
                {
                    db[i, 1] = slots[10];
                }
                else if (i > 2 && i < 11)
                {
                    db[i, 1] = '-';
                }
                else if (i == 11)
                {
                    db[i, 1] = slots[11];
                }
                else if (i > 11 && i < 20)
                {
                    db[i, 1] = '-';
                }
                else if (i == 20)
                {
                    db[i, 1] = slots[12];
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 3)
                {
                    db[i, 2] = '-';
                }
                else if (i == 11)
                {
                    db[i, 2] = '-';
                }
                else if (i == 19)
                {
                    db[i, 2] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 4)
                {
                    db[i, 3] = '-';
                }
                else if (i == 11)
                {
                    db[i, 3] = '-';
                }
                else if (i == 18)
                {
                    db[i, 3] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 5)
                {
                    db[i, 4] = '-';
                }
                else if (i == 17)
                {
                    db[i, 4] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 6)
                {
                    db[i, 5] = slots[9];
                }
                else if (i > 6 && i < 11)
                {
                    db[i, 5] = '-';
                }
                else if (i == 11)
                {
                    db[i, 5] = slots[8];
                }
                else if (i > 11 && i < 16)
                {
                    db[i, 5] = '-';
                }
                else if (i == 16)
                {
                    db[i, 5] = slots[7];
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 7)
                {
                    db[i, 6] = '-';
                }
                else if (i == 11)
                {
                    db[i, 6] = '-';
                }
                else if (i == 15)
                {
                    db[i, 6] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 8)
                {
                    db[i, 7] = '-';
                }
                else if (i == 11)
                {
                    db[i, 7] = '-';
                }
                else if (i == 14)
                {
                    db[i, 7] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 9)
                {
                    db[i, 8] = '-';
                }
                else if (i == 11)
                {
                    db[i, 8] = '-';
                }
                else if (i == 13)
                {
                    db[i, 8] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 10)
                {
                    db[i, 9] = '-';
                }
                else if (i == 11)
                {
                    db[i, 9] = '-';
                }
                else if (i == 12)
                {
                    db[i, 9] = '-';
                }
            }

            // Middle of the board.
            for (int i = 1; i < 21; i++)
            {
                if (i == 11)
                {
                    db[i, 10] = slots[6];
                }
            }

            // Second half of the board.
            for (int i = 1; i < 21; i++)
            {
                if (i == 10)
                {
                    db[i, 11] = '-';
                }
                else if (i == 11)
                {
                    db[i, 11] = '-';
                }
                else if (i == 12)
                {
                    db[i, 11] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 9)
                {
                    db[i, 12] = '-';
                }
                else if (i == 11)
                {
                    db[i, 12] = '-';
                }
                else if (i == 13)
                {
                    db[i, 12] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 8)
                {
                    db[i, 13] = '-';
                }
                else if (i == 11)
                {
                    db[i, 13] = '-';
                }
                else if (i == 14)
                {
                    db[i, 13] = '-';
                }
            }

            for (int i = 1; i < 20; i++)
            {
                if (i == 7)
                {
                    db[i, 14] = '-';
                }
                else if (i == 15)
                {
                    db[i, 14] = '-';
                }
            }

            for (int i = 1; i < 20; i++)
            {
                if (i == 6)
                {
                    db[i, 15] = slots[5];
                }
                else if (i > 6 && i < 11)
                {
                    db[i, 15] = '-';
                }
                else if (i == 11)
                {
                    db[i, 15] = slots[4];
                }
                else if (i > 11 && i < 16)
                {
                    db[i, 15] = '-';
                }
                else if (i == 16)
                {
                    db[i, 15] = slots[3];
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 5)
                {
                    db[i, 16] = '-';
                }
                else if (i == 11)
                {
                    db[i, 16] = '-';
                }
                else if (i == 17)
                {
                    db[i, 16] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 4)
                {
                    db[i, 17] = '-';
                }
                else if (i == 11)
                {
                    db[i, 17] = '-';
                }
                else if (i == 18)
                {
                    db[i, 17] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 3)
                {
                    db[i, 18] = '-';
                }
                else if (i == 11)
                {
                    db[i, 18] = '-';
                }
                else if (i == 19)
                {
                    db[i, 18] = '-';
                }
            }

            for (int i = 1; i < 21; i++)
            {
                if (i == 2)
                {
                    db[i, 19] = slots[0];
                }
                else if (i > 2 && i < 11)
                {
                    db[i, 19] = '-';
                }
                else if (i == 11)
                {
                    db[i, 19] = slots[1];
                }
                else if (i > 11 && i < 20)
                {
                    db[i, 19] = '-';
                }
                else if (i == 20)
                {
                    db[i, 19] = slots[2];
                }
            }
        }

        /// <summary>
        /// Print the board to the screen.
        /// </summary>
        /// <param name="db"></param>
        private void PrintToScreen(DoubleBuffer<char> db)
        {

            // Draw the board.
            for (int y = 0; y < db.YDim; y++)
            {
                for (int x = 0; x < db.XDim; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (db[x, y] != default)
                    {
                        Console.Write(db[x, y]);
                    }
                }
                Console.WriteLine();
            }

            // Draw the instructions.
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("Choose a piece and a slot to move. ");
        }

        /// <summary>
        /// Print the stuff that doesn't change to the screen.
        /// </summary>
        private void PrintStatic()
        {
            // Draw the piece's numbers.
            Console.SetCursorPosition(2, 0);
            Console.WriteLine("10");
            Console.SetCursorPosition(11, 0);
            Console.WriteLine("11");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("12");
            Console.SetCursorPosition(4, 5);
            Console.WriteLine("9");
            Console.SetCursorPosition(11, 4);
            Console.WriteLine("8");
            Console.SetCursorPosition(18, 5);
            Console.WriteLine("7");
            Console.SetCursorPosition(13, 10);
            Console.WriteLine("6");
            Console.SetCursorPosition(4, 15);
            Console.WriteLine("5");
            Console.SetCursorPosition(11, 14);
            Console.WriteLine("4");
            Console.SetCursorPosition(18, 15);
            Console.WriteLine("3");
            Console.SetCursorPosition(2, 20);
            Console.WriteLine("0");
            Console.SetCursorPosition(11, 20);
            Console.WriteLine("1");
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("2");

            // Draw the instructions.
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("Choose a piece and a slot to move. ");
        }

        /// <summary>
        /// Initialize the variable.
        /// </summary>
        public Render()
        {
            slots = new char[]
           {
                '.', '.', '.', '.', '.', '.',
                '.',
                '.', '.', '.', '.', '.', '.'
           };
        }
    }
}
