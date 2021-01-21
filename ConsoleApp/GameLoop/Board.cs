using System;
using Common;

namespace ConsoleApp
{
    public class Board : GameObject
    {
        public static char[] Slots
        {
            get => slots;
            set => slots = value;
        }

        private static char[] slots;

        private GameState gameState;

        /// <summary>
        /// First frame of the game.
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        /// Update the board every frame.
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Render the board.
        /// </summary>
        public override void Render()
        {
            DrawTable();
            //Console.WriteLine("Número de slots: " + slots.Length);
        }

        private void DrawTable()
        {
            // legendas
            Console.SetCursorPosition(2, 0);
            // 10
            Console.WriteLine("10");
            // 11
            Console.SetCursorPosition(11, 0);
            // 12
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

            // primeira metade

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

            // meio

            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(i, 10);
                if (i == 11)
                {
                    Console.WriteLine($"{slots[6]}");
                }
            }

            // segunda metade

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

            // Instruções:
            Console.SetCursorPosition(0, 21);
            if (GameLoop.isPlayer)
            {
                Console.WriteLine("Turno do jogador");
            }
            else if (GameLoop.isOpponent)
            {
                Console.WriteLine("Turno do oponente");
            }

            //Console.SetCursorPosition(0, 21);
            //Console.WriteLine("Escolha a peça e casa: ");
            /*Console.SetCursorPosition(0, 22);
            Console.WriteLine("Peça: " + UserInput.Piece);
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("Casa: " + UserInput.Slot);*/

        }

        public Board()
        {
            slots = new char[]
            {
                '.', '.', '.', '.', '.', '.',
                '.',
                '.', '.', '.', '.', '.', '.'
            };

            gameState = new GameState();
        }
    }
}
