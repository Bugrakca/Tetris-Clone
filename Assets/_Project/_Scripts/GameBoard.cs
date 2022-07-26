using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameBoard : MonoBehaviour
{
    public static float Difficulty = 0.9f;
    public static float LastFall;
    public static int Score;

    public TMP_Text scoreText; 
    public TMP_Text pauseText; 
    public TMP_Text speedText; 
    
    private static bool _gameIsPaused;
    
    public float time;
    
    private GameObject _block;
    
    
    private void Update()
    {
        time = Time.time; //Timer for UI
        PauseGame();
        scoreText.text = $"Score: {Score}";
    }
    

    //Assign the Time.timescale 0 or 1 
    private void PauseGame()
    {
        Time.timeScale = _gameIsPaused ? 0 : 1;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameIsPaused = !_gameIsPaused;

            if (_gameIsPaused)
            {
                pauseText.color = Color.black;
                pauseText.fontStyle = FontStyles.Bold;
                pauseText.fontStyle = FontStyles.Underline;
            }

            else
            {
                pauseText.color = Color.gray;
                pauseText.fontStyle = FontStyles.Normal;
                pauseText.fontStyle &= FontStyles.Underline;
            }
        }
        
    }


    private void GameOver(Transform obj)
    {
        
    }
}
