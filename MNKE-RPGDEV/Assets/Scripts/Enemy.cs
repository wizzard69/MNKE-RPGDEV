using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : CharacterStats
{
    public override void Start()
    {
        base.Start();
        OnHealthReachedZero += Die;
    }

    public void Die()
    {
        Destroy(gameObject);
        print("Enemy is Dead");
    }
}
