using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    public Transform firepoint;
    public BulletController bullet;

    bool canfire = true;
    float shotCounter;

    private void Start()
    {
        shotCounter = bullet.timeBetweenShots;
    }

    private void Update()
    {
        if (isFiring & canfire)
        {
            canfire = false;

            BulletController newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as BulletController;
            newBullet.bulletSpeed = bullet.bulletSpeed;
            newBullet.bulletRange = bullet.bulletRange;
            newBullet.bulletDamage = bullet.bulletDamage;

            StartCoroutine(WaitForNextBullet());
        }
    }

    IEnumerator WaitForNextBullet()
    {
        yield return new WaitForSeconds(shotCounter);
        isFiring = false;
        canfire = true;
    }
}
