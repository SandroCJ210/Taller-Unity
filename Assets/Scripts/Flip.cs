using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRender;
    Rigidbody2D rb;
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (rb.velocity.x > 0)
        //{
        //    spriteRender.flipX = false;

        //}
        //if (rb.velocity.x < 0)
        //{
        //    spriteRender.flipX = true;
        //}
        if (rb.velocity.x > 0) // Se mueve a la derecha
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0) // Se mueve a la izquierda
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }

}