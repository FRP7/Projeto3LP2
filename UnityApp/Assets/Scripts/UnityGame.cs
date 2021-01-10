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

    [SerializeField] private List<GameObject> AllObjects = new List<GameObject>();

    // Todas as peças.
    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        get => gameState.AllSlots;
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
            /*foreach(GameObject item in playerObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.black;
            }
            foreach (GameObject item in AIObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.white;
            }*/

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

            /*foreach (GameObject item in playerObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.white;
            }
            foreach (GameObject item in AIObjects)
            {
                item.GetComponent<SpriteRenderer>().color = Color.black;
            }*/
        }

        /*foreach (GameObject item in EmptyObjects)
        {
            item.GetComponent<SpriteRenderer>().color = Color.grey;
        }*/
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
        playerTurn.PlayerPlay(4, 6);
    }
}
