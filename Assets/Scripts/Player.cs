using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 inputVector;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float life;

    private Rigidbody2D rb;

    public float Life
    {
        get => life;
        private set
        {
            life = value;
            UIManager.Instance.UpdateUIText();
        }
    }
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Bullet")) return;
        Destroy(collision.gameObject);
        Life -= 5.0f;
        Debug.Log("Bullet triggered, new life is " + life);
        if(Life <= 0){
            UIManager.Instance.DisplayLoseScreen();
            Destroy(gameObject);
        }
    }
}
