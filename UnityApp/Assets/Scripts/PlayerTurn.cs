using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Common;
using System.Linq;

public class PlayerTurn
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

    public void PlayerPlay(int piece, int slot)
    {
        Debug.Log("Turno do jogador.");
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
        // aqui que o bug está no checkplayerlegalplays e deve ser relacionado com o 6

        gameState.CheckPlayerLegalPlays(piece);

        /*foreach (var item in ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>())
       {
           Debug.Log($"Tipo: {item.Item1}. Cor: {item.Item2}");
       }*/

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
            gameState.PlayerPlay(piece, slot, true);
        }
        else
        {
            gameState.PlayerPlay(piece, slot, false);
        }

        /*if (unityGame.IsPlayerWhite)
        {
            GetAllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.White);
        }
        else if (!unityGame.IsPlayerWhite)
        {
            GetAllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.Black);
            Debug.Log("Atualizar peças.");
        }
        GetAllSlots[piece] = Tuple.Create(SlotTypes.None, SlotColors.Grey);

        GetPlayerLegalPlays.Clear();*/

    }
}
