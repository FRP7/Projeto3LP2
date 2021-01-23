using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class the controls the UI in the SetGame scene.
/// </summary>
public class SetGameUI : MonoBehaviour
{
    // Button to choose black.
    [SerializeField] private Button blackOption;

    // Button to choose white.
    [SerializeField] private Button whiteOption;

    // Access the ColorSO ScriptableObject.
    [SerializeField] private ColorSO colorspec;

    /// <summary>
    /// Choose white when clicked and begin the game.
    /// </summary>
    public void ChooseWhite()
    {
        colorspec.IsPlayerWhite = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Choose black when clicked and begin the game.
    /// </summary>
    public void ChooseBlack()
    {
        colorspec.IsPlayerWhite = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
