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
        // 1: testar jogada
        ChoosePiece(1);
        PlayPiece();
    }

    private void ChoosePiece(int piece)
    {
        GameState gameState = new GameState();
        gameState.CheckPlayerLegalPlays(piece);

        /*foreach (var item in ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>())
       {
           Debug.Log($"Tipo: {item.Item1}. Cor: {item.Item2}");
       }*/

        Debug.Log("Peça escolhida");
    }

    private void PlayPiece()
    {
        Debug.Log("Jogador joga peça.");
    }
}
