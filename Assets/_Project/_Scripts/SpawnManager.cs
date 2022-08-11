using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip placeSound;

    private bool placed;
    
    [SerializeField] private List<GameObject> shapes;

    private GameObject _nextBlockSpawnPos;
    
    public GameObject nextBlock;


    private void Awake()
    {
        _nextBlockSpawnPos = GameObject.FindWithTag("NextObjPos");
        SpawnShape(transform.position, shapes[Random.Range(0, 7)]);
        nextBlock = SpawnNextShape();
    }

    public GameObject SpawnNextShape()
    {
        GridSystem.UpdateGrid(_nextBlockSpawnPos.transform);
        GameObject nextObject = SpawnShape(_nextBlockSpawnPos.transform.position, shapes[Random.Range(0, 7)]);
        Destroy(nextObject.GetComponent<MoveBlock>());
        if (placed)
        {
            source.PlayOneShot(placeSound);
        }

        placed = true;

        return nextObject;
    }

    public GameObject SpawnShape(Vector3 gameObj, GameObject shape)
    {
        GameObject currentObject = Instantiate(shape, gameObj, Quaternion.identity);

        currentObject.AddComponent<MoveBlock>();

        return currentObject;
    }
    
}
