using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;
    public float bulletspeed;
    public float bulletRange;
    public float timeBetweenShots;
    float shotCounter;
    public Transform firepoint;

    private void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as BulletController;
                newBullet.bulletSpeed = bulletspeed;
                newBullet.bulletRange = bulletRange;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
