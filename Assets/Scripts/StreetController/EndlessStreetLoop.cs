using System;
using UnityEngine;

namespace StreetController
{
    public class EndlessStreetLoop : MonoBehaviour
    {
        private float _movementSpeed = 8f;

        private void FixedUpdate()
        {
            StreetMovement();
        }

        private void StreetMovement()
        {
            gameObject.transform.Translate(0f, 0f, _movementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Relocator"))
            {
                gameObject.transform.Translate(0f, 0f, -160f);
            }
        }
        
    }
}
