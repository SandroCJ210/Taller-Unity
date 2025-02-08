
using System;
using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerAim playerAim;
    [SerializeField] private GameObject bulletPrefab;
    
    public Transform bulletSpawn;
    [SerializeField] private float offsetMagnitude = 5f;

    public float fireRate = 0.5f; // Tiempo entre disparos auitomáticos
    private float nextFireTime = 0f; // Tiempo en el que se permitirá el próximo disparo

    private Coroutine shootingCoroutine;
    private void Start()
    {
        playerAim = GetComponent<PlayerAim>();
    }

    private void Update()
    {
        Vector2 aimDirection = playerAim.AimDirection;
        bulletSpawn.position = transform.position + new Vector3(aimDirection.x * offsetMagnitude, aimDirection.y * offsetMagnitude, 0);
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.L) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            shootingCoroutine = StartCoroutine(Autoshoot());
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            StopCoroutine(shootingCoroutine);
        }
        
    }

    private IEnumerator Autoshoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot()
    {
        Vector2 aimDirection = playerAim.AimDirection;
        bulletSpawn.position = transform.position + new Vector3(aimDirection.x * offsetMagnitude, aimDirection.y * offsetMagnitude, 0);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(aimDirection);
        
        // GameObject bullet = new GameObject("Bullet");
        //
        // bullet.transform.position = transform.position;
        // Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
        // rb.gravityScale = 0;
        // rb.velocity = new Vector2(aimDirection.x * bulletSpeed, aimDirection.y * bulletSpeed);
        // bullet.AddComponent<CircleCollider2D>();
        // SpriteRenderer sr = bullet.AddComponent<SpriteRenderer>();
        // sr.sprite = Resources.Load<Sprite>("Sprites/PlayerBullet");
    }
}
