using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 inputVector;
    [SerializeField] private float speed;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        
        inputVector = new Vector2(xAxis, yAxis);
    }

    private void Move()
    {
        transform.Translate(inputVector * speed * Time.deltaTime);
    }
}
