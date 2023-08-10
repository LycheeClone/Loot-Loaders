using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public GameObject[] vehiclePrefabs;
    public float resetPositionZ = -8f;

    private List<GameObject> buildingPool;
    private List<GameObject> vehiclePool;
    public GameObject containerObject;

    private void Start()
    {
        //containerObject = new GameObject("ObjectContainer");

        buildingPool = new List<GameObject>();
        vehiclePool = new List<GameObject>();

        // Bina havuzu
        for (int i = 0; i < buildingPrefabs.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject building = Instantiate(buildingPrefabs[i]);
                building.SetActive(false);
                buildingPool.Add(building);
            }
        }

        // Araç havuzu
        for (int i = 0; i < vehiclePrefabs.Length; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject vehicle = Instantiate(vehiclePrefabs[i]);
                vehicle.SetActive(false);
                vehiclePool.Add(vehicle);
            }
        }

        // Arabaları belirli sürede bir oluştur
        StartCoroutine(CreateVehiclesRoutine());

        // Binaları belirli sürede bir oluştur
        StartCoroutine(CreateBuildingsRoutine());
    }

    private IEnumerator CreateVehiclesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            int randomIndex = Random.Range(0, vehiclePool.Count);
            GameObject selectedVehicle = vehiclePool[randomIndex];
            vehiclePool.RemoveAt(randomIndex);

            selectedVehicle.transform.position = containerObject.transform.position;
            selectedVehicle.SetActive(true);
        }
    }

    private IEnumerator CreateBuildingsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.7f);

            int randomIndex = Random.Range(0, buildingPool.Count);
            GameObject selectedBuilding = buildingPool[randomIndex];
            buildingPool.RemoveAt(randomIndex);

            selectedBuilding.transform.position = containerObject.transform.position;
            selectedBuilding.SetActive(true);
        }
    }

    private void Update()
    {
        foreach (GameObject building in buildingPool)
        {
            if (building.activeInHierarchy && building.transform.position.z <= resetPositionZ)
            {
                building.SetActive(false);
                buildingPool.Add(building);
            }
        }

        foreach (GameObject vehicle in vehiclePool)
        {
            if (vehicle.activeInHierarchy && vehicle.transform.position.z <= resetPositionZ)
            {
                vehicle.SetActive(false);
                vehiclePool.Add(vehicle);
            }
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class ObjectPooling : MonoBehaviour
// {
//     public GameObject[] buildingPrefabs;
//     public GameObject[] vehiclePrefabs;
//
//     private List<GameObject> buildingPool;
//     private List<GameObject> vehiclePool;
//     public GameObject containerObject;
//
//     private void Start()
//     {
//         //containerObject = new GameObject("ObjectContainer");
//
//         buildingPool = new List<GameObject>();
//         vehiclePool = new List<GameObject>();
//
//         // Bina havuzu
//         for (int i = 0; i < buildingPrefabs.Length; i++)
//         {
//             for (int j = 0; j < 10; j++)
//             {
//                 GameObject building = Instantiate(buildingPrefabs[i]);
//                 building.SetActive(false);
//                 buildingPool.Add(building);
//             }
//         }
//
//         // Araç havuzu
//         for (int i = 0; i < vehiclePrefabs.Length; i++)
//         {
//             for (int j = 0; j < 10; j++)
//             {
//                 GameObject vehicle = Instantiate(vehiclePrefabs[i]);
//                 vehicle.SetActive(false);
//                 vehiclePool.Add(vehicle);
//             }
//         }
//
//         // Arabaları belirli sürede bir oluştur
//         StartCoroutine(CreateVehiclesRoutine());
//
//         // Binaları belirli sürede bir oluştur
//         StartCoroutine(CreateBuildingsRoutine());
//     }
//
//     private IEnumerator CreateVehiclesRoutine()
//     {
//         while (true)
//         {
//             yield return new WaitForSeconds(3f);
//
//             int randomIndex = Random.Range(0, vehiclePool.Count);
//             GameObject selectedVehicle = vehiclePool[randomIndex];
//             vehiclePool.RemoveAt(randomIndex);
//
//             selectedVehicle.transform.position = containerObject.transform.position;
//             selectedVehicle.SetActive(true);
//         }
//     }
//
//     private IEnumerator CreateBuildingsRoutine()
//     {
//         while (true)
//         {
//             yield return new WaitForSeconds(4.7f);
//
//             int randomIndex = Random.Range(0, buildingPool.Count);
//             GameObject selectedBuilding = buildingPool[randomIndex];
//             buildingPool.RemoveAt(randomIndex);
//
//             selectedBuilding.transform.position = containerObject.transform.position;
//             selectedBuilding.SetActive(true);
//         }
//     }
// }


// İkinci idare eden using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class ObjectPooling : MonoBehaviour
// {
//     public GameObject[] buildingPrefabs;
//     public GameObject[] vehiclePrefabs;
//
//     public GameObject containerObject;
//
//     private void Start()
//     {
//         //containerObject = new GameObject("ObjectContainer");
//
//         // Arabaları belirli sürede bir oluştur
//         StartCoroutine(CreateVehiclesRoutine());
//
//         // Binaları belirli sürede bir oluştur
//         StartCoroutine(CreateBuildingsRoutine());
//     }
//
//     private IEnumerator CreateVehiclesRoutine()
//     {
//         while (true)
//         {
//             yield return new WaitForSeconds(3f);
//
//             int randomIndex = Random.Range(0, vehiclePrefabs.Length);
//             GameObject selectedVehiclePrefab = vehiclePrefabs[randomIndex];
//             GameObject createdVehicle = Instantiate(selectedVehiclePrefab);
//             createdVehicle.transform.position = containerObject.transform.position;
//         }
//     }
//
//     private IEnumerator CreateBuildingsRoutine()
//     {
//         while (true)
//         {
//             yield return new WaitForSeconds(4.7f);
//
//             int randomIndex = Random.Range(0, buildingPrefabs.Length);
//             GameObject selectedBuildingPrefab = buildingPrefabs[randomIndex];
//             GameObject createdBuilding = Instantiate(selectedBuildingPrefab);
//             createdBuilding.transform.position = containerObject.transform.position;
//         }
//     }
// }

// using System.Collections.Generic;
// using UnityEngine;
//
// public class ObjectPooling : MonoBehaviour
// {
//     public GameObject[] buildingPrefabs;
//     public GameObject[] vehiclePrefabs;
//
//     private List<GameObject> buildingPool;
//     private List<GameObject> vehiclePool;
//     public GameObject containerObject;
//
//     private void Start()
//     {
//         //containerObject = new GameObject("ObjectContainer");
//
//         buildingPool = new List<GameObject>();
//         vehiclePool = new List<GameObject>();
//
//         // Bina havuzu
//         for (int i = 0; i < buildingPrefabs.Length; i++)
//         {
//             for (int j = 0; j < 10; j++)
//             {
//                 GameObject building = Instantiate(buildingPrefabs[i]);
//                 building.SetActive(false);
//                 buildingPool.Add(building);
//             }
//         }
//
//         // Araç havuzu
//         for (int i = 0; i < vehiclePrefabs.Length; i++)
//         {
//             for (int j = 0; j < 10; j++)
//             {
//                 GameObject vehicle = Instantiate(vehiclePrefabs[i]);
//                 vehicle.SetActive(false);
//                 vehiclePool.Add(vehicle);
//             }
//         }
//
//         // Rastgele bina seçimi
//         for (int i = 0; i < 10; i++)
//         {
//             int randomIndex = Random.Range(0, buildingPool.Count);
//             GameObject selectedBuilding = buildingPool[randomIndex];
//             selectedBuilding.transform.position = containerObject.transform.position;
//             selectedBuilding.SetActive(true);
//             buildingPool.RemoveAt(randomIndex);
//         }
//
//         // Rastgele araç seçimi
//         for (int i = 0; i < 10; i++)
//         {
//             int randomIndex = Random.Range(0, vehiclePool.Count);
//             GameObject selectedVehicle = vehiclePool[randomIndex];
//             selectedVehicle.transform.position = containerObject.transform.position;
//             selectedVehicle.SetActive(true);
//             vehiclePool.RemoveAt(randomIndex);
//         }
//     }
// }