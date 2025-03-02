using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float shootRate;
    [SerializeField] float offsetMagnitude;

    [Header("Turret Settings")]
    [SerializeField] float life = 50.0f;
    [SerializeField] bool canMove = false;
    [SerializeField] float normalSpeed;
    [SerializeField] float chaseSpeed;
    [SerializeField] float moveDistance;

    bool bIsFollowingPlayer = false;

    Transform player;

    GameObject Warning;
    int WarningCounter = 0;
    bool bIsInWarning;
    bool bIsShooting = false;
    Vector2 startPosition;
    float moveSpeed;
    CapsuleCollider2D capsuleCollider;

    void Start()
    {
        InitializeVariables();
        GameManager.Instance.EnemiesAlive++;
    }

    private void InitializeVariables()
    {
        Warning = transform.GetChild(2).gameObject;
        player = GameObject.Find("Player")?.transform;
        Warning.SetActive(false);
        startPosition = transform.position;
        moveSpeed = normalSpeed;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void StartShoot()
    {
        if (!bIsShooting)
        {
            InvokeRepeating(nameof(Shoot), 0, shootRate);
        }
    }

    IEnumerator Blink()
    {
        bIsInWarning = true;
        WarningCounter = 0;

        while (WarningCounter < 5)
        {
            Warning.SetActive(!Warning.activeSelf);
            WarningCounter++;
            yield return new WaitForSeconds(0.5f);
        }
        Warning.SetActive(false);
        bIsInWarning = false;
    }

    void StopShoot()
    {
        bIsShooting = false;
        CancelInvoke(nameof(Shoot));
    }
    void Shoot()
    {
        if (player == null) return;
        Vector2 aimDirection = (player.position - transform.position).normalized;
        bulletSpawn.position = transform.position + new Vector3(aimDirection.x * offsetMagnitude, aimDirection.y * offsetMagnitude, 0);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript)
        {
            bulletScript.Initialize(aimDirection);
        }
    }
    /*void OnBecameVisible()
    {
        if(!bIsInWarning){
            StartCoroutine(Blink());
        }
        StartShoot();
    }
    void OnBecameInvisible()
    {
        StopShoot();
    }*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= 10.0f;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.EnemiesAlive--;
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            bIsFollowingPlayer = true;
            moveSpeed = chaseSpeed;
            if (!bIsInWarning)
            {
                StartCoroutine(Blink());
            }
            StartShoot();
            capsuleCollider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        /*if (collision.gameObject.CompareTag("Player"))
        {
            bIsFollowingPlayer = false;
            moveSpeed = normalSpeed;
            StopShoot();
        }*/
    }

    void Update()
    {
        if (!canMove) return;
        if(!bIsFollowingPlayer){
            MoveTurret();
        }else{
            FollowTurret();
        }
    }

    void MoveTurret()
    {
        float x = startPosition.x + Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = new Vector3(x, transform.position.y, 0);
    }

    void FollowTurret(){
        transform.position = new Vector3(transform.position.x - (1 * Time.deltaTime * chaseSpeed),transform.position.y,0);
    }
}
