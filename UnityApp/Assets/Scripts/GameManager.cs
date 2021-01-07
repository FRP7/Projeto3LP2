using System;
using UnityEngine;
using Common;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private Material black;
    [SerializeField] private Material white;
    [SerializeField] private Material playerColor;
    [SerializeField] private Material aiColor;
    [SerializeField] private Transform[] slots;

    private void Awake()
    {
        gameState = new GameState();
        gameState.playerColor = Colors.White;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void SetColor()
    {
        if (gameState.playerColor == Colors.Black)
        {
            playerColor.color = black.color;
            aiColor.color = white.color;
        }
        if (gameState.playerColor == Colors.White)
        {
            playerColor.color = white.color;
            aiColor.color = black.color;
        }
    }
}
