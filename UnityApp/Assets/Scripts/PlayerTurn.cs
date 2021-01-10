using System;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PlayerTurn
{
    private UnityGame unityGame = new UnityGame();
    // Todas as peças.
    public List<Tuple<int, SlotTypes, SlotColors>> GetPlayerLegalPlays
    {
        //get => board.AllSlots;
        get => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
        //set => board.AllSlots = value;
        set => ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>();
    }

    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        //get => board.AllSlots;
        get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        //set => board.AllSlots = value;
        set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
    }

    public void PlayerPlay(int piece, int slot)
    {
        Debug.Log("Turno do jogador.");
        // 1: testar jogada
        ChoosePiece(piece, slot);
        PlayPiece(piece, slot);
    }

    private void ChoosePiece(int piece, int slot)
    {
        GameState gameState = new GameState();
        gameState.CheckPlayerLegalPlays(piece);

        /*foreach (var item in ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>())
       {
           Debug.Log($"Tipo: {item.Item1}. Cor: {item.Item2}");
       }*/

        Debug.Log("Peça escolhida");
    }

    private void PlayPiece(int piece, int slot)
    {
        Debug.Log("Jogador joga peça.");

        if (unityGame.IsPlayerWhite)
        {
            GetAllSlots[slot] = new Tuple<SlotTypes, SlotColors>(SlotTypes.Player, SlotColors.White);
        }
        else if(!unityGame.IsPlayerWhite)
        {
            GetAllSlots[slot] = new Tuple<SlotTypes, SlotColors>(SlotTypes.Player, SlotColors.Black);
        }

        GetAllSlots[piece] = new Tuple<SlotTypes, SlotColors>(SlotTypes.None, SlotColors.Grey);

        // testar
        /*foreach(var item in GetPlayerLegalPlays)
        {
            Debug.Log($"Type: {item.Item1}. Color: {item.Item2}");
        }*/

        // esvaziar a lista
        GetPlayerLegalPlays.Clear();
    }
}
