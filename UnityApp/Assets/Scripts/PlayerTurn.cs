using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Common;
using System.Linq;

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
        //get => unityGame.GetAllSlots;
        get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        //set => unityGame.GetAllSlots = value;
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
        Debug.Log("Chega aqui?");
        // aqui que o bug está no checkplayerlegalplays e deve ser relacionado com o 6
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

        // testar
        int index = 0;
        /*foreach (var item in GetPlayerLegalPlays)
        {
            Debug.Log($"Index: {index}. Type: {item.Item1.ToString()}. Color: {item.Item2.ToString()}");
            index++;
        }*/

        if (unityGame.IsPlayerWhite)
        {
            GetAllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.White);
        }
        else if (!unityGame.IsPlayerWhite)
        {
            GetAllSlots[slot] = Tuple.Create(SlotTypes.Player, SlotColors.Black);
            Debug.Log("Atualizar peças.");
        }

        GetAllSlots[piece - 1] = Tuple.Create(SlotTypes.None, SlotColors.Grey);
        // testar
        /*foreach(var item in GetPlayerLegalPlays)
        {
            Debug.Log($"Type: {item.Item1}. Color: {item.Item2}");
        }*/

        // testar
        /*int index = 0;
        foreach (var item in GetPlayerLegalPlays)
        {
            Debug.Log($"Index: {index}. Type: {item.Item1}. Color: {item.Item2}");
            index++;
        }*/
        Debug.Log("Tamanho da lista antes: " + GetAllSlots.Count);
        // esvaziar a lista
        GetPlayerLegalPlays.Clear();
        Debug.Log("Tamanho da lista depois: " + GetAllSlots.Count);

        //bug: a peça 6 tem problemas, acho que perde cenas da lista.
    }
}
