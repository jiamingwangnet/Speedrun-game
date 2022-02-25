using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed;

    public void Move(int direction)
    {
        transform.position += direction * speed * Time.deltaTime * Vector3.up; 
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Move(1);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            Move(-1);
        }
    }
}
