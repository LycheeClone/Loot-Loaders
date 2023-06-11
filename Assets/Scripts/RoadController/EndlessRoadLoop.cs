using System;
using UnityEngine;

namespace RoadController
{
    public class EndlessRoadLoop : MonoBehaviour
    {
        private float _speed = 20f;

        private void FixedUpdate()
        {
            RoadMovement();
        }

        private void RoadMovement()
        {
            gameObject.transform.Translate(0f, 0f, _speed * Time.deltaTime);
        }

        public bool hasCollided = false;


        private bool isFirstTrigger = true;

        private void OnTriggerEnter(Collider other)
        {
            if (isFirstTrigger)
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 274.8391f);
                isFirstTrigger = false;
            }
            else
            {
                Debug.Log("275");
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 275f);
            }
        }



    }
}