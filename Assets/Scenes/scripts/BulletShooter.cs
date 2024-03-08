using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    
    public GameObject bulletPrefab; // 발사할 탄환의 프리팹
    public float bulletSpeed = 3f; // 탄환의 속도
    public Transform bulletSpawnPoint; // 탄환 발사 지점
    public float fireRate = 1f; // 초당 발사 횟수

    private float nextFireTime = 0f; // 다음 발사 시간

    void Update()
    {
        //Fire();

        
        if (Time.time >= nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + 1f / fireRate;
        }
        
    }

    void ShootBullet()
    {
        if (bulletPrefab && bulletSpawnPoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.velocity = Vector2.up * bulletSpeed;
            }

        }
    }
    void Fire()
    {
       GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
       Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
       rigid.AddForce(Vector2.up*100, ForceMode2D.Impulse);
    }

}

