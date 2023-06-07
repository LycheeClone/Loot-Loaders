using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildingspawnerDeneme : MonoBehaviour
{
    private float _nextSpawnTime;
    [SerializeField] private float _spawnEveryXSeconds;
    public Transform[] BuildSpawnPoints;
    public GameObject[] SpawnableObjects;

    private void FixedUpdate()
    {
        SpawnTimeController();
    }

    private void SpawnTimeController()
    {
        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime += _spawnEveryXSeconds;
            SpawnObjectWithCollisionCheck();
        }
    }

    private void SpawnObjectWithCollisionCheck()
    {
        GameObject objectToSpawn = SpawnableObjects[RandomSpawnableObjectPicker()];
        Transform newSpawnTransform = BuildSpawnPoints[RandomSpawnPositionPicker()];

        Collider[] colliders = Physics.OverlapBox(newSpawnTransform.position, objectToSpawn.transform.localScale / 2f);
        if (colliders.Length > 0)
        {
            // Spawn point is occupied, find a new one
            bool foundSpawnPoint = false;
            for (int i = 0; i < BuildSpawnPoints.Length; i++)
            {
                colliders = Physics.OverlapBox(BuildSpawnPoints[i].position, objectToSpawn.transform.localScale / 2f);
                if (colliders.Length == 0)
                {
                    // Found an empty spawn point
                    newSpawnTransform = BuildSpawnPoints[i];
                    foundSpawnPoint = true;
                    break;
                }
            }

            if (!foundSpawnPoint)
            {
                // Couldn't find an empty spawn point, abort spawning
                Debug.Log("All spawn points are occupied. Cannot spawn object.");
                return;
            }
        }

        TreeSpawner(objectToSpawn, newSpawnTransform);
    }

    private void TreeSpawner(GameObject objectToSpawn, Transform newSpawnTransform)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, newSpawnTransform.position, objectToSpawn.transform.rotation);
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
