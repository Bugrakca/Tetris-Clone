using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public static void RotatePiece(GameObject obj)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            obj.transform.Rotate(Vector3.forward, -90f);
            
            if (MoveBlock.CheckPiecePos(obj.transform))
            { 
                GridSystem.UpdateGrid(obj.transform);
            }
            else
            {
                obj.transform.Rotate(Vector3.forward, 90f);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.E))
        {
            obj.transform.Rotate(Vector3.forward, 90f);
            
            if (MoveBlock.CheckPiecePos(obj.transform))
            { 
                GridSystem.UpdateGrid(obj.transform);
            }
            else
            {
                obj.transform.Rotate(Vector3.forward, -90f);
            }
        }
    }
}
