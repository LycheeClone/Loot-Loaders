using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public WheelCollider RightFrontCollider;
    public WheelCollider LeftFrontCollider;
    public WheelCollider RightRearCollider;
    public WheelCollider LeftRearCollider;
    public GameObject RightFrontWheel;
    public GameObject LeftFrontWheel;
    public GameObject RightRearWheel;
    public GameObject LeftRearWheel;
    public Rigidbody CarRb;
    [SerializeField] private float _forwardSpeed;



}
