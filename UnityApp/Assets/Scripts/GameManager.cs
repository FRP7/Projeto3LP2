using System;
using UnityEngine;
using Common;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        gameState = new GameState();
        Debug.Log(gameState.IsGameOver);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
