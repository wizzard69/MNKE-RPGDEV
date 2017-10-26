using UnityEngine;
using RPGStateMachine;

public class AttackStateV2 : State<EnemyScriptV2>
{
    static AttackStateV2 _instance;

    #region Singleton
    AttackStateV2()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static AttackStateV2 Instance
    {
        get
        {
            if (_instance == null)
            {
                new AttackStateV2();
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

        if (!_owner.gun.isFiring)
        {
            _owner.gun.isFiring = true;
        }

        Debug.Log("Attacking Player");
        //_owner.stateMachine.ChangeState(PatrolStateV2.Instance);
        _owner.stateMachine.ChangeState(MoveToStateV2.Instance);
        return;
    }
}