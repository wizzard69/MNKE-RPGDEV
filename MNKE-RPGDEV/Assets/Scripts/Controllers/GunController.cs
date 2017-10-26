using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    bool IsFirstBullet;
    public BulletController bullet;
    float shotCounter;
    public Transform firepoint;

    private void Start()
    {
        shotCounter = bullet.timeBetweenShots;
        IsFirstBullet = true;
    }

    private void Update()
    {
        if (isFiring)
        {
            if (IsFirstBullet)
            {
                BulletController newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as BulletController;
                newBullet.bulletSpeed = bullet.bulletSpeed;
                newBullet.bulletRange = bullet.bulletRange;
                newBullet.bulletDamage = bullet.bulletDamage;
                shotCounter = bullet.timeBetweenShots;
                IsFirstBullet = false;
            }

            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                BulletController newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as BulletController;
                newBullet.bulletSpeed = bullet.bulletSpeed;
                newBullet.bulletRange = bullet.bulletRange;
                newBullet.bulletDamage = bullet.bulletDamage;
                shotCounter = bullet.timeBetweenShots;
                isFiring = false;
            }
        }
    }
}
