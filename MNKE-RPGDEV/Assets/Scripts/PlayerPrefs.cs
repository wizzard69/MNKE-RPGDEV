using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);  
    }

    private void Start()
    {
        gamelevel = 25;
    }

    public static int gamelevel { get; set; }
}
