﻿using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class that takes care of the opponent's turn.
    /// </summary>
    public class OpponentTurn
    {
        // The GameState class from Common.
        private readonly GameState gameState;

        /// <summary>
        /// Gets or sets a value indicating whether the turn is over.
        /// </summary>
        public bool IsPlayed { get; set; }

        /// <summary>
        /// Play the turn.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <param name="slot"> Chosen slot.</param>
        /// <param name="isPlayerWhite"> Check whether the player is white.
        /// </param>
        public void OpponentPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (ChoosePiece(piece) && CheckIfLegal(slot))
            {
                PlayPiece(piece, slot, isPlayerWhite);
                IsPlayed = true;
            }
        }

        /// <summary>
        /// Choose a piece and list all possible legal plays.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <returns> Returns true if the piece is legal.</returns>
        private bool ChoosePiece(int piece)
        {
            gameState.CheckOpponentLegalPlays(piece);

            return true;
        }

        /// <summary>
        /// Check if the chosen play is legal.
        /// </summary>
        /// <param name="slot"> Chosen slot.</param>
        /// <returns> Returns true if the chosen play is legal. </returns>
        private bool CheckIfLegal(int slot)
        {
            return gameState.CheckIfLegal(slot);
        }

        /// <summary>
        /// Play the piece.
        /// </summary>
        /// <param name="piece"> Chosen piece. </param>
        /// <param name="slot"> Chosen slot. </param>
        /// <param name="isPlayerWhite"> Checks whether the player is white.
        /// </param>
        private void PlayPiece(int piece, int slot, bool isPlayerWhite)
        {
            if (isPlayerWhite)
            {
                gameState.OpponentPlay(piece, slot, true);
            }
            else
            {
                gameState.OpponentPlay(piece, slot, false);
            }
        }

        /// <summary>
        /// Initialize the variables and properties.
        /// </summary>
        public OpponentTurn()
        {
            IsPlayed = false;
            gameState = new GameState();
        }
    }
}