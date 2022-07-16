using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
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
    
    
    
}
