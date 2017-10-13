﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    public int maxSpaceToMoveBeforeRotate;
    public float detectionDistance;
    [Range(0.6f, 3.0f)]
    public float moveWaitTime;

    CharacterStats stats;

    public void start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthReachedZero += Die;
    }

    void Die()
    {
        Destroy(gameObject);
        print("Enemy is Dead");
    }
}
