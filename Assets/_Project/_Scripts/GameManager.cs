using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string highPlayerName;
    public int highScore;

    public List<UserData> userData = new ();
    
    public int score1;
    public string player1;
    public int score2;
    public string player2;
    public int score3;
    public string player3;
    public int score4;
    public string player4;
    public int score5;
    public string player5;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadUserData();
    }

    public void SaveUserData()
    {
        userData.Add(new UserData(highPlayerName, GameBoard.Score));
        FileHandler.SaveToJson(userData, "savefile.json");
    }

    public void LoadUserData()
    {
        userData = FileHandler.ReadListFromJson<UserData>("savefile.json");

        foreach (var user in userData)
        {
            if (user.highScore > highScore)
            {
                highPlayerName = user.highPlayerName;
                highScore = user.highScore;
                score1 = user.highScore;
                player1 = user.highPlayerName;
            }

            // Maybe this is not the best way but it defines the best high scores.
            if (user.highScore > score2 && user.highScore < score1)
            {
                score2 = user.highScore;
                player2 = user.highPlayerName;
            }

            if (user.highScore > score3 && user.highScore < score2)
            {
                score3 = user.highScore;
                player3 = user.highPlayerName;
            }

            if (user.highScore > score4 && user.highScore < score3)
            {
                score4 = user.highScore;
                player4 = user.highPlayerName;
            }

            if (user.highScore > score5 && user.highScore < score4)
            {
                score5 = user.highScore;
                player5 = user.highPlayerName;
            }
        }
    }


    [Serializable]
    public class UserData
    {
        public string highPlayerName;
        public int highScore;

        public UserData(string name, int score)
        {
            highPlayerName = name;
            highScore = score;
        }
    }
}
