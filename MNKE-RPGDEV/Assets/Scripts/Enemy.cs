using System.Collections;
using RPGStateMachine;
using UnityEngine;

//[RequireComponent(typeof(CharacterStats))]
public class Enemy : CharacterStats
{
   
    public override void Start()
    {
        OnHealthReachedZero += Die;     
        base.Start();
    }

    public void Die()
    {
        Destroy(gameObject);
        print("Enemy is Dead");
    }
}
