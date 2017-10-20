using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyScript : MonoBehaviour
{
    public EnemyStats enemyStats;

    StateMachine stateMachine = new StateMachine();
    float zeroTimer = 0f;
    bool canMove, moveActive;
    Movement movement;
    Transform _transform;

    private void Start()
    {
        canMove = true;
        moveActive = true;
        movement = GetComponent<Movement>();
        _transform = GetComponent<Transform>();
        this.stateMachine.ChangeState(new PatrolState(_transform, movement, enemyStats, Vector3.forward));
    }

    private void Update()
    {
        if (moveActive)
        {
            TimerFunction(enemyStats.moveWaitTime);
        }

        if (canMove)
        {
            canMove = false;
            this.stateMachine.ExecuteStateUpdate();
        }
    }

    private void TimerFunction(float timeLimit)
    {
        zeroTimer += Time.deltaTime;
        if (zeroTimer > timeLimit)
        {
            zeroTimer = 0f;
            canMove = true;
        }
    }
}
