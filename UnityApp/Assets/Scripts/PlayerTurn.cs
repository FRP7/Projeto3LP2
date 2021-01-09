using System;
using UnityEngine;
using Common;

public class PlayerTurn
{

    public void PlayerPlay()
    {
        UnityGame unityGame = new UnityGame();

        Debug.Log("Jogador joga.");
        Play(unityGame.piece, unityGame.slot);
    }

    // Onde a jogada é feita.
    private void Play(int piece, int slot)
    {
    }
}
