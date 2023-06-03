using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeSpawnController : MonoBehaviour
{
    private float _nextSpawnTime;
    [SerializeField] private float _spawnEveryXSeconds;
    public Transform[] TreeSpawnPoints;
    public GameObject[] SpawnableObjects;


    private void Start()
    {
        //InvokeRepeating("SpawnTimeController", 0f, 3f);
    }

    private void FixedUpdate()
    {
        SpawnTimeController2();
        //InvokeRepeating("SpawnTimeController",0f,3f);
    }


    private void SpawnTimeController()
    {
        TreeSpawner(SpawnableObjects[RandomSpawnableObjectPicker()], TreeSpawnPoints[RandomSpawnPositionPicker()]);
    }
    private void SpawnTimeController2()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime += _spawnEveryXSeconds;
            TreeSpawner(SpawnableObjects[RandomSpawnableObjectPicker()], TreeSpawnPoints[RandomSpawnPositionPicker()]);
        }
    }

    private void TreeSpawner(GameObject objectToSpawn, Transform newSpawnTransform)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, newSpawnTransform.position, newSpawnTransform.rotation);
        spawnedObject.transform.Rotate(Vector3.up, 180f);
    }

    private int RandomSpawnPositionPicker()
    {
        return Random.Range(0, TreeSpawnPoints.Length);
    }

    private int RandomSpawnableObjectPicker()
    {
        return Random.Range(0, SpawnableObjects.Length);
    }
}