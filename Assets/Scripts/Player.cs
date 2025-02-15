using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 inputVector;
    [SerializeField] private float speed;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void GetInput()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        
        inputVector = new Vector2(xAxis, 0f);
    }

    private void Move()
    {
        rb.velocity = new Vector2(inputVector.x * speed, rb.velocity.y);
    }

    public Vector2 InputVector => inputVector;
}
