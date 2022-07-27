using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameBoard : MonoBehaviour
{
    public static float Difficulty = 0.8f;
    public static float LastFall;
    public static int Score;

    public TMP_Text scoreText; 
    public TMP_Text pauseText; 
    public TMP_Text levelText; 
    
    private static bool _gameIsPaused;
    public static readonly List<int> ClearedLines = new();
    
    public float time;
    
    private GameObject _block;
    
    
    private void Update()
    {
        time = Time.time; //Timer for UI
        PauseGame();
        scoreText.text = $"Score: {Score}";
        levelText.text = $"Level: {GridSystem.Level}";
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


    public static void GameOver(Transform obj)
    {
        if (!MoveBlock.CheckPiecePos(obj.transform))
        {
            Debug.Log("Game Over!");
            Destroy(obj.gameObject);
        }
    }

    public static void DifficultyChange()
    {
        if (SumOfClearedLines() % 2 == 0)
        {
            Difficulty -= 0.08f;
            GridSystem.LineCount = 0;
            Debug.Log(GridSystem.LineCount);
        }
        // else if (GridSystem.LineCount >= GridSystem.Level * 5)
        // {
        //     Difficulty -= 0.08f;
        // }
        
    }

    private static int SumOfClearedLines()
    {
        int answer = 0;

        foreach (var value in ClearedLines)
        {
            answer += value;
        }
        
        return answer;
    }
}
