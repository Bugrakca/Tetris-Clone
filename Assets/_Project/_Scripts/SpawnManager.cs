using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    //TODO: Create a variable for random spawning object. Starting the game spawn that object and assing next random object to that variable. 
    //TODO: Show the next block to the player.
    
    [SerializeField] private List<GameObject> shapes;


    private void Start()
    {
        SpawnNextShape();
    }


    private void SpawnNextShape()
    {
        int i = Random.Range(0, shapes.Count);

        //TODO: Create an if statement here, when the block cannot move anymore spawn the next block.
        Instantiate(shapes[i], transform.position, Quaternion.identity);
    }
}
