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

        /// <summary>
        /// Render the game.
        /// </summary>
        public void RenderGame()
        {
            DrawTable();
        }

        /// <summary>
        /// Draw the table.
        /// </summary>
        private void DrawTable()
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

            // Draw the first half of the board.
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 1);
                if (i == 2)
                {
                    Console.WriteLine($"{slots[10]}");
                }
                else if (i > 2 && i < 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"{slots[11]}");
                }
                else if (i > 11 && i < 20)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 20)
                {
                    Console.WriteLine($"{slots[12]}");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 2);
                if (i == 3)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 19)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 3);
                if (i == 4)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 18)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 4);
                if (i == 5)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 17)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 5);
                if (i == 6)
                {
                    Console.WriteLine($"{slots[9]}");
                }
                else if (i > 6 && i < 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"{slots[8]}");
                }
                else if (i > 11 && i < 16)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 16)
                {
                    Console.WriteLine($"{slots[7]}");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 6);
                if (i == 7)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 15)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 7);
                if (i == 8)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 14)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 8);
                if (i == 9)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 13)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 9);
                if (i == 10)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 12)
                {
                    Console.WriteLine($"-");
                }
            }

            // Draw the middle of the board.
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 10);
                if (i == 11)
                {
                    Console.WriteLine($"{slots[6]}");
                }
            }

            // Draw the second half of the board.
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 11);
                if (i == 10)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 12)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 12);
                if (i == 9)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 13)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 13);
                if (i == 8)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 14)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 20; i++)
            {
                Console.SetCursorPosition(i, 14);
                if (i == 7)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 15)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 20; i++)
            {
                Console.SetCursorPosition(i, 15);
                if (i == 6)
                {
                    Console.WriteLine($"{slots[5]}");
                }
                else if (i > 6 && i < 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"{slots[4]}");
                }
                else if (i > 11 && i < 16)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 16)
                {
                    Console.WriteLine($"{slots[3]}");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 16);
                if (i == 5)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 17)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 17);
                if (i == 4)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 18)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 18);
                if (i == 3)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 19)
                {
                    Console.WriteLine($"-");
                }
            }

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 19);
                if (i == 2)
                {
                    Console.WriteLine($"{slots[0]}");
                }
                else if (i > 2 && i < 11)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 11)
                {
                    Console.WriteLine($"{slots[1]}");
                }
                else if (i > 11 && i < 20)
                {
                    Console.WriteLine($"-");
                }
                else if (i == 20)
                {
                    Console.WriteLine($"{slots[2]}");
                }
            }

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
