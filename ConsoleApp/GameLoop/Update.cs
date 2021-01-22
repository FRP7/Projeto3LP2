using System;
using Common;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the logic of the game is updated.
    /// </summary>
    public class Update
    {
        private bool isPlayerFirst;

        private bool IsPlayerWhite { get; }

        public bool IsPlayer { get; private set; }

        public bool IsOpponent { get; private set; }

        private UserInput userInput;

        public delegate Victory CheckWin();
        public CheckWin checkWin;

        public delegate void RenderGame(bool isPlayer, bool isOpponent);
        public RenderGame renderGame;

        public delegate void CheckUserInput();
        public CheckUserInput checkUserInput;

        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
        {
            get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
            set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        }
        /// <summary>
        /// Update the logic of the game.
        /// </summary>
        public void UpdateGame()
        {
            //GameState gameState = new GameState();
            //Console.WriteLine("Game updated");
            GameResult gameResult = new GameResult();

            bool isGame = true;
            while (isGame)
            {
                if (checkWin.Invoke() == Victory.None)
                {
                    Console.SetCursorPosition(25, 15);
                    if (IsPlayer)
                    {
                        Console.WriteLine("Turno do jogador");
                    }
                    else if (IsOpponent)
                    {
                        Console.WriteLine("Turno do oponente");
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
                    // ganhou o oponente
                    isGame = false;
                    gameResult.ShowGameResult(false);
                }
                else if (checkWin.Invoke() == Victory.Player)
                {
                    // ganhou o jogador
                    isGame = false;
                    gameResult.ShowGameResult(true);
                }
            }
        }

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

        private void PlayerFirst()
        {
            if (IsPlayer)
            {
                while (IsPlayer)
                {
                    //checkUserInput.Invoke();
                    PlayerPlay();
                    SetColor();
                }
            }
            else if (IsOpponent)
            {
                while (IsOpponent)
                {
                    //checkUserInput.Invoke();
                    OpponentPlay();
                    SetColor();
                }
            }
        }

        private void OpponentPlay()
        {
            OpponentTurn opponentTurn = new OpponentTurn();
            checkUserInput.Invoke();
            opponentTurn.OpponentPlay(UserInput.Piece, UserInput.Slot);
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

        private void PlayerPlay()
        {
            PlayerTurn playerTurn = new PlayerTurn();
            checkUserInput.Invoke();
            playerTurn.PlayerPlay(UserInput.Piece, UserInput.Slot);
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
        /// Initialize variables.
        /// </summary>
        public Update(bool isPlayerFirst, bool isPlayerWhite, 
            CheckWin checkWin, RenderGame renderGame, 
            CheckUserInput checkUserInput, bool isPlayer, bool isOpponent)
        {
            this.isPlayerFirst = isPlayerFirst;
            IsPlayerWhite = isPlayerWhite;
            userInput = new UserInput();
            this.checkWin += checkWin;
            this.renderGame += renderGame;
            this.checkUserInput += checkUserInput;
            this.IsPlayer = isPlayer;
            this.IsOpponent = isOpponent;
        }
    }
}
