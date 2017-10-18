using UnityEngine;
using RPGStateMachine;

public class AttackState : State<EnemyController>
{

    private static AttackState _instance;

    private AttackState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static AttackState Instance
    {
        get
        {
            if (_instance == null)
            {
                new AttackState();
            }

            return _instance;
        }
    }

    public override void EnterState(EnemyController _owner)
    {
        Debug.Log("Entering AttackState");
    }

    public override void ExitState(EnemyController _owner)
    {
        Debug.Log("Exiting AttackState");
    }

    public override void UpdateState(EnemyController _owner)
    {
        if (!_owner.switchState)
        {
            _owner.stateMachine.ChangeState(PatrolState.Instance);
        }
    }
}
