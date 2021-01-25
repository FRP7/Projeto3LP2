using UnityEngine;

namespace UnityApp
{
    /// <summary>
    /// Class where the game's result is shown.
    /// </summary>
    public class GameResult : MonoBehaviour
    {
        [SerializeField]
        private ResultSO resultSO;

        [SerializeField]
        private GameObject playerUI;

        [SerializeField]
        private GameObject opponentUI;

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
                // mostrar UI de vitoria do jogador
                playerUI.SetActive(true);
            }
            else if (!resultSO.HasPlayerWon)
            {
                // mostrar UI de vitoria do oponente
                opponentUI.SetActive(true);
            }
        }
    }
}