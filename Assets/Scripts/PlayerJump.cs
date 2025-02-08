using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [SerializeField] private float jumpForce = 5.0f;

    [SerializeField] private float raycastDistance = 1.0f;
    [SerializeField] private LayerMask groundLayer;

    private bool tryJumping = false;
    private bool isGrounded = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        CheckGround();
        Jump();

        Debug.Log("isGrounded: " + isGrounded + " tryJumping: " + tryJumping);
    }

    private void FixedUpdate()
    {
        // CheckGround();
        // Jump();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector2.down * raycastDistance);
    }

    private void GetInput()
    {
        tryJumping = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tryJumping = true;
            return;
        }
    }

    private void Jump()
    {
        if (!tryJumping) return;
        if(!isGrounded) return;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
        isGrounded = (hit.collider != null);
        // if (hit.transform != null)
        // {
        //     isGrounded = true;
        // }
        // else
        // {
        //     isGrounded = false;
        // }

    }


}
