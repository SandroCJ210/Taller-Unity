
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int healthPoints = 5;

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0) Destroy(gameObject);   
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
    }
}
