using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyController : Enemy
{
    public LayerMask raycastLayerMask;

    enum EnemyState { Patrol, Move2Target, Search, Attack }
    EnemyState curState;

    enum FaceDirection { Forward, Backward, Left, Right };
    FaceDirection faceDirection;

    Movement movement;
    bool enemyCanMove;
    bool isWaiting;
    bool isRotating;
    Vector3 moveDirection;

    int allowedSpacesToMove;
    int hasMovedSpaces;

    Grid grid;
    Node targetNode;
    Color gizmocolor;
    int fullrotate = 4;
    int curRotate = 0;

    private void Start()
    {
        grid = GameObject.Find("GameManager").GetComponent(typeof(Grid)) as Grid;

        curState = EnemyState.Patrol;

        base.start();

        movement = GetComponent<Movement>();

        ResetMoves(true);
    }

    void Update()
    {
        switch (curState)
        {
            case EnemyState.Patrol:
                gizmocolor = Color.green;
                EnemyPatrolling();
                break;
            case EnemyState.Move2Target:
                gizmocolor = Color.yellow;
                EnemyMoveToTarget();
                break;
            case EnemyState.Search:
                gizmocolor = Color.blue;
                EnemySearching();
                break;
            case EnemyState.Attack:
                gizmocolor = Color.red;
                EnemyAttack();
                break;
            default:
                break;
        }
    }

    IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(moveWaitTime);

        isWaiting = false;

        hasMovedSpaces++;

        yield return 0;
    }

    void RotateEnemy()
    {
        faceDirection = (FaceDirection)Random.Range(0, System.Enum.GetValues(typeof(FaceDirection)).Length);

        switch (faceDirection)
        {
            case FaceDirection.Forward:
                moveDirection = Vector3.forward;
                break;
            case FaceDirection.Backward:
                moveDirection = Vector3.back;
                break;
            case FaceDirection.Left:
                moveDirection = Vector3.left;
                break;
            case FaceDirection.Right:
                moveDirection = Vector3.right;
                break;
            default:
                break;
        }

        transform.LookAt(transform.position + moveDirection);
    }

    void ResetMoves(bool rotate)
    {
        allowedSpacesToMove = Random.Range(1, maxSpaceToMoveBeforeRotate + 1);
        hasMovedSpaces = 0;

        if (rotate)
        {
            RotateEnemy();
        }
    }

    void EnemyPatrolling()
    {
        targetNode = null;

        if (!isWaiting)
        {
            enemyCanMove = movement.ObjectCanMove(moveDirection);

            if (enemyCanMove && hasMovedSpaces < allowedSpacesToMove)
            {
                isWaiting = true;

                movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z));

                StartCoroutine(EnemyMove());
            }
            else
            {
                ResetMoves(true);
            }
        }

        Debug.DrawRay(transform.position, new Vector3(moveDirection.x * detectionDistance, moveDirection.y * detectionDistance, moveDirection.z * detectionDistance), Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDirection, out hit, detectionDistance, raycastLayerMask))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) <= 1f)
            {
                ResetMoves(true);
                return;
            }

            if (hit.collider.tag == "Player")
            {
                targetNode = grid.nodeFromWorldPoint(hit.collider.transform.position);

                ResetMoves(false);

                curState = EnemyState.Move2Target;
            }
        }
    }

    void EnemyMoveToTarget()
    {
        if (!isWaiting)
        {
            enemyCanMove = movement.ObjectCanMove(moveDirection);

            if (enemyCanMove)
            {
                Node currentNode = grid.nodeFromWorldPoint(transform.position);

                if (targetNode.gridX != currentNode.gridX)
                {
                    isWaiting = true;

                    movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z));

                    StartCoroutine(EnemyMove());
                }
                else
                {
                    if (targetNode.gridY != currentNode.gridY)
                    {
                        isWaiting = true;

                        movement.MoveObject(new Vector2(moveDirection.x, moveDirection.z));

                        StartCoroutine(EnemyMove());
                    }
                    else
                    {
                        curState = EnemyState.Search;
                    }
                }
            }
        }
    }

    void EnemySearching()
    {
        Debug.DrawRay(transform.position, transform.forward * detectionDistance, Color.blue);

        if (!isRotating)
        {
            if (curRotate == fullrotate)
            {
                curRotate = 0;
                curState = EnemyState.Patrol;
                return;
            }

            isRotating = true;
            StartCoroutine(RotateSearch());
        }
    }

    IEnumerator RotateSearch()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z));

        yield return new WaitForSeconds(moveWaitTime);

        isRotating = false;

        curRotate++;

        yield return 0;
    }

    void EnemyAttack()
    {
        //Attack player whilst in range.
        print("Attacking player......");
        curState = EnemyState.Patrol;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmocolor;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
