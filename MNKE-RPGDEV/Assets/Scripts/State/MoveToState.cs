using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToState : IState
{
    Vector3 moveDirection;
    Movement movement;
    EnemyStats enemyStats;
    Transform transform;
    StateMachine stateMachine = new StateMachine();

    public MoveToState(Vector3 moveDirection, Movement movement, EnemyStats enemyStats, Transform transform)
    {
        this.moveDirection = moveDirection;
        this.movement = movement;
        this.enemyStats = enemyStats;
        this.transform = transform;
    }

    public void Enter()
    {
    }

    public void Execute()
    {
        if (!movement.ObjectCanMove(moveDirection))
        {
            stateMachine.ChangeState(new PatrolState(transform, movement, enemyStats, moveDirection));
            stateMachine.ExecuteStateUpdate();
        }

        movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z), enemyStats.moveSpeed);
        
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, moveDirection, out hit, detectionDistance, raycastLayerMask))
        //{
        //    if (hit.collider.tag == "Player")
        //    {
        //        //Shoot Projectile

        //        targetNode = grid.nodeFromWorldPoint(hit.collider.transform.position);

        //        ResetMoves(false, maxSpaceToMoveBeforeRotate);

        //        float dist = Vector3.Distance(hit.transform.position, transform.position);

        //        if (dist <= 1.5f && !isAttacking)
        //        {
        //            curState = EnemyState.Attack;
        //        }
        //    }
        //}

        //if (!isWaiting)
        //{
        //    enemyCanMove = movement.ObjectCanMove(moveDirection);

        //    if (enemyCanMove)
        //    {
        //        isWaiting = true;

        //        movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z), enemyStats.moveSpeed);

        //        StartCoroutine(EnemyMove(moveWaitTime));
        //    }
        //    else
        //    {
        //        curState = EnemyState.Patrol;
        //    }
        //}
    }

    public void Exit()
    {
    }
}
