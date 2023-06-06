using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class draft : MonoBehaviour
{
    // public GameObject CarToSpawn;
    // public Rigidbody Rb;
    public float Speed;

    private void Awake()
    {
        //CarToSpawn = GameObject.FindGameObjectWithTag("CrossCar");
    }

    private void Update()
    {
        //rb.AddForce(0,0,-speed*Time.deltaTime);
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.z <= -8)
        {
            Destroy(gameObject);
        }
    }
}