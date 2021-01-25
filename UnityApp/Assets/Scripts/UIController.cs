using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityApp
{
    /// <summary>
    /// Class where the game's UI is controlled.
    /// </summary>
    public class UIController : MonoBehaviour
    {
        // InputField that gets the piece's number.
        [SerializeField]
        private InputField piece;

        // InputField that gets the slot's number.
        [SerializeField]
        private InputField slot;

        // Play button.
        [SerializeField]
        private Button playButton;

        // GameManager GameObject.
        [SerializeField]
        private GameObject gameManager;

        // UI that shows if it's the player's turn.
        [SerializeField]
        private GameObject playerTurn;

        // UI that show if it's the opponent's turn.
        [SerializeField]
        private GameObject opponentTurn;

        /// <summary>
        /// Check button click.
        /// </summary>
        public void ClickButton()
        {
            string support = piece.GetComponent<InputField>().text;
            int convertPeca = -1;
            int convertSlot = -1;

            if (int.TryParse(support, out convertPeca))
            {
                support = slot.GetComponent<InputField>().text;

                if (int.TryParse(support, out convertSlot))
                {
                    // hurray
                    gameManager.GetComponent<UnityGame>().Piece = convertPeca;
                    gameManager.GetComponent<UnityGame>().Slot = convertSlot;
                    gameManager.GetComponent<UnityGame>().IsPlayed = true;
                    piece.text = string.Empty;
                    slot.text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Method that is called before the game starts.
        /// </summary>
        private void Awake()
        {
            playerTurn.SetActive(false);
            opponentTurn.SetActive(false);
        }

        /// <summary>
        /// Method that is called every frame.
        /// </summary>
        private void Update()
        {
            if (gameManager.GetComponent<UnityGame>().IsPlayer)
            {
                opponentTurn.SetActive(false);
                playerTurn.SetActive(true);
            }
            else if (gameManager.GetComponent<UnityGame>().IsOpponent)
            {
                playerTurn.SetActive(false);
                opponentTurn.SetActive(true);
            }
        }
    }
}
