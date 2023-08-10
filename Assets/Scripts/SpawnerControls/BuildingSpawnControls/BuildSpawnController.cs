using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildSpawnController : MonoBehaviour
{
    private float _nextSpawnTime;
    [SerializeField] private float _spawnEveryXSeconds;
    public Transform BuildSpawnPoints;
    public GameObject[] SpawnableObjects;

    private void FixedUpdate()
    {
        SpawnTimeController2();
    }

    private void SpawnTimeController2()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime += _spawnEveryXSeconds;
            BuildSpawner(SpawnableObjects[RandomSpawnableObjectPicker()], BuildSpawnPoints);
        }
    }

    private void BuildSpawner(GameObject objectToSpawn, Transform newSpawnTransform)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, newSpawnTransform.position, objectToSpawn.transform.rotation);
    }

    private int RandomSpawnableObjectPicker()
    {
        return Random.Range(0, SpawnableObjects.Length);
    }
}