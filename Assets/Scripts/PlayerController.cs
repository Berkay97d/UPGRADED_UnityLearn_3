using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;

    [SerializeField] private GameObject food;
    

    private void Update()
    {
        if (GameController.isGameOver)
        {
            return;
        }
        
        Move();
        StayInGameArea();
        ThrowFood();
    }

    private void Move()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed );
    }

    private void StayInGameArea()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    }


    private void ThrowFood()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, food.transform.rotation);
        }
    }
    
}
