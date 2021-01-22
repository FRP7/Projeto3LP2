using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private InputField peca;
    [SerializeField] private InputField slot;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject PlayerTurn;
    [SerializeField] private GameObject OpponentTurn;

    private void Awake()
    {
        PlayerTurn.SetActive(false);
        OpponentTurn.SetActive(false);
    }

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

    public void ClickButton()
    {
        string support = peca.GetComponent<InputField>().text;
        int convertPeca = -1;
        int convertSlot = -1;

        if (Int32.TryParse(support, out convertPeca))
        {
            support = slot.GetComponent<InputField>().text;

            if (Int32.TryParse(support, out convertSlot))
            {
                // hurray
                gameManager.GetComponent<UnityGame>().Peca = convertPeca;
                gameManager.GetComponent<UnityGame>().Slot = convertSlot;
                gameManager.GetComponent<UnityGame>().IsPlayed = true;
                peca.text = "";
                slot.text = "";
            } 
        }
    }
}
