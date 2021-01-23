using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Class where the game's UI is controlled.
/// </summary>
public class UIController : MonoBehaviour
{
    // InputField that gets the piece's number.
    [SerializeField] private InputField piece;

    // InputField that gets the slot's number.
    [SerializeField] private InputField slot;

    // Play button.
    [SerializeField] private Button playButton;

    // GameManager GameObject.
    [SerializeField] private GameObject gameManager;

    // UI that shows if it's the player's turn.
    [SerializeField] private GameObject PlayerTurn;

    // UI that show if it's the opponent's turn.
    [SerializeField] private GameObject OpponentTurn;

    /// <summary>
    /// Method that is called before the game starts.
    /// </summary>
    private void Awake()
    {
        PlayerTurn.SetActive(false);
        OpponentTurn.SetActive(false);
    }

    /// <summary>
    /// Method that is called every frame.
    /// </summary>
    private void Update()
    {
        if(gameManager.GetComponent<UnityGame>().IsPlayer)
        {
            OpponentTurn.SetActive(false);
            PlayerTurn.SetActive(true);
        } 
        else if(gameManager.GetComponent<UnityGame>().IsOpponent)
        {
            PlayerTurn.SetActive(false);
            OpponentTurn.SetActive(true);
        }
    }

    /// <summary>
    /// Check button click.
    /// </summary>
    public void ClickButton()
    {
        string support = piece.GetComponent<InputField>().text;
        int convertPeca = -1;
        int convertSlot = -1;

        if (Int32.TryParse(support, out convertPeca))
        {
            support = slot.GetComponent<InputField>().text;

            if (Int32.TryParse(support, out convertSlot))
            {
                // hurray
                gameManager.GetComponent<UnityGame>().Piece = convertPeca;
                gameManager.GetComponent<UnityGame>().Slot = convertSlot;
                gameManager.GetComponent<UnityGame>().IsPlayed = true;
                piece.text = "";
                slot.text = "";
            } 
        }
    }
}
