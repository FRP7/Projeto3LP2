using System;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PlayerTurn
{

    public void PlayerPlay()
    {
        UnityGame unityGame = new UnityGame();

        Debug.Log("Turno do jogador.");
        ChoosePiece(unityGame.piece);
        PlayPiece();
        // teste
        //ServiceLocator.Register<List<Tuple<SlotTypes, SlotColors>>>(AllSlots)
        /*foreach (var item in ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>())
        {
            Debug.Log($"Tipo: {item.Item1}. Cor: {item.Item2}");
        }*/
    }

    private void ChoosePiece(int piece)
    {
        GameState gameState = new GameState();
        gameState.CheckPlayerLegalPlays(piece);

        foreach (var item in ServiceLocator.GetService<List<Tuple<int, SlotTypes, SlotColors>>>())
        {
            Debug.Log($"Int: {item.Item1}. Tipo: {item.Item2}. Cor: {item.Item3}");
        }
        Debug.Log("Peça escolhida");
    }

    private void PlayPiece()
    {
        Debug.Log("Jogador joga peça.");
    }
}
