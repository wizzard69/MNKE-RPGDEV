using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public LayerMask raycastLayerMask;

     public EnemyStats enemyStats { get; set; }

    enum EnemyState { Patrol, Move2Target, Search, Attack }
    EnemyState curState;

    Movement movement;
    Vector3 moveDirection;
    int allowedSpacesToMove, hasMovedSpaces, faceDirection;
    bool enemyCanMove, isWaiting, isAttacking;
    Grid grid;
    Node targetNode;
    Color gizmocolor;

    private void Start()
    {
        targetNode = null;
        curState = EnemyState.Patrol;
        grid = FindObjectOfType<Grid>() as Grid;
        movement = GetComponent<Movement>();
        ResetMoves(true, 0);
        RotateEnemy();
    }

    private void Update()
    {
        switch (curState)
        {
            case EnemyState.Patrol:
                gizmocolor = Color.green;
                EnemyPatrolling(enemyStats.detectionDistance, enemyStats.moveWaitTime, enemyStats.maxSpaceToMoveBeforeRotate, enemyStats.moveSpeed);
                break;
            case EnemyState.Move2Target:
                gizmocolor = Color.yellow;
                EnemyMoveToTarget(enemyStats.detectionDistance, enemyStats.moveWaitTime, enemyStats.maxSpaceToMoveBeforeRotate);
                break;
            case EnemyState.Attack:
                gizmocolor = Color.red;
                EnemyAttack(enemyStats.moveWaitTime);
                break;
            default:
                break;
        }
    }

    public void EnemyPatrolling(float detectionDistance, float moveWaitTime, int maxSpaceToMoveBeforeRotate, float moveSpeed)
    {
        targetNode = null;

        if (!isWaiting)
        {
            enemyCanMove = movement.ObjectCanMove(moveDirection);

            if (enemyCanMove && hasMovedSpaces < allowedSpacesToMove)
            {
                isWaiting = true;

                movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z), moveSpeed);

                StartCoroutine(EnemyMove(moveWaitTime));
            }
            else
            {
                ResetMoves(true, maxSpaceToMoveBeforeRotate);
            }
        }

        Debug.DrawRay(transform.position, new Vector3(moveDirection.x * detectionDistance, moveDirection.y * detectionDistance, moveDirection.z * detectionDistance), Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDirection, out hit, detectionDistance, raycastLayerMask))
        {
            if (hit.collider.tag == "Player")
            {
                //Shoot Projectile

                targetNode = grid.nodeFromWorldPoint(hit.collider.transform.position);

                ResetMoves(false, maxSpaceToMoveBeforeRotate);

                float dist = Vector3.Distance(hit.transform.position, transform.position);

                if (dist <= 1.5f && !isAttacking)
                {
                    curState = EnemyState.Attack;
                }
                else
                {
                    curState = EnemyState.Move2Target;
                }
            }
            else
            {
                if (Vector3.Distance(hit.transform.position, transform.position) <= 1f)
                {
                    ResetMoves(true, maxSpaceToMoveBeforeRotate);
                    return;
                }
            }
        }
    }

    public void EnemyMoveToTarget( float detectionDistance, float moveWaitTime, int maxSpaceToMoveBeforeRotate)
    {
        Debug.DrawRay(transform.position, new Vector3(moveDirection.x * detectionDistance, moveDirection.y * detectionDistance, moveDirection.z * detectionDistance), Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDirection, out hit, detectionDistance, raycastLayerMask))
        {
            if (hit.collider.tag == "Player")
            {
                //Shoot Projectile

                targetNode = grid.nodeFromWorldPoint(hit.collider.transform.position);

                ResetMoves(false, maxSpaceToMoveBeforeRotate);

                float dist = Vector3.Distance(hit.transform.position, transform.position);

                if (dist <= 1.5f && !isAttacking)
                {
                    curState = EnemyState.Attack;
                }
            }
        }

        if (!isWaiting)
        {
            enemyCanMove = movement.ObjectCanMove(moveDirection);

            if (enemyCanMove)
            {
                isWaiting = true;

                movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z), enemyStats.moveSpeed);

                StartCoroutine(EnemyMove(moveWaitTime));
            }
            else
            {
                curState = EnemyState.Patrol;
            }
        }
    }

    public void EnemyAttack(float moveWaitTime)
    {
        isAttacking = true;
        //Attack player whilst in range.
        print("Attacking player......");
        StartCoroutine(AttackPause(moveWaitTime));
    }

    void ResetMoves(bool rotate, int maxSpaceToMoveBeforeRotate)
    {
        allowedSpacesToMove = Random.Range(1, maxSpaceToMoveBeforeRotate + 1);
        hasMovedSpaces = 0;

        if (rotate)
        {
            RotateEnemy();
        }
    }

    void RotateEnemy()
    {
        faceDirection = Random.Range(0, 4);

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

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmocolor;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    #region IENUMERATORS
    IEnumerator EnemyMove(float moveWaitTime)
    {
        yield return new WaitForSeconds(moveWaitTime);

        isWaiting = false;

        hasMovedSpaces++;

        yield return 0;
    }

    IEnumerator AttackPause(float moveWaitTime)
    {
        yield return new WaitForSeconds(moveWaitTime);
        curState = EnemyState.Patrol;
        isAttacking = false;
    }

    ///
    #endregion
}
