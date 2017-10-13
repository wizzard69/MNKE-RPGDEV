using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Player : MonoBehaviour {
    
    CharacterStats stats;

    public void start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthReachedZero += Die;
    }

    void Die()
    {
        Destroy(gameObject);
        print("Player is Dead");
    }
}
