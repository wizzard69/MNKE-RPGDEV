using UnityEngine;
using RPGStateMachine;

public class MoveToStateV2 : State<EnemyScriptV2>
{
    static MoveToStateV2 _instance;

    #region Singleton
    MoveToStateV2()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static MoveToStateV2 Instance
    {
        get
        {
            if (_instance == null)
            {
                new MoveToStateV2();
            }

            return _instance;
        }
    }
    #endregion

    public override void EnterState(EnemyScriptV2 _owner)
    {
    }

    public override void ExitState(EnemyScriptV2 _owner)
    {
    }

    public override void UpdateState(EnemyScriptV2 _owner)
    {
        if (!_owner.movement.ObjectCanMove(_owner.moveDirection))
        {
            _owner.stateMachine.ChangeState(PatrolStateV2.Instance);
            return;
        }

        _owner.movement.MoveObject(new Vector2(_owner.moveDirection.x, _owner.moveDirection.z), _owner.enemyStats.moveSpeed);
    }
}