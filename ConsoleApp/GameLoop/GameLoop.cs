using System;
using System.Threading;
using System.Collections.Generic;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the game loop happens.
    /// </summary>
    public class GameLoop
    {
        // Access Render class.
        private Render render;

        // Access UserInput class.
        private UserInput userInput;

        // Access the GameState class (in the Common).
        private GameState gameState;

        /// <summary>
        /// Gets or sets a value indicating whether the player is white.
        /// </summary>
        public bool IsPlayerWhite { get; set; }

        /// <summary>
        /// Gets a value indicating whether the player is the first to play.
        /// </summary>
        public bool IsPlayerFirst => gameState.IsPlayerFirst;

        /// <summary>
        /// Gets or sets all slots in the game (whether are occupied by the
        /// player or not).
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
        {
            get => ServiceLocator.GetService<GameData>().AllSlots;
            set => ServiceLocator.GetService<GameData>().AllSlots = value;
        }

        // Checks whether is the player's turn.
        private bool isPlayer;

        // Checks whether is the opponent turn.
        private bool isOpponent;

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
            userInput = new UserInput();
            gameState = new GameState();
            gameState.Start();
            render = new Render();
            SetColor();

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
            Update update = new Update(
                IsPlayerFirst, 
                IsPlayerWhite, 
                gameState.CheckWin,
                RenderGame,
                CheckUserInput,
                isPlayer,
                isOpponent);
            update.UpdateGame(GetAllSlots);

        }

        /// <summary>
        /// Check the user input.
        /// </summary>
        private void CheckUserInput()
        {
            Thread thread = new Thread(userInput.CheckUserInput);
            thread.Start();
            thread.Join();
        }

        /// <summary>
        /// Render the game.
        /// </summary>
        /// <param name="isPlayer"> Checks whether is the player's turn.
        /// </param>
        /// <param name="isOpponent"> Checks whether is the opponent's turn.
        /// </param>
        private void RenderGame(bool isPlayer, bool isOpponent)
        {
            render.RenderGame();
        }

        /// <summary>
        /// Set the colors in the game.
        /// </summary>
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

        /// <summary>
        /// Initialize the property.
        /// </summary>
        /// <param name="isPlayerWhite"> Checks whether the player is white.
        /// </param>
        public GameLoop(bool isPlayerWhite)
        {
            IsPlayerWhite = isPlayerWhite;
        }
    }
}
