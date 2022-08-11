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
    
    public static MainMenuController Instance;

    private void Awake()
    {
        if (Instance == null) {
            //First run, set the instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
 
        } else if (Instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
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
    
    public void BestScores()
    {
        SceneManager.LoadScene("ScoreTable");
    }
}