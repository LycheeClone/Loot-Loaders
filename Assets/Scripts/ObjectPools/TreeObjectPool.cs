using System.Collections.Generic;
using UnityEngine;

namespace ObjectPools
{
    public class TreeObjectPool : MonoBehaviour
    {
        public int poolSize = 10;
        public GameObject treePrefab;
        private List<GameObject> treeObjectPool;

        void Start()
        {
            treeObjectPool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(treePrefab, transform);
                obj.SetActive(false);
                treeObjectPool.Add(obj);
            }
        }

        public GameObject GetTree()
        {
            for (int i = 0; i < treeObjectPool.Count; i++)
            {
                if (!treeObjectPool[i].activeInHierarchy)
                {
                    treeObjectPool[i].SetActive(true);
                    return treeObjectPool[i];
                }
            }
            GameObject obj = Instantiate(treePrefab, transform);
            obj.SetActive(false);
            treeObjectPool.Add(obj);
            return obj;
        }
    }
}