using System;
using System.Collections.Generic;
using Common;

/// <summary>
/// Class of the opponent's turn.
/// </summary>
public class OpponentTurn
{
    // Access the GameState class (common)
    private GameState gameState; 

    /// <summary>
    /// Gets or sets whether the turn is played.
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
        if (!IsPlayed)
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
    /// <param name="piece"> The chosen piece.</param>
    /// <param name="slot"> The chosen slot.</param>
    /// <returns> Returns true if the chosen play is legal.</returns>
    private bool CheckIfLegal(int piece, int slot)
    {
        return gameState.CheckIfLegal(piece, slot);
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

    /// <summary>
    /// Initialize the variables and properties.
    /// </summary>
    public OpponentTurn()
    {
        IsPlayed = false;
        gameState  = new GameState();
    }
}
