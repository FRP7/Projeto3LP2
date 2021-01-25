using UnityEngine;

namespace UnityApp
{
    /// <summary>
    /// Class where the game's result is shown.
    /// </summary>
    public class GameResult : MonoBehaviour
    {
        // The result's scriptable object.
        [SerializeField]
        private ResultSO resultSO;

        // The player UI.
        [SerializeField]
        private GameObject playerUI;

        // The opponent UI.
        [SerializeField]
        private GameObject opponentUI;

        // Awake is called before the game starts.
        private void Awake()
        {
            playerUI.SetActive(false);
            opponentUI.SetActive(false);
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (resultSO.HasPlayerWon)
            {
                // Show the victory UI of the player.
                playerUI.SetActive(true);
            }
            else if (!resultSO.HasPlayerWon)
            {
                // Show the victory UI of the opponent.
                opponentUI.SetActive(true);
            }
        }
    }
}