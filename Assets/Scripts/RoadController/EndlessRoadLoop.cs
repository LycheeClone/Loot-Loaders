using System;
using UnityEngine;

namespace RoadController
{
    public class EndlessRoadLoop : MonoBehaviour
    {
        private float _speed = 8f;

        private void FixedUpdate()
        {
            RoadMovement();
        }

        private void RoadMovement()
        {
            gameObject.transform.Translate(0f, 0f, _speed * Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Relocator"))
            {
                gameObject.transform.Translate(0f, 0f, -320f);
            }
        }
    }
}