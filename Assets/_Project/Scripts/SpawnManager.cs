using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> shapes;


    private void Start()
    {
        SpawnNextShape();
    }


    private void SpawnNextShape()
    {
        int i = Random.Range(0, shapes.Count);

        Instantiate(shapes[i], transform.position, Quaternion.identity);
    }
}
