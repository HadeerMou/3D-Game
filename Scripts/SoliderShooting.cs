using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;

    private Animator soliderAnimator;
    private float nextBullet;

    private void Awake()
    {
        soliderAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        //code for firing
        if (Input.GetMouseButton(0))
        {
            soliderAnimator.SetBool("Fire", true);
            // current time bigger than nextbullet tp shoot a bullet every 0.25 seconds
            if (Time.time > nextBullet)
            {
                nextBullet = Time.time + fireRate;
                GameObject bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;

                bullet.GetComponent<Bullet>().targetTag = "Player";
                bullet.GetComponent<Bullet>().target = Bullet.TargetToDestroy.Player;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            soliderAnimator.SetBool("Fire", false);
        }
    }
}
