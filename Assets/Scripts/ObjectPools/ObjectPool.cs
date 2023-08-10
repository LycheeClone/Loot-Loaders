using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public int poolSize = 10;
    public GameObject[] treePrefabs;
    public GameObject[] buildingPrefabs;
    public GameObject[] carPrefabs;

    private List<GameObject>[] treeObjectPool;
    private List<GameObject>[] buildingObjectPool;
    private List<GameObject>[] carObjectPool;

    void Start()
    {
        // Ağaçlar için object pool oluşturma
        treeObjectPool = new List<GameObject>[treePrefabs.Length];
        for (int i = 0; i < treePrefabs.Length; i++)
        {
            treeObjectPool[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(treePrefabs[i], transform);
                obj.SetActive(false);
                treeObjectPool[i].Add(obj);
            }
        }

        // Binalar için object pool oluşturma
        buildingObjectPool = new List<GameObject>[buildingPrefabs.Length];
        for (int i = 0; i < buildingPrefabs.Length; i++)
        {
            buildingObjectPool[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(buildingPrefabs[i], transform);
                obj.SetActive(false);
                buildingObjectPool[i].Add(obj);
            }
        }

        // Arabalar için object pool oluşturma
        carObjectPool = new List<GameObject>[carPrefabs.Length];
        for (int i = 0; i < carPrefabs.Length; i++)
        {
            carObjectPool[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(carPrefabs[i], transform);
                obj.SetActive(false);
                carObjectPool[i].Add(obj);
            }
        }
    }

    // Ağaç prefab'larını döndüren method
    public GameObject GetTreePrefab(int index)
    {
        for (int i = 0; i < treeObjectPool[index].Count; i++)
        {
            if (!treeObjectPool[index][i].activeInHierarchy)
            {
                treeObjectPool[index][i].SetActive(true);
                return treeObjectPool[index][i];
            }
        }

        GameObject obj = Instantiate(treePrefabs[index], transform);
        obj.SetActive(false);
        treeObjectPool[index].Add(obj);
        return obj;
    }

    // Bina prefab'larını döndüren method
    public GameObject GetBuildingPrefab(int index)
    {
        for (int i = 0; i < buildingObjectPool[index].Count; i++)
        {
            if (!buildingObjectPool[index][i].activeInHierarchy)
            {
                buildingObjectPool[index][i].SetActive(true);
                return buildingObjectPool[index][i];
            }
        }

        GameObject obj = Instantiate(buildingPrefabs[index], transform);
        obj.SetActive(false);
        buildingObjectPool[index].Add(obj);
        return obj;
    }

    // Araba prefab'larını döndüren method
    public GameObject GetCarPrefab(int index)
    {
        for (int i = 0; i < carObjectPool[index].Count; i++)
        {
            if (!carObjectPool[index][i].activeInHierarchy)
            {
                carObjectPool[index][i].SetActive(true);
                return carObjectPool[index][i];
            }
        }

        GameObject obj = Instantiate(carPrefabs[index], transform);
        obj.SetActive(false);
        carObjectPool[index].Add(obj);
        return obj;
    }

    // Rastgele bir prefab seçmek için kullanılan method
    public GameObject GetRandomPrefab()
    {
        int type = Random.Range(0, 3); // 0: ağaç, 1: bina, 2: araba
        int index = 0;
        if (type == 0)
        {
            index = Random.Range(0, treePrefabs.Length);
            return GetTreePrefab(index);
        }
        else if (type == 1)
        {
            index = Random.Range(0, buildingPrefabs.Length);
            return GetBuildingPrefab(index);
        }
        else
        {
            index = Random.Range(0, carPrefabs.Length);
            return GetCarPrefab(index);
        }
    }
}