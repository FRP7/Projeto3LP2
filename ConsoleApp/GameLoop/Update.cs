using System;
using System.Collections.Generic;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the logic of the game is updated.
    /// </summary>
    public class Update
    {
        // Check whether the player is the first to play.
        private readonly bool isPlayerFirst;

        // Gets and checks whether the player is the first to play.
        private bool IsPlayerWhite { get; }

        /// <summary>
        /// Gets a value indicating whether is the player's turn.
        /// </summary>
        public bool IsPlayer { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is the opponent's turn.
        /// </summary>
        public bool IsOpponent { get; private set; }

        /// <summary>
        /// Delegate of the win checker method.
        /// </summary>
        /// <returns> Returns an enum to point if someone won.</returns>
        public delegate Victory CheckWin();

        // Access the delegate CheckWin.
        private readonly CheckWin checkWin;

        /// <summary>
        /// Delegate of the render game method.
        /// </summary>
        /// <param name="isPlayer"> Check whether is the player's turn.</param>
        /// <param name="isOpponent"> Check wthether is the opponent's turn.
        /// </param>
        public delegate void RenderGame(bool isPlayer, bool isOpponent);

        // Access the delegate RenderGame.
        private readonly RenderGame renderGame;

        /// <summary>
        /// Delegate of the check user input.
        /// </summary>
        public delegate void CheckUserInput();

        // Access the delegate CheckUserInput.
        private readonly CheckUserInput checkUserInput;

        /// <summary>
        /// Gets or sets all the slots in the game (whether are occupied by
        /// the player or not).
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots { get; set; }

        /// <summary>
        /// Update the logic of the game.
        /// </summary>
        /// <param name="slots"> All slots in the game (whether are occupied by
        /// the player or not).</param>
        public void UpdateGame(List<Tuple<SlotTypes, SlotColors>> slots)
        {
            GameResult gameResult = new GameResult();

            GetAllSlots = slots;

            bool isGame = true;
            while (isGame)
            {
                if (checkWin.Invoke() == Victory.None)
                {
                    Console.SetCursorPosition(25, 15);
                    if (IsPlayer)
                    {
                        Console.WriteLine("Player's turn.");
                    }
                    else if (IsOpponent)
                    {
                        Console.WriteLine("Opponent turn.");
                    }

                    if (isPlayerFirst)
                    {
                        PlayerFirst();
                        renderGame.Invoke(IsPlayer, IsOpponent);
                    }
                    else
                    {
                        OpponentFirst();
                        renderGame.Invoke(IsPlayer, IsOpponent);
                    }
                }
                else if (checkWin.Invoke() == Victory.Opponent)
                {
                    // The opponent won.
                    isGame = false;
                    gameResult.ShowGameResult(false);
                }
                else if (checkWin.Invoke() == Victory.Player)
                {
                    // The player won.
                    isGame = false;
                    gameResult.ShowGameResult(true);
                }
            }
        }

        /// <summary>
        /// GameLoop if the opponent is the first to play in the game.
        /// </summary>
        private void OpponentFirst()
        {
            if (IsOpponent)
            {
                while (IsOpponent)
                {
                    checkUserInput.Invoke();
                    OpponentPlay();
                    SetColor();
                }
            }
            else if (IsPlayer)
            {

                while (IsPlayer)
                {
                    checkUserInput.Invoke();
                    PlayerPlay();
                    SetColor();
                }
            }
        }

        /// <summary>
        /// GameLoop if the player is the first to play in the game.
        /// </summary>
        private void PlayerFirst()
        {
            if (IsPlayer)
            {
                while (IsPlayer)
                {
                    PlayerPlay();
                    SetColor();
                }
            }
            else if (IsOpponent)
            {
                while (IsOpponent)
                {
                    OpponentPlay();
                    SetColor();
                }
            }
        }

        /// <summary>
        /// Method of the opponent's play.
        /// </summary>
        private void OpponentPlay()
        {
            OpponentTurn opponentTurn = new OpponentTurn();
            checkUserInput.Invoke();
            opponentTurn.OpponentPlay(
                UserInput.Piece,
                UserInput.Slot,
                IsPlayerWhite);
            renderGame.Invoke(IsPlayer, IsOpponent);
            if (UserInput.Piece != -1 && UserInput.Slot != -1)
            {
                if (opponentTurn.IsPlayed)
                {
                    IsOpponent = false;
                    IsPlayer = true;
                }

                UserInput.Piece = -1;
                UserInput.Slot = -1;
            }
        }

        /// <summary>
        /// Method of the player's play.
        /// </summary>
        private void PlayerPlay()
        {
            PlayerTurn playerTurn = new PlayerTurn();
            checkUserInput.Invoke();
            playerTurn.PlayerPlay(
                UserInput.Piece,
                UserInput.Slot,
                IsPlayerWhite);
            renderGame.Invoke(IsPlayer, IsOpponent);
            if (UserInput.Piece != -1 && UserInput.Slot != -1)
            {
                if (playerTurn.IsPlayed)
                {
                    IsPlayer = false;
                    IsOpponent = true;
                }

                UserInput.Piece = -1;
                UserInput.Slot = -1;
            }
        }

        /// <summary>
        /// Update the colors in the board.
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
        /// Initialize the variables.
        /// </summary>
        /// <param name="isPlayerFirst"> Checks whether the player is the first 
        /// to play.</param>
        /// <param name="isPlayerWhite"> Checks whether the player is white.
        /// </param>
        /// <param name="checkWin"> The method to check if there's a win.
        /// </param>
        /// <param name="renderGame"> The method to render the game.</param>
        /// <param name="checkUserInput"> The method to check and read the
        /// user's input.</param>
        /// <param name="isPlayer"> Checks whether it's the player's turn.
        /// </param>
        /// <param name="isOpponent"> Checks whether it's the opponent's turn.
        /// </param>
        public Update(
            bool isPlayerFirst,
            bool isPlayerWhite,
            CheckWin checkWin,
            RenderGame renderGame,
            CheckUserInput checkUserInput,
            bool isPlayer,
            bool isOpponent)
        {
            this.isPlayerFirst = isPlayerFirst;
            IsPlayerWhite = isPlayerWhite;
            this.checkWin += checkWin;
            this.renderGame += renderGame;
            this.checkUserInput += checkUserInput;
            this.IsPlayer = isPlayer;
            this.IsOpponent = isOpponent;
        }
    }
}
