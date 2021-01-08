using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class UnityGame : MonoBehaviour
{
    private GameState gameState;
    [SerializeField] private GameObject[] pieces;

    private void Awake()
    {
        gameState = new GameState();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameState.Start();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        gameState.Update();
    }

    private void SetColor()
    {
        for(int i = 0; i < pieces.Length; i++)
        {
            // as peças do jogador ficam pretas.
            if(gameState.GetSlotTypes[i] == SlotTypes.Black)
            {
                pieces[i].GetComponent<SpriteRenderer>().color = Color.black;
            }

            // as peças da ai ficam brancas.
            if (gameState.GetSlotTypes[i] == SlotTypes.White)
            {
                pieces[i].GetComponent<SpriteRenderer>().color = Color.white;
            }

            // as peças vazias ficam brancas.
            if (gameState.GetSlotTypes[i] == SlotTypes.Grey)
            {
                pieces[i].GetComponent<SpriteRenderer>().color = Color.grey;
            }
        }
    }
}
