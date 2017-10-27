using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int noOfEnemiesInScene;
    public GameObject ExitObject;
    Movement movement;
    Enemy[] enemies;

    private void Start()
    {
        movement = GetComponent<Movement>();

        for (int e = 0; e < noOfEnemiesInScene; e++)
        {

            int rnd = Random.Range(0, GameController.Instance.enemyDatabase.EnemyStatsDatabase.Length);

            Vector3 enemyAdjustedPlacement = movement.GetRandomWalkableNode();

            GameObject goEnemy = Instantiate(GameController.Instance.enemyDatabase.EnemyStatsDatabase[rnd].Prefab,
new Vector3(enemyAdjustedPlacement.x, enemyAdjustedPlacement.y + 1, enemyAdjustedPlacement.z), Quaternion.identity);

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
