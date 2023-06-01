using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    private bool swipeStarted = false;
    private Vector2 swipeStartPos;
    private float moveAmount = 5f;

    public float swipeThreshold = 50f; // Kaydırma eşiği

    private void Update()
    {
        CarMovement();
        ConstMovement();
    }
    
    private void ConstMovement()
    {
        Vector3 direction = Vector3.forward;
        CarRb.AddForce(direction.normalized * _forwardSpeed, ForceMode.VelocityChange); // Speed up the object   
    }

    private void SlideObject(float direction)
    {
        Vector3 targetPosition = transform.position + new Vector3(direction * moveAmount, 0, 0);
        transform.DOMove(targetPosition, 0.25f);
    }

    private void CarMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStarted = true;
                swipeStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeEndPos = touch.position;
                Vector2 swipeDirection = swipeEndPos - swipeStartPos;

                float swipeAmountX = Mathf.Abs(swipeDirection.x);

                if (swipeStarted && swipeAmountX > swipeThreshold)
                {
                    // Sağa kaydırma
                    if (swipeDirection.x > 0)
                    {
                        Debug.Log("Sağa kaydırma yapıldı!");
                        SlideObject(1f);
                    }
                    // Sola kaydırma
                    else
                    {
                        Debug.Log("Sola kaydırma yapıldı!");
                        SlideObject(-1f);
                    }
                }

                swipeStarted = false;


                // if (Input.touchCount > 0)
                // {
                //     Touch touch = Input.GetTouch(0);
                //
                //     // Ekrandaki dokunmatik pozisyonu al
                //     Vector2 touchPosition = touch.position;
                //
                //     // Ekrandaki dokunmatik pozisyonun yüzdesini hesapla
                //     float halfScreenWidth = Screen.width / 2f;
                //     float touchPercentage = touchPosition.x / Screen.width;
                //
                //     // Karakteri hareket ettir
                //     if (touchPercentage < 0.5f)
                //     {
                //         transform.DOMoveX(-5, 0.25f);
                //     }
                //     else if (touchPercentage > 0.5f)
                //     {
                //         transform.DOMoveX(5, 0.25f);
                //     }
                // }
            }
        }
    }
}