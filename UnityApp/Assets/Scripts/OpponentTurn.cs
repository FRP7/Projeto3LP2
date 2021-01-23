using System;
using System.Collections.Generic;
using Common;

public class OpponentTurn
{
    private GameState gameState = new GameState();

    public List<Tuple<int, SlotTypes, SlotColors, bool>> GetPlayerLegalPlays
    {
        //get => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
        get => ServiceLocator.GetService<GameData>().PlayerLegalPlays;
        //set => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
        set => ServiceLocator.GetService<GameData>().PlayerLegalPlays = value;
    }

    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        get => ServiceLocator.GetService<GameData>().AllSlots;
        set => ServiceLocator.GetService<GameData>().AllSlots = value;
    }

    public bool IsPlayed { get; set; }

    public void OpponentPlay(int piece, int slot, bool isPlayerWhite)
    {
        if (!IsPlayed)
        {
            if (ChoosePiece(piece, slot))
            {
                if (CheckIfLegal(piece, slot))
                {
                    PlayPiece(piece, slot, isPlayerWhite);
                    IsPlayed = true;
                }
            }
        }
    }

    private bool ChoosePiece(int piece, int slot)
    {
        gameState.CheckOpponentLegalPlays(piece);

        return true;
    }

    private bool CheckIfLegal(int piece, int slot)
    {
        return gameState.CheckIfLegal(piece, slot);
    }

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

    public OpponentTurn()
    {
        IsPlayed = false;
    }
}
