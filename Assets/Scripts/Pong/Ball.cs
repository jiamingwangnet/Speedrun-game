using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Vector2 initialVelocity;
        private Vector2 velocity;

        // Start is called before the first frame update
        void Start()
        {
            velocity = initialVelocity;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 movement = new Vector3(velocity.x, velocity.y) * Time.deltaTime;
            transform.position += movement;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("wall"))
            {
                velocity.y *= -1;
            }

            if (collision.transform.CompareTag("paddle"))
            {
                velocity.x *= -1;
            }
        }
    }
}
