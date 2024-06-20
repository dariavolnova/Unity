using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class SpawnController : MonoBehaviour
{ 
    private int numberCheck;
    private Vector3 spawnPos;

    public Vector3 SpawnPos { get => spawnPos; set => spawnPos = value; }

    void Start()
    {
        spawnPos = transform.position;
        numberCheck = 1;   
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {        
            if (numberCheck != Convert.ToInt16(collision.gameObject.name.Substring(gameObject.name.Length - 1)))
            {   
                SpawnPos = collision.transform.position;
                numberCheck = Convert.ToInt16(collision.gameObject.name.Substring(gameObject.name.Length - 1));
            }  
        }  
    }
}