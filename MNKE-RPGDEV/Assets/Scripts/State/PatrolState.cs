using UnityEngine;
using RPGStateMachine;

public class PatrolState : State<EnemyController>
{

    private static PatrolState _instance;

    private PatrolState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static PatrolState Instance
    {
        get
        {
            if (_instance == null)
            {
                new PatrolState();
            }

            return _instance;
        }
    }

    public override void EnterState(EnemyController _owner)
    {
        Debug.Log(_owner.enemyStats.name + " has entered Patrol State");
    }

    public override void ExitState(EnemyController _owner)
    {
        Debug.Log("Exiting PatrolState");
    }

    public override void UpdateState(EnemyController _owner)
    {
        if (_owner.switchState)
        {
            _owner.stateMachine.ChangeState(AttackState.Instance);
        }
    }
}
