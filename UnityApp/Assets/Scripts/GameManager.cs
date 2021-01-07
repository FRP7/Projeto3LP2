using System;
using UnityEngine;
using Common;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject[] slots;

    private void Awake()
    {
        gameState = new GameState();
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameState.Start();
        SetColor();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void SetColor()
    {
        if(ServiceLocator.GetService<Colors>() == Colors.Black)
        {
            for(int i = 0; i < 5; i++)
            {
                slots[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
            for (int i = 6; i < 12; i++)
            {
                slots[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            slots[12].GetComponent<SpriteRenderer>().color = Color.grey;
        }

        if (ServiceLocator.GetService<Colors>() == Colors.White)
        {
            for (int i = 0; i < 5; i++)
            {
                slots[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
            for (int i = 6; i < 12; i++)
            {
                slots[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
            slots[12].GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }
}
