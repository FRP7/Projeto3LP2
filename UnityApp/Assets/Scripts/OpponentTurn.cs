using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Common;
using System.Linq;

public class OpponentTurn
{
    private UnityGame unityGame = new UnityGame();
    private GameState gameState = new GameState();
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
        //get => unityGame.GetAllSlots;
        get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        //set => unityGame.GetAllSlots = value;
        set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
    }

    public void OpponentPlay(int piece, int slot)
    {
        Debug.Log("Turno do oponente.");
        // 1: testar jogada
        if (ChoosePiece(piece, slot))
        {
            if(CheckIfLegal(piece, slot))
            {
                PlayPiece(piece, slot);
            }
            else
            {
                Debug.Log("A jogada não é válida");
            }
        }
        else
        {
            Debug.Log("A peça ou a slot não existem");
        }
    }

    private bool ChoosePiece(int piece, int slot)
    {
        Debug.Log("Chega aqui?");

        gameState.CheckOpponentLegalPlays(piece);

        Debug.Log("Peça escolhida");

        return true;
    }

    private bool CheckIfLegal(int piece, int slot)
    {
        Debug.Log("Verificar se é legal");
        return gameState.CheckIfLegal(piece, slot);
    }

    private void PlayPiece(int piece, int slot)
    {
        Debug.Log("Jogador joga peça.");
        if(unityGame.IsPlayerWhite)
        {
            gameState.OpponentPlay(piece, slot, true);
        }
        else
        {
            gameState.OpponentPlay(piece, slot, false);
        }

    }
}
