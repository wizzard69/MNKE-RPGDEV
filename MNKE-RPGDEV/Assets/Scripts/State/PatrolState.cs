using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    Movement _movement;
    EnemyStats _enemyStats;
    Transform _transform;
    StateMachine stateMachine = new StateMachine();

    float hasMovedSpaces = 0;
    float allowedSpacesToMove = 0;
    Vector3 _moveDirection;

    public PatrolState(Transform transform, Movement movement, EnemyStats enemyStats, Vector3 moveDirection)
    {
        _movement = movement;
        _enemyStats = enemyStats;
        _transform = transform;
        _moveDirection = moveDirection;
    }

    public void Enter()
    {
        //Debug.Log("Entering Patrol State");
        ResetMoves(false, _enemyStats.maxSpaceToMoveBeforeRotate);
    }

    public void Execute()
    {
        //targetNode = null;

        if (!_movement.ObjectCanMove(_moveDirection))
        {
            ResetMoves(true, _enemyStats.maxSpaceToMoveBeforeRotate);
            return;
        }

        if (hasMovedSpaces >= allowedSpacesToMove)
        {
            ResetMoves(true, _enemyStats.maxSpaceToMoveBeforeRotate);
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(_transform.position, _moveDirection, out hit, _enemyStats.detectionDistance, _enemyStats.raycastLayerMask))
        {
            if (Vector3.Distance(hit.transform.position, _transform.position) <= 1f)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Player Detected");
                    //Player Detected
                    //Attack Player State

                    //targetNode = grid.nodeFromWorldPoint(hit.collider.transform.position);

                    //        ResetMoves(false, maxSpaceToMoveBeforeRotate);

                    //        float dist = Vector3.Distance(hit.transform.position, transform.position);

                    //        if (dist <= 1.5f && !isAttacking)
                    //        {
                    //            curState = EnemyState.Attack;
                    //        }
                    //        else
                    //        {
                    //            curState = EnemyState.Move2Target;
                    //        }

                    stateMachine.ChangeState(new AttackState());
                    stateMachine.ExecuteStateUpdate();
                }
                else
                {
                    ResetMoves(true, _enemyStats.maxSpaceToMoveBeforeRotate);
                    return;
                }
            }
            else
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Player Detected");
                    //Shoot Projectile

                    stateMachine.ChangeState(new MoveToState(_moveDirection, _movement, _enemyStats, _transform));
                    stateMachine.ExecuteStateUpdate();
                }
            }
        }

        _movement.MoveObject(new Vector2(_moveDirection.x, _moveDirection.z), _enemyStats.moveSpeed);
        hasMovedSpaces++;
    }

    public void Exit()
    {
        //Debug.Log("Entering Patrol State");
    }

    void ResetMoves(bool rotate, int maxSpaceToMoveBeforeRotate)
    {
        System.Random rand = new System.Random();

        allowedSpacesToMove = rand.Next(1, maxSpaceToMoveBeforeRotate + 1);

        hasMovedSpaces = 0;

        if (rotate)
        {
            stateMachine.ChangeState(new RotateState(_transform, _movement, _enemyStats));
            stateMachine.ExecuteStateUpdate();
        }
    }
}
