using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(StateController))]
public class EnemyController : Enemy
{
    public EnemyStats enemyStats;
    StateController stateController;

    [HideInInspector]
    public bool switchState = false;

    private void Start()
    {
        stateController = GetComponent<StateController>();
        stateController.enemyStats = enemyStats;

        base.start();
    }
}
