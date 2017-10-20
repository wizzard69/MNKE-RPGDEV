using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateState : IState
{
    int faceDirection;
    Transform transform;
    StateMachine stateMachine = new StateMachine();
    Movement movement;
    EnemyStats enemyStats;
    Vector3 moveDirection;

    public RotateState(Transform transform, Movement movement, EnemyStats enemyStats)
    {
        this.transform = transform;
        this.movement = movement;
        this.enemyStats = enemyStats;
    }

    public void Enter()
    {
        RotateEnemy();
    }

    public void Execute()
    {
        RotateEnemy();
        stateMachine.ChangeState(new PatrolState(transform, movement, enemyStats, moveDirection));
        stateMachine.ExecuteStateUpdate();
    }

    public void Exit()
    {
    }

    void RotateEnemy()
    {
        System.Random rand = new System.Random();
        faceDirection = rand.Next(0, 4);

        switch (faceDirection)
        {
            case 0:
                moveDirection = Vector3.forward;
                break;
            case 1:
                moveDirection = Vector3.back;
                break;
            case 2:
                moveDirection = Vector3.left;
                break;
            case 3:
                moveDirection = Vector3.right;
                break;
            default:
                break;
        }

        transform.LookAt(transform.position + moveDirection);
    }
}
