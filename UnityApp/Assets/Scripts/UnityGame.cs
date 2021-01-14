using System;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class UnityGame : MonoBehaviour
{
    private GameState gameState;

    [SerializeField] private List<GameObject> AllObjects = new List<GameObject>();

    // para testar as jogadas.
    [Header("Testar as jogadas. Peça: número da peça + 1. Slot: número da slot a mover.")]
    [SerializeField] private int peca = -1;
    [SerializeField] private int slot = -1;

    // Todas as peças.
    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        //get => gameState.AllSlots;
        get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        //set => gameState.AllSlots = value;
        set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
    }

    public bool IsPlayerWhite { get => isPlayerWhite; }

    // False = black  TRUE = white
    [SerializeField] private bool isPlayerWhite;


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
            for(int i = 0; i < GetAllSlots.Count; i++)
            {
                if(GetAllSlots[i].Item1 == SlotTypes.Player)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.black;
                } else if(GetAllSlots[i].Item1 == SlotTypes.AI)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.None)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.grey;
                }
            }
        }
        else if (gameState.PlayerType == SlotColors.White)
        {

            for (int i = 0; i < GetAllSlots.Count; i++)
            {
                if (GetAllSlots[i].Item1 == SlotTypes.Player)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.AI)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.black;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.None)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.grey;
                }
            }
        }
    }

    private void AIFirst()
    {
        gameState.Update();
        SetColor();
        PlayerPlay();
    }

    private void PlayerFirst()
    {
        PlayerPlay();
        SetColor();
        gameState.Update();
    }

    private void PlayerPlay()
    {
        PlayerTurn playerTurn = new PlayerTurn();

        // peça, slot
        if (peca > -1 && slot > -1)
        {
            playerTurn.PlayerPlay(peca, slot);
            peca = -1;
            slot = -1;
        }
    }
}
