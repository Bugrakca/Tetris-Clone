#if UNITY_EDITOR
using UnityEditor;
#endif

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    // public TMP_InputField inputName;

    private void Awake()
    {
        GameManager.Instance.LoadUserData();
    }

    // public void SetPlayerName()
    // {
    //     GameManager.Instance.playerName = inputName.text;
    // }
    
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    // public void BestScores()
    // {
    //     SceneManager.LoadScene("HighScores");
    // }
}