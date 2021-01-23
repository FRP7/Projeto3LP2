using System;
using System.Collections.Generic;
using UnityEngine;
using Common;

/// <summary>
/// Class where the game is controlled. 
/// </summary>
public class UnityGame : MonoBehaviour
{
    // Access the GameState (in the Common).
    private GameState gameState;

    // List of all the slot GameObjects.
    [SerializeField] private List<GameObject> AllObjects = 
        new List<GameObject>();

    // The chosen piece.
    [SerializeField] private int piece;

    // The chosen slot.
    [SerializeField] private int slot;

    // Checks whether the turn is played.
    [SerializeField] private bool isPlayed;

    // Checks whether is the player's turn.
    [SerializeField] private bool isPlayer;

    // Checks whether is the opponent's turn.
    [SerializeField] private bool isOpponent;

    /// <summary>
    /// Gets and sets whether is the player's turn.
    /// </summary>
    public bool IsPlayer
    {
        get => isPlayer;
        set => isPlayer = value;
    }

    /// <summary>
    /// Gets and sets whether is the opponent's turn.
    /// </summary>
    public bool IsOpponent
    {
        get => isOpponent;
        set => isOpponent = value;
    }

    /// <summary>
    /// Gets and sets the chosen piece.
    /// </summary>
    public int Piece
    {
        get => piece;
        set => piece = value;
    }

    /// <summary>
    /// Gets and sets the chosen slot.
    /// </summary>
    public int Slot
    {
        get => slot;
        set => slot = value;
    }

    /// <summary>
    /// Gets and sets whether the turn is played.
    /// </summary>
    public bool IsPlayed
    {
        get => isPlayed;
        set => isPlayed = value;
    }

    /// <summary>
    /// Gets and sets all the slots in the game (whether are occupied by the 
    /// player or not).
    /// </summary>
    public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
    {
        get => ServiceLocator.GetService<GameData>().AllSlots;
        set => ServiceLocator.GetService<GameData>().AllSlots = value;
    }

    /// <summary>
    /// Gets whether the player is white.
    /// </summary>
    public bool IsPlayerWhite => colorSpec.IsPlayerWhite; 

    /// <summary>
    /// Gets whether the player is the first to play.
    /// </summary>
    public bool IsPlayerFirst => gameState.IsPlayerFirst;

    // Access the ColorSO ScriptableObject.
    [SerializeField] private ColorSO colorSpec;

    /// <summary>
    /// Method to be played before the game begins.
    /// </summary>
    private void Awake()
    {
        piece = -1;
        slot = -1;
        gameState = new GameState();
        isPlayed = false;
        isPlayer = false;
        isOpponent = false;
    }

    /// <summary>
    /// Method to be played in the first frame of the game.
    /// </summary>
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

    /// <summary>
    /// Method to be called all the frames.
    /// </summary>
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
                OpponentFirst();
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

    /// <summary>
    /// Choose a color.
    /// </summary>
    private void PickColor()
    {
        if (IsPlayerWhite)
        {
            gameState.PlayerType = SlotColors.White;
        }
        else if (!IsPlayerWhite)
        {
            gameState.PlayerType = SlotColors.Black;
        }
    }

    /// <summary>
    /// Update the colors.
    /// </summary>
    private void SetColor()
    {
        if (gameState.PlayerType == SlotColors.Black)
        {
            for (int i = 0; i < GetAllSlots.Count; i++)
            {
                if (GetAllSlots[i].Item1 == SlotTypes.Player)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color =
                        Color.black;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = 
                        Color.white;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.None)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = 
                        Color.grey;
                }
            }
        }
        else if (gameState.PlayerType == SlotColors.White)
        {

            for (int i = 0; i < GetAllSlots.Count; i++)
            {
                if (GetAllSlots[i].Item1 == SlotTypes.Player)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color =
                        Color.white;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = 
                        Color.black;
                }
                else if (GetAllSlots[i].Item1 == SlotTypes.None)
                {
                    AllObjects[i].GetComponent<SpriteRenderer>().color = 
                        Color.grey;
                }
            }
        }
    }

    /// <summary>
    /// The game loop when the opponent is the first to play.
    /// </summary>
    private void OpponentFirst()
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

    /// <summary>
    /// The game loop when the player is the first to play.
    /// </summary>
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

    /// <summary>
    /// The player's play.
    /// </summary>
    private void PlayerPlay()
    {
        PlayerTurn playerTurn = new PlayerTurn();

        if (isPlayed == true)
        {
            playerTurn.PlayerPlay(piece, slot, IsPlayerWhite);
            piece = -1;
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

    /// <summary>
    /// The opponent's play.
    /// </summary>
    private void OpponentPlay()
    {
        OpponentTurn opponentTurn = new OpponentTurn();

        if (isPlayed == true)
        {
            opponentTurn.OpponentPlay(piece, slot, IsPlayerWhite);
            piece = -1;
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
