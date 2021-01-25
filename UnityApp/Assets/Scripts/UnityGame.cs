using System;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityApp
{
    /// <summary>
    /// Class where the game is controlled.
    /// </summary>
    public class UnityGame : MonoBehaviour
    {
        // Access the ColorSO ScriptableObject.
        [SerializeField]
        private ColorSO colorSpec;

        // List of all the slot GameObjects.
        [SerializeField]
        private List<GameObject> allObjects =
            new List<GameObject>();

        // Access the result ScriptableoObject.
        [SerializeField]
        private ResultSO resultSO;

        // Access the GameState (in the Common).
        private GameState gameState;

        /// <summary>
        /// Gets or sets a value indicating whether the turn is played.
        /// </summary>
        public bool IsPlayed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the player's turn.
        /// </summary>
        public bool IsPlayer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the opponent's turn.
        /// </summary>
        public bool IsOpponent { get; set; }

        /// <summary>
        /// Gets or sets the chosen piece.
        /// </summary>
        public int Piece { get; set; }

        /// <summary>
        /// Gets or sets the chosen slot.
        /// </summary>
        public int Slot { get; set; }

        /// <summary>
        /// Gets or sets all the slots in the game (whether are occupied by the
        /// player or not).
        /// </summary>
        public List<Tuple<SlotTypes, SlotColors>> GetAllSlots
        {
            get => ServiceLocator.GetService<GameData>().AllSlots;
            set => ServiceLocator.GetService<GameData>().AllSlots = value;
        }

        /// <summary>
        /// Gets a value indicating whether the player is white.
        /// </summary>
        public bool IsPlayerWhite => colorSpec.IsPlayerWhite;

        /// <summary>
        /// Gets a value indicating whether the player is the first to play.
        /// </summary>
        public bool IsPlayerFirst => gameState.IsPlayerFirst;

        /// <summary>
        /// Method to be played before the game begins.
        /// </summary>
        private void Awake()
        {
            Piece = -1;
            Slot = -1;
            gameState = new GameState();
            IsPlayed = false;
            IsPlayer = false;
            IsOpponent = false;
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
                IsPlayer = true;
            }
            else if (!IsPlayerFirst)
            {
                IsOpponent = true;
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
                resultSO.HasPlayerWon = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().
                    buildIndex + 1);
            }
            else if (gameState.CheckWin() == Victory.Player)
            {
                // ganhou o jogador
                resultSO.HasPlayerWon = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().
                    buildIndex + 1);
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
                        allObjects[i].GetComponent<SpriteRenderer>().color =
                            Color.black;
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
                    {
                        allObjects[i].GetComponent<SpriteRenderer>().color =
                            Color.white;
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.None)
                    {
                        allObjects[i].GetComponent<SpriteRenderer>().color =
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
                        allObjects[i].GetComponent<SpriteRenderer>().color =
                            Color.white;
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.Opponent)
                    {
                        allObjects[i].GetComponent<SpriteRenderer>().color =
                            Color.black;
                    }
                    else if (GetAllSlots[i].Item1 == SlotTypes.None)
                    {
                        allObjects[i].GetComponent<SpriteRenderer>().color =
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
            if (IsOpponent)
            {
                OpponentPlay();
                SetColor();
            }
            else if (IsPlayer)
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
            if (IsPlayer)
            {
                PlayerPlay();
                SetColor();
            }
            else if (IsOpponent)
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

            if (IsPlayed)
            {
                playerTurn.PlayerPlay(Piece, Slot, IsPlayerWhite);
                Piece = -1;
                Slot = -1;
                if (playerTurn.IsPlayed)
                {
                    IsPlayed = false;
                    IsPlayer = false;
                    IsOpponent = true;
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

            if (IsPlayed)
            {
                opponentTurn.OpponentPlay(Piece, Slot, IsPlayerWhite);
                Piece = -1;
                Slot = -1;
                if (opponentTurn.IsPlayed)
                {
                    IsPlayed = false;
                    IsPlayer = true;
                    IsOpponent = false;
                    SetColor();
                }
            }
        }
    }
}
