using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityApp
{
    /// <summary>
    /// Class where the UI of the Main Menu is controlled.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Method to load the game scene.
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// Method to load the menu scene.
        /// </summary>
        public void Menu()
        {
            SceneManager.LoadScene(0);
        }

        /// <summary>
        /// Method to exit the game.
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
