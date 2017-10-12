using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float damageAmount;
    public float attackAmount;
    public int maxSpaceToMoveBeforeRotate;
    public float detectionDistance;
    [Range(0.6f, 3.0f)]
    public float moveWaitTime;

    public PlayerHealth playerhealth;

    public void start()
    {
        playerhealth = GameObject.Find("PlayerObject").GetComponent<PlayerHealth>();
    }    
}
