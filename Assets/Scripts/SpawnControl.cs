using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public Transform[] SpawnPositions;
    private float _nexSpawnTime = 0f;
    public float spawnEveryXSeconds;
    [SerializeField] private GameObject[] spawnableObjects;
    private void FixedUpdate()
    {
        SpawnTimeControl();

    }

    private void SpawnTimeControl()
    {
        if (Time.time> _nexSpawnTime)
        {
            _nexSpawnTime += spawnEveryXSeconds;
            CarSpawner(spawnableObjects[SpawnPicker()],SpawnPositions[RandomSpawnNumber()]);
        }
    }

    private void CarSpawner(GameObject objectToSpawn, Transform newTransform)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, newTransform.position, newTransform.rotation);
        spawnedObject.transform.Rotate(Vector3.up, 180f); // Nesneyi y ekseninde 180 derece çevir
    }
    
    private int RandomSpawnNumber()
    {
        return Random.Range(0, SpawnPositions.Length);
    }

    private int SpawnPicker()
    {
        return Random.Range(0, spawnableObjects.Length);
    }
}
