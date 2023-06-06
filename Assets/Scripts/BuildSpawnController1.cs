using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildSpawnController1 : MonoBehaviour
{
    private float _nextSpawnTime;
    [SerializeField] private float _spawnEveryXSeconds;
    public Transform[] BuildSpawnPoints;
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
        TreeSpawner(SpawnableObjects[RandomSpawnableObjectPicker()], BuildSpawnPoints[RandomSpawnPositionPicker()]);
    }
    private void SpawnTimeController2()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime += _spawnEveryXSeconds;
            TreeSpawner(SpawnableObjects[RandomSpawnableObjectPicker()], BuildSpawnPoints[RandomSpawnPositionPicker()]);
        }
    }

    private void TreeSpawner(GameObject objectToSpawn, Transform newSpawnTransform)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, newSpawnTransform.position, objectToSpawn.transform.rotation);
        //spawnedObject.transform.Rotate(Vector3.up, 180f);
    }

    private int RandomSpawnPositionPicker()
    {
        return Random.Range(0, BuildSpawnPoints.Length);
    }

    private int RandomSpawnableObjectPicker()
    {
        return Random.Range(0, SpawnableObjects.Length);
    }
}