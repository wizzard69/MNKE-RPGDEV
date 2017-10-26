using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletRange;
    public int bulletDamage;
    public float timeBetweenShots;
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        float dist = Vector3.Distance(transform.position, startPos);

        if (dist >= bulletRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision != null)
            {
               collision.gameObject.transform.parent.gameObject.GetComponent<EnemyScriptV2>().TakeDamage(bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}
