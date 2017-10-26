using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int noOfEnemiesInScene;
    public GameObject ExitObject;
    Enemy[] enemies;

    private void Start()
    {
        for (int e = 0; e < noOfEnemiesInScene; e++)
        {
            int rnd = Random.Range(0, GameController.Instance.enemyDatabase.EnemyStatsDatabase.Length);

            GameObject enemyParent = GameObject.Find("Enemies");

            GameObject goEnemy = Instantiate(GameController.Instance.enemyDatabase.EnemyStatsDatabase[rnd].Prefab, enemyParent.transform.position, Quaternion.identity);

            goEnemy.transform.parent = enemyParent.transform;
        }
    }

    private void Update()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>();

        if (enemies.Length <= 0)
        {
            ExitObject.SetActive(true);
        }
    }
}
