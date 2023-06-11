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
                for (int i = 0; i < 1; i++)
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 294.8391f);
                }
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 295f);
            }
        }
        
    }
}
