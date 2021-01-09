using System;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class UnityGame : MonoBehaviour
{
    private GameState gameState;

    [SerializeField] private List<GameObject> playerObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> AIObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> EmptyObjects = new List<GameObject>();

    // Todas as peças.
    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        get => gameState.AllSlots;
    }

    // False = black  TRUE = white
    [SerializeField] private bool isPlayerWhite;

    //testar jogada
    [SerializeField] public int piece;
    [SerializeField] public int slot;


    private void Awake()
    {
        gameState = new GameState();
    }
    // Start is called before the first frame update
    void Start()
    {
        PickColor();
        gameState.Start();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState.IsPlayerFirst)
        {
            PlayerFirst();
        }
        else
        {
            AIFirst();
        }
    }

    private void PickColor()
    {
        if(isPlayerWhite)
        {
            gameState.PlayerType = SlotColors.White;
        }
        else if(!isPlayerWhite)
        {
            gameState.PlayerType = SlotColors.Black;
        }
    }

    private void SetColor()
    {
        if(gameState.PlayerType == SlotColors.Black)
        {
            foreach(GameObject item in playerObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.black;
            }
            foreach (GameObject item in AIObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else if (gameState.PlayerType == SlotColors.White)
        {
            foreach (GameObject item in playerObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.white;
            }
            foreach (GameObject item in AIObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }

        foreach (GameObject item in EmptyObjects)
        {
            item.GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    private void AIFirst()
    {
        gameState.Update();
        PlayerPlay();
    }

    private void PlayerFirst()
    {
        PlayerPlay();
        gameState.Update();
    }

    private void PlayerPlay()
    {
        PlayerTurn playerTurn = new PlayerTurn();
        playerTurn.PlayerPlay();
    }
}
