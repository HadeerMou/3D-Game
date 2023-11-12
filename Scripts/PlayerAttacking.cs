using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;

    private float nextBullet;

    private void Attack()
    {
        if (Time.time > nextBullet)
        {
            nextBullet = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 25;

            bullet.GetComponent<Bullet>().targetTag = "Enemy";
            bullet.GetComponent<Bullet>().target = Bullet.TargetToDestroy.Enemy;

        }
    }
}
