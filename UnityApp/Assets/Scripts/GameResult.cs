using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField] private ResultSO resultSO;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject opponentUI;

    private void Awake()
    {
        playerUI.SetActive(false);
        opponentUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(resultSO.HasPlayerWon)
        {
            // mostrar UI de vitoria do jogador
            playerUI.SetActive(true);
        }
        else if(!resultSO.HasPlayerWon)
        {
            // mostrar UI de vitoria do oponente
            opponentUI.SetActive(true);
        }
    }
}
