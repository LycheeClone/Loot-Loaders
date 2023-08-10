using System.Collections.Generic;
using UnityEngine;

namespace ObjectPools
{
    public class BuildingPool : MonoBehaviour
    {
        public int poolSize = 10;
        public GameObject[] prefabList;
        private List<GameObject>[] objectPool;

        void Start()
        {
            objectPool = new List<GameObject>[prefabList.Length];
            for (int i = 0; i < prefabList.Length; i++)
            {
                objectPool[i] = new List<GameObject>();
                for (int j = 0; j < poolSize; j++)
                {
                    GameObject obj = Instantiate(prefabList[i], transform);
                    obj.SetActive(false);
                    objectPool[i].Add(obj);
                }
            }
        }

        public GameObject GetTreePrefab()
        {
            for (int i = 0; i < objectPool[0].Count; i++)
            {
                if (!objectPool[0][i].activeInHierarchy)
                {
                    objectPool[0][i].SetActive(true);
                    return objectPool[0][i];
                }
            }
            GameObject obj = Instantiate(prefabList[0], transform);
            obj.SetActive(false);
            objectPool[0].Add(obj);
            return obj;
        }

        public GameObject GetBuildingPrefab()
        {
            for (int i = 0; i < objectPool[1].Count; i++)
            {
                if (!objectPool[1][i].activeInHierarchy)
                {
                    objectPool[1][i].SetActive(true);
                    return objectPool[1][i];
                }
            }
            GameObject obj = Instantiate(prefabList[1], transform);
            obj.SetActive(false);
            objectPool[1].Add(obj);
            return obj;
        }

        public GameObject GetCarPrefab()
        {
            for (int i = 0; i < objectPool[2].Count; i++)
            {
                if (!objectPool[2][i].activeInHierarchy)
                {
                    objectPool[2][i].SetActive(true);
                    return objectPool[2][i];
                }
            }
            GameObject obj = Instantiate(prefabList[2], transform);
            obj.SetActive(false);
            objectPool[2].Add(obj);
            return obj;
        }

        public GameObject GetRandomPrefab()
        {
            int index = Random.Range(0, prefabList.Length);
            if(index == 0)
                return GetTreePrefab();
            else if(index == 1)
                return GetBuildingPrefab();
            else
                return GetCarPrefab();
        }

    }

    public class ExampleScript : MonoBehaviour
    {
        public BuildingPool objectPool;

        void Start()
        {
            GameObject obj = objectPool.GetRandomPrefab();
            obj.transform.position = transform.position;
            obj.SetActive(true);
        }
    }
}