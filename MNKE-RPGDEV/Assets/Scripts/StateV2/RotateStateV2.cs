using UnityEngine;
using RPGStateMachine;

public class RotateStateV2 : State<EnemyScriptV2>
{
    static RotateStateV2 _instance;
    int faceDirection;

    #region Singleton
    RotateStateV2()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static RotateStateV2 Instance
    {
        get
        {
            if (_instance == null)
            {
                new RotateStateV2();
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
        RotateEnemy(_owner);
        _owner.stateMachine.ChangeState(PatrolStateV2.Instance);
    }
    void RotateEnemy(EnemyScriptV2 _owner)
    {
        System.Random rand = new System.Random();
        faceDirection = rand.Next(0, 4);

        switch (faceDirection)
        {
            case 0:
                _owner.moveDirection = Vector3.forward;
                break;
            case 1:
                _owner.moveDirection = Vector3.back;
                break;
            case 2:
                _owner.moveDirection = Vector3.left;
                break;
            case 3:
                _owner.moveDirection = Vector3.right;
                break;
            default:
                break;
        }

        _owner.transform.LookAt(_owner.transform.position + _owner.moveDirection);
    }
}