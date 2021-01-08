using System;
using UnityEngine;
using Common;

public class Player : MonoBehaviour
{
    [SerializeField] private int x = 0;
    [SerializeField] private int y = 0;
    [SerializeField] private GameObject gameManager;

    public bool PlayerPlay()
    {
        if (x != 0 && y != 0)
        {
            gameManager.GetComponent<GameManager>().GameState.PlayPiece(x, y);
            Debug.Log("Jogada feita");
            x = 0;
            y = 0;
            return true;
        }
        else
        {
            Debug.Log("Jogue");
            return false;
        }
    }
}
