using System;
using System.Threading;
using Common;
using System.Collections.Generic;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the game loop happens.
    /// </summary>
    public class GameLoop
    {
        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        public static bool IsGameOver { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is won.
        /// </summary>
        public static bool IsGameWon { get; set; }

        // Access Update class.
        private Update update;

        // Access Render class.
        private Render render;

        // Access UserInput class.
        private UserInput userInput;

        // Access GameOver class.
        private GameOver gameOver;

        // Access GameWon class.
        private GameWon gameWon;

        private GameState gameState;

        public static bool IsPlayerWhite;

        public bool IsPlayerFirst => gameState.IsPlayerFirst;

        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
        {
            get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
            set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        }

        public static bool isPlayer;
        public static bool isOpponent;

        /// <summary>
        /// The game loop.
        /// </summary>
        public void Game()
        {
            Start();
            Update();
        }

        /// <summary>
        /// First frame of the game (similar to Unity).
        /// </summary>
        private void Start()
        {
            isPlayer = false;
            isOpponent = false;
            render = new Render();
            userInput = new UserInput();
            gameOver = new GameOver();
            gameWon = new GameWon();
            gameState = new GameState();
            gameState.Start();
            SetColor();
            //Console.WriteLine("Game initialized.");
            if (IsPlayerFirst)
            {
                isPlayer = true;
            }
            else if (!IsPlayerFirst)
            {
                isOpponent = true;
            }
        }

        /// <summary>
        /// Update each frame while the game isn't over (similar do Unity).
        /// </summary>
        private void Update()
        {
            update = new Update(IsPlayerFirst, IsPlayerWhite, 
                gameState.CheckWin, RenderGame, CheckUserInput);
            update.UpdateGame();
            //render.RenderGame();

        }

        private void CheckUserInput()
        {
            Thread thread = new Thread(userInput.CheckUserInput);
            thread.Start();
            thread.Join();
        }

        private void RenderGame()
        {
            render.RenderGame();
        }

        private void SetColor()
        {
            if (!IsPlayerWhite)
            {
                for (int i = 0; i < GetAllSlots.Count; i++)
                {
                    if (GetAllSlots[i].Item1 == SlotTypes.Player)
                    {
                        Render.Slots[i] = 'B';
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
                    {
                        Render.Slots[i] = 'W';
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.None)
                    {
                        Render.Slots[i] = 'X';
                    }
                }
            }

            if (IsPlayerWhite)
            {
                for (int i = 0; i < GetAllSlots.Count; i++)
                {
                    if (GetAllSlots[i].Item1 == SlotTypes.Player)
                    {
                        Render.Slots[i] = 'W';
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
                    {
                        Render.Slots[i] = 'B';
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.None)
                    {
                        Render.Slots[i] = 'X';
                    }
                }
            }
        }


        public GameLoop(bool isPlayerWhite)
        {
            IsPlayerWhite = isPlayerWhite;
        }

    }
}
