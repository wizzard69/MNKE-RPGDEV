using UnityEngine;
using RPGStateMachine;
using System.Collections;

public class PatrolStateV2 : State<EnemyScriptV2>
{
    static PatrolStateV2 _instance;
    float hasMovedSpaces = 0;
    float allowedSpacesToMove = 0;

    #region Singleton
    PatrolStateV2()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static PatrolStateV2 Instance
    {
        get
        {
            if (_instance == null)
            {
                new PatrolStateV2();
            }

            return _instance;
        }
    }
    #endregion

    public override void EnterState(EnemyScriptV2 _owner)
    {
        ResetMoves(false, _owner);
    }

    public override void ExitState(EnemyScriptV2 _owner)
    {
    }

    public override void UpdateState(EnemyScriptV2 _owner)
    {
        if (!_owner.movement.ObjectCanMove(_owner.moveDirection))
        {
            ResetMoves(true, _owner);
            return;
        }

        if (hasMovedSpaces > allowedSpacesToMove)
        {
            ResetMoves(true, _owner);
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(_owner.transform.position, _owner.moveDirection, out hit, _owner.enemyStats.detectionDistance, _owner.enemyStats.raycastLayerMask))
        {
            if (Vector3.Distance(hit.transform.position, _owner.transform.position) <= 1f)
            {
                if (hit.collider.tag != "Player")
                {
                    ResetMoves(true, _owner);
                    return;
                }
            }
        }

        _owner.movement.MoveObject(new Vector2(_owner.moveDirection.x, _owner.moveDirection.z), _owner.enemyStats.moveSpeed);

        hasMovedSpaces++;
    }

    void ResetMoves(bool rotate, EnemyScriptV2 _owner)
    {
        System.Random rand = new System.Random();

        allowedSpacesToMove = rand.Next(1, _owner.enemyStats.maxSpaceToMoveBeforeRotate + 1);

        hasMovedSpaces = 0;

        if (rotate)
        {
            _owner.stateMachine.ChangeState(RotateStateV2.Instance);
        }
    }
}