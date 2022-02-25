using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private float speed;
        private int lastMoveDirection;
        private bool canMove = true;

        public void Move(int direction)
        {
            if (!canMove) return;
            transform.position += direction * speed * Time.deltaTime * Vector3.up;
            lastMoveDirection = direction;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(1);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(-1);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.CompareTag("wall"))
            {
                canMove = false;
                transform.position -= 0.275f * lastMoveDirection * Vector3.up;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.CompareTag("wall"))
            {
                canMove = true;
            }
        }
    }
}
