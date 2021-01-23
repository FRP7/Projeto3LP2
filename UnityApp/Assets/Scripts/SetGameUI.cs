using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SetGameUI : MonoBehaviour
{
    [SerializeField] private Button blackOption;
    [SerializeField] private Button whiteOption;
    [SerializeField] private ColorSO colorspec;

    public void ChooseWhite()
    {
        colorspec.IsPlayerWhite = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChooseBlack()
    {
        colorspec.IsPlayerWhite = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
