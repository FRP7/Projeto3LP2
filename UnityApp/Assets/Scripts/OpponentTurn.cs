using Common;

namespace UnityApp
{
    /// <summary>
    /// Class of the opponent's turn.
    /// </summary>
    public class OpponentTurn
    {
        // Access the GameState class (common)
        private GameState gameState;

        /// <summary>
        /// Gets or sets a value indicating whether the turn is played.
        /// </summary>
        public bool IsPlayed { get; set; }

        /// <summary>
        /// The opponent's play.
        /// </summary>
        /// <param name="piece"> The chosen piece.</param>
        /// <param name="slot"> The chosen slot.</param>
        /// <param name="isPlayerWhite"> Whether the player is white.</param>
        public void OpponentPlay(int piece, int slot, bool isPlayerWhite)
        {
            if (!IsPlayed && ChoosePiece(piece) && CheckIfLegal(slot))
            {
                PlayPiece(piece, slot, isPlayerWhite);
                IsPlayed = true;
            }
        }

        /// <summary>
        /// List all the current legal plays with the chosen piece.
        /// </summary>
        /// <param name="piece"> The chosen piece.</param>
        /// <returns> Returns true if the chosen piece is legal.</returns>
        private bool ChoosePiece(int piece)
        {
            gameState.CheckOpponentLegalPlays(piece);

            return true;
        }

        /// <summary>
        /// Checks whether the play is legal.
        /// </summary>
        /// <param name="slot"> The chosen slot.</param>
        /// <returns> Returns true if the chosen play is legal.</returns>
        private bool CheckIfLegal(int slot)
        {
            return gameState.CheckIfLegal(slot);
        }

        /// <summary>
        /// Play the chosen piece.
        /// </summary>
        /// <param name="piece"> The chosen piece. </param>
        /// <param name="slot"> The chosen slot. </param>
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

        // Initialize the variables and properties.
        public OpponentTurn()
        {
            IsPlayed = false;
            gameState = new GameState();
        }
    }
}