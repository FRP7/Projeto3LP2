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
    [SerializeField] private bool isPlayed;
    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isOpponent;

    public bool IsPlayer
    {
        get => isPlayer;
        set => isOpponent = value;
    }

    public bool IsOpponent
    {
        get => isOpponent;
        set => isOpponent = value;
    }

    public int Peca
    {
        get => peca;
        set => peca = value;
    }

    public int Slot
    {
        get => slot;
        set => slot = value;
    }

    public bool IsPlayed
    {
        get => isPlayed;
        set => isPlayed = value;
    }

    // Todas as peças.
    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        get => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
        set => ServiceLocator.GetService<List<Tuple<SlotTypes, SlotColors>>>();
    }

    public bool IsPlayerWhite { get => isPlayerWhite; }

    public bool IsPlayerFirst => gameState.IsPlayerFirst;

    // False = black  TRUE = white
    [SerializeField] private bool isPlayerWhite;


    private void Awake()
    {
        gameState = new GameState();
        isPlayed = false;
        isPlayer = false;
        isOpponent = false;
    }
    // Start is called before the first frame update
    private void Start()
    {
        PickColor();
        gameState.Start();
        SetColor();
        if (IsPlayerFirst)
        {
            isPlayer = true;
        }
        else if (!IsPlayerFirst)
        {
            isOpponent = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameState.CheckWin() == Victory.None)
        {
            if (gameState.IsPlayerFirst)
            {
                PlayerFirst();
            }
            else
            {
                AIFirst();
            }
        }
        else if (gameState.CheckWin() == Victory.Opponent)
        {
            // ganhou o oponente
        }
        else if (gameState.CheckWin() == Victory.Player)
        {
            // ganhou o jogador
        }
    }

    private void PickColor()
    {
        if (isPlayerWhite)
        {
            gameState.PlayerType = SlotColors.White;
        }
        else if (!isPlayerWhite)
        {
            gameState.PlayerType = SlotColors.Black;
        }
    }

    private void SetColor()
    {
        if (gameState.PlayerType == SlotColors.Black)
        {
            for (int i = 0; i < GetAllSlots.Count; i++)
            {
                if (GetAllSlots[i].Item1 == SlotTypes.Player)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = Color.black;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
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
                else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
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
        if (isOpponent)
        {
            OpponentPlay();
            SetColor();
        }
        else if (isPlayer)
        {
            PlayerPlay();
            SetColor();
        }
    }

    private void PlayerFirst()
    {
        if (isPlayer)
        {
            PlayerPlay();
            SetColor();
        }
        else if (isOpponent)
        {
            OpponentPlay();
            SetColor();
        }
    }

    private void PlayerPlay()
    {
        Debug.Log("Começa o turno do jogador.");
        PlayerTurn playerTurn = new PlayerTurn();

        if (isPlayed == true)
        {
            playerTurn.PlayerPlay(peca, slot, isPlayerWhite);
            peca = -1;
            slot = -1;
            if (playerTurn.IsPlayed)
            {
                isPlayed = false;
                isPlayer = false;
                isOpponent = true;
                SetColor();
            }
        }
    }

    private void OpponentPlay()
    {
        Debug.Log("Começa o turno do oponente.");
        OpponentTurn opponentTurn = new OpponentTurn();

        if (isPlayed == true)
        {
            opponentTurn.OpponentPlay(peca, slot, isPlayerWhite);
            peca = -1;
            slot = -1;
            if (opponentTurn.IsPlayed)
            {
                isPlayed = false;
                isPlayer = true;
                isOpponent = false;
                SetColor();
            }
        }
    }
}
