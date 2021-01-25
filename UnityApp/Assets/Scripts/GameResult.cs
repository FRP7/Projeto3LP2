using UnityEngine;

public class GameResult : MonoBehaviour
{
    //  Access the results ScriptableObject.
    [SerializeField] private ResultSO resultSO;

    // Access the player's UI.
    [SerializeField] private GameObject playerUI;

    // Access the opponent's UI.
    [SerializeField] private GameObject opponentUI;

    private void Awake()
    {
        playerUI.SetActive(false);
        opponentUI.SetActive(false);
    }

    // Start is called before the first frame update
    private void Start()
    {
        if(resultSO.HasPlayerWon)
        {
            // Show the victory UI of the player.
            playerUI.SetActive(true);
        }
        else if(!resultSO.HasPlayerWon)
        {
            // Show the victory UI of the opponent.
            opponentUI.SetActive(true);
        }
    }
}
