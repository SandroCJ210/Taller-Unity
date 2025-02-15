using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Vector2 aimDirection = Vector2.right;
    private Vector2 lastHorizontalDirection = Vector2.right;
    
    // Expression-bodied members
    public Vector2 AimDirection => aimDirection;


     Animator torsoAnimator;
  
     void Start()
    {
        torsoAnimator = transform.Find("Animacion.torso").GetComponent<Animator>();
    }
    void Update()
    {
        GetAimInput();
        GetImputY();


    }
    // Solid principles
    private void GetImputY() {
        float directionshot = Input.GetAxisRaw("Vertical");
        torsoAnimator.SetFloat("aimY", directionshot);
    } 
    private void GetAimInput()
    {
        float aimX = Input.GetAxisRaw("Horizontal");
        float aimY = Input.GetAxisRaw("Vertical");

        if (aimX != 0 || aimY != 0) // Si presionamos algun input
        {
            // aimDirection = new Vector2(aimX, aimY);
            if (aimX != 0) // Tenemos input horizontal
            {
                lastHorizontalDirection = new Vector2(Mathf.Sign(aimX), 0);
            }

            if (aimY != 0) // Si hay un input vertical 
            {
                aimDirection = new Vector2(0, Mathf.Sign(aimY));
            }
            else // Si no hay input vertical, usamos el horizontal
            {
                aimDirection = lastHorizontalDirection;
            }
        } 
        else
        {
            aimDirection = Vector2.right; // Siempre vuelve a la derecha si no hay input
            lastHorizontalDirection = Vector2.right;
        }


    }

    public Vector2 GetAimDirection(){
        return aimDirection;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, aimDirection);
    }
    
}
