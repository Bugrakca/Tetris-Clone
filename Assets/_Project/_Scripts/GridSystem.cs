using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public static int Level = 1;
    public static int LineCount;
    
    public static int Width = 10;
    public static int Height = 20;

    public static Transform[,] _gridData = new Transform[Width, Height];

    public static void UpdateGrid(Transform obj)
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (_gridData[x, y] != null)
                    if (_gridData[x, y].parent == obj)
                        _gridData[x, y] = null;
            }
        }

        foreach (Transform child in obj)
        {
            Vector2 v = MoveBlock.RoundedVector2(child.position);

            _gridData[(int) v.x, (int) v.y] = child;
        }
    }
    
    public static void ClearLine()
    {
        int count = 0;
        
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (!IsRowFull(y))
                {
                    break;
                }
                
                DeleteRow(y);
                DecreaseAboveRows(y);
                GameBoard.DifficultyChange();
                count++;

                if (count == 1)
                {
                    Level++;
                }
                
                else
                {
                    Level += count % 5;
                }
                
                if (count % 5 == 0)
                {
                    
                    Level += count / 5;
                }
            }
        }
        GameBoard.ClearedLines.Add(count);
        AddScore(count, Level);
    }

    private static bool IsRowFull(int y)
    {
        for (int x = 0; x < Width; x++)
        {
            if (_gridData[x, y] == null)
                return false;
        }

        return true;
    }

    private static void DeleteRow(int y)
    {
        for (int x = 0; x < Width; x++)
        {
            Destroy(_gridData[x, y].gameObject);
            _gridData[x, y] = null;
        }
    }

    private static void AddScore(int clearedLines, int level)
    {
        if (clearedLines > 1)
            GameBoard.Score += 2 * (level + clearedLines * 100);
        else
            GameBoard.Score += (level + clearedLines) * 100;
    }

    private static void DecreaseRow(int y)
    {
        for (int x = 0; x < Width; x++)
        {
            if (_gridData[x, y] != null)
            {
                _gridData[x, y - 1] = _gridData[x, y];
                _gridData[x, y] = null;
                _gridData[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    private static void DecreaseAboveRows(int y)
    {
        for (int i = y; i < Height; i++)
        {
            DecreaseRow(i);
        }
    }
}
