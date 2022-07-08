using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameBoard : MonoBehaviour
{
//DONE: Move the blocks, left to right.
//DONE: Create a bool method for checking if blocks in the area or not.
//DONE: Create a timer based difficulty.
//DONE: Drop the block every 1 second, one pixel.
//DONE: Create a timer and pause the game.
//DONE: Create a grid data.
//TODO: Rotate the blocks. Create a conditions for this. When rotating the block pieces are outside the area, find how far away to the area and move back the piece into the area.
//TODO: When pressing a button (upArrow), place the block instant.
//TODO: Create a lock the block method when collide the other pieces or bottom of the area.
//TODO: Create a method for clear full lines.
//TODO: Create a method move the pieces one pixel down.
//TODO: Create a method move all above pieces to down.
//TODO: Create a score system. When lines cleared player gets score.
//TODO: Score base challenge, when player gets the X score then increase the fall speed, increment level(Show this to the screen. LVL 1 etc.).
//TODO: If pieces collide with other pieces top of the screen - Game Over.
//TODO: When starting a game, player has to enter a name or end of the game.
//TODO: Create a score board.
//TODO: Create a main menu screen. (New, Load, Leaderboard, Settings, Exit)
//TODO: Implement the JSON helper class.
//TODO: Display high score inside the right area.
//TODO: If player not save and want to quit the game. Ask the player if really want's to quit.

    [SerializeField] private float difficulty;

    private float _lastFall;
    private static bool _gameIsPaused;
    private GameObject _block;

    private Transform[,] _gridData = new Transform[Width, Height];

    public float time;
    
    public static int Width = 10;
    public static int Height = 20;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        time = Time.time; //Timer for UI
        _block = GameObject.FindWithTag("Piece");
        
        Move(_block);
        CheckPiecePos(_block.transform);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameIsPaused = !_gameIsPaused;
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = _gameIsPaused ? 0 : 1;
    }


    public bool InsideBorder(Vector2 pos)
    {
        return (int)pos.x < Width && (int)pos.x >= 0 && (int)pos.y >= 0;
    }

    private bool CheckPiecePos(Transform obj)
    {
        foreach (Transform child in obj)
        {
            Vector2 v = RoundedVector2(child.position);
            if (!InsideBorder(v))
            {
                return false;
            }
        }

        return true;
    }

    private Vector2 RoundedVector2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    private void Move(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            obj.transform.position += new Vector3(-1, 0, 0);

            if (!CheckPiecePos(obj.transform))
            {
                obj.transform.position += new Vector3(1, 0, 0);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            obj.transform.position += new Vector3(1, 0, 0);
            
            if (!CheckPiecePos(obj.transform))
            {
                obj.transform.position += new Vector3(-1, 0, 0);
            }
        }
        
        else if (Input.GetKey(KeyCode.DownArrow) && Time.time - _lastFall > 0.1f || Time.time - _lastFall >= difficulty)
        {
            obj.transform.position += new Vector3(0, -1, 0);
            
            if (!CheckPiecePos(obj.transform))
            {
                obj.transform.position += new Vector3(0, 1, 0);
            }
            
            _lastFall = Time.time;
        }
    }
}
