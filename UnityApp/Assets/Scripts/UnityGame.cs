using UnityEngine;
using Common;

public class UnityGame : MonoBehaviour
{
    private GameState gameState;

    [SerializeField] private GameObject[] pieces;

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
            gameState.PlayerType = SlotTypes.White;
        }
        else if(!isPlayerWhite)
        {
            gameState.PlayerType = SlotTypes.Black;
        }
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

            // as peças vazias ficam cinzentas.
            if (gameState.GetSlotTypes[i] == SlotTypes.Grey)
            {
                pieces[i].GetComponent<SpriteRenderer>().color = Color.grey;
            }
        }
    }

    private void AIFirst()
    {
        gameState.Update();
        PlayerPlay();
    }

    private void PlayerFirst()
    {
        PlayerPlay();
        gameState.Update();
    }

    private void PlayerPlay()
    {
        Debug.Log("Jogador joga.");
    }
}
