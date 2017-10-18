using UnityEngine;
using RPGStateMachine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(StateController))]
public class EnemyController : Enemy
{
    StateController stateController;
    public StateMachine<EnemyController> stateMachine { get; set; }

    [HideInInspector]
    public bool switchState = false;

    private void Start()
    {
        stateController = GetComponent<StateController>();
        stateController.enemyStats = enemyStats;

        stateMachine = new StateMachine<EnemyController>(this);
        stateMachine.ChangeState(PatrolState.Instance);

        base.start();
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode.P)))
        {
            switchState = !switchState;
        }
        stateMachine.Update();
    }
}
