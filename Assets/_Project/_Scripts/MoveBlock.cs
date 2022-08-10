using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private SpawnManager _spawnManager;
    private void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        GameBoard.GameOver(transform);
    }

    private void Update()
    {
        if (!GameBoard.GameIsPaused)
        {
            Move(transform.gameObject);
            Rotate.RotatePiece(transform.gameObject); 
        }
    }
    

    public static bool InsideBorder(Vector2 pos)
    {
        return (int)pos.x < GridSystem.Width && (int)pos.x >= 0 && (int)pos.y >= 0;
    }

    //Checking child objects positions if child objects are inside the border or not.
    public static bool CheckPiecePos(Transform obj)
    {
        foreach (Transform child in obj)
        {
            Vector2 v = RoundedVector2(child.position);
            if (!InsideBorder(v))
            {
                return false;
            }

            if (GridSystem._gridData[(int) v.x, (int) v.y] != null &&
                GridSystem._gridData[(int) v.x, (int) v.y].parent != obj.transform)
            {
                return false;
            }
        }
        return true;
    }

    //Round the objects positions for consistency.
    public static Vector2 RoundedVector2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }
    
    
    public void Move(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            obj.transform.position += new Vector3(-1, 0, 0);

            if (CheckPiecePos(obj.transform))
            {
                GridSystem.UpdateGrid(obj.transform);
            }
            else
            {
                obj.transform.position += new Vector3(1, 0, 0);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            obj.transform.position += new Vector3(1, 0, 0);
            
            if (CheckPiecePos(obj.transform))
            {
                GridSystem.UpdateGrid(obj.transform);
            }
            else
            {
                obj.transform.position += new Vector3(-1, 0, 0);
            }
        }
        
        else if (Time.time - GameBoard.LastFall >= GameBoard.Difficulty)
        {
            obj.transform.position += new Vector3(0, -1, 0);
            
            if (CheckPiecePos(obj.transform))
            {
                GridSystem.UpdateGrid(obj.transform);
            }
            else
            {
                obj.transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<SpawnManager>().SpawnShape(_spawnManager.transform.position, _spawnManager.nextBlock);
                Destroy(_spawnManager.nextBlock);
                _spawnManager.nextBlock = _spawnManager.SpawnNextShape();

                enabled = false;

                GridSystem.ClearLine();
            }
            
            
            GameBoard.LastFall = Time.time;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Time.time - GameBoard.LastFall > 0.1f)
        {
            obj.transform.position += new Vector3(0, -1, 0);
            
            GameBoard.Score += 1;

            if (CheckPiecePos(obj.transform))
            {
                GridSystem.UpdateGrid(obj.transform);
            }
            else
            {
                obj.transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<SpawnManager>().SpawnShape(_spawnManager.transform.position, _spawnManager.nextBlock);
                Destroy(_spawnManager.nextBlock);
                _spawnManager.nextBlock = _spawnManager.SpawnNextShape();
                
                enabled = false;
                
                GridSystem.ClearLine();
            }
            
            
            GameBoard.LastFall = Time.time;
        }
        
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time - GameBoard.LastFall > 0f)
        {
            while (CheckPiecePos(obj.transform))
            {
                GridSystem.UpdateGrid(obj.transform);
                
                GameBoard.Score += 2;
                
                obj.transform.position += new Vector3(0, -1, 0);
            }
            
            obj.transform.position += new Vector3(0, 1, 0);

            FindObjectOfType<SpawnManager>().SpawnShape(_spawnManager.transform.position, _spawnManager.nextBlock);
            Destroy(_spawnManager.nextBlock);
            _spawnManager.nextBlock = _spawnManager.SpawnNextShape();

            enabled = false;
                
            GridSystem.ClearLine();
            
            GameBoard.LastFall = Time.time;

        }
    }
    
}
