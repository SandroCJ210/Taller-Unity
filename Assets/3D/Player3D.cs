using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    [SerializeField]private float velocidadMovi = 10.0f;
    [SerializeField]private float velocidadRot = 250.0f;

    private Animator animator;
    private float x, y;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * velocidadRot * Time.deltaTime, 0);
        transform.Translate(0,0,y*velocidadMovi*Time.deltaTime);

        animator.SetFloat("MovY", y);
        animator.SetFloat("MovX", x);

    }
}
