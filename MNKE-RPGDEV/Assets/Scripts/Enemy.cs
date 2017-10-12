using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float damageAmount;
    public float attackAmount;
    public int maxSpaceToMoveBeforeRotate;
    public float detectionDistance;
    public int startingHealth;
    [Range(0.6f, 3.0f)]
    public float moveWaitTime;

    public PlayerHealth playerhealth;
    int currentHealth;

    public void start()
    {
        currentHealth = startingHealth;
        playerhealth = GameObject.Find("PlayerObject").GetComponent<PlayerHealth>();
    }    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        print("Enemy is Dead");
    }
}
