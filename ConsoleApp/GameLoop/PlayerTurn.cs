using System;
using System.Collections.Generic;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class that takes care of the player's turn.
    /// </summary>
    public class PlayerTurn
    {
        // The GameState class from Common.
        private GameState gameState; 

        /// <summary>
        /// Gets and sets whether the turn is over.
        /// </summary>
        public bool IsPlayed { get; set; }

        /// <summary>
        /// Play the turn.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <param name="slot"> Chosen slot.</param>
        /// <param name="isPlayerWhite"> Check whether the player is white.
        /// </param>
        public void PlayerPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (ChoosePiece(piece))
            {
                if (CheckIfLegal(piece, slot))
                {
                    PlayPiece(piece, slot, isPlayerWhite);
                    IsPlayed = true;
                }
            }
        }

        /// <summary>
        /// Choose a piece and list all possible legal plays.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <returns> Returns true if the piece is legal.</returns>
        private bool ChoosePiece(int piece)
        {
            gameState.CheckPlayerLegalPlays(piece);

            return true;
        }

        /// <summary>
        /// Check if the chosen play is legal.
        /// </summary>
        /// <param name="piece"> Chosen piece.</param>
        /// <param name="slot"> Chosen slot.</param>
        /// <returns> Returns true if the chosen play is legal. </returns>
        private bool CheckIfLegal(int piece, int slot)
        {
            return gameState.CheckIfLegal(piece, slot);
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
                gameState.PlayerPlay(piece, slot, true);
            }
            else
            {
                gameState.PlayerPlay(piece, slot, false);
            }
        }

        /// <summary>
        /// Initialize the variables and properties.
        /// </summary>
        public PlayerTurn()
        {
            IsPlayed = false;
            gameState = new GameState();
        }
    }
}
