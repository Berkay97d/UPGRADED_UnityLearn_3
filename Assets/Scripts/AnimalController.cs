using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float destroyRange;
    
    
    

    private void Update()
    {
        if (GameController.isGameOver)
        {
            Destroy(gameObject);
            return;
        }
        
        Move();
        DestroyAnimal();
    }

    private void Move()
    {
        transform.Translate(transform.forward * Time.deltaTime * -speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            UIController.WinScore();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void DestroyAnimal()
    {
        if (transform.position.z < destroyRange)
        {
            UIController.LoseLife();
            Destroy(gameObject);
        }
    }
    
}
