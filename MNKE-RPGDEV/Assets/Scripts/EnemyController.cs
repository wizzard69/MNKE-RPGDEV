using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Range(0.6f, 3.0f)]
    public float moveWaitTime;
    public float detectionDistance;
    public int maxSpaceToMoveBeforeRotate;
    public LayerMask raycastLayerMask;

    enum FaceDirection { Forward, Backward, Left, Right };
    FaceDirection faceDirection;

    Movement movement;
    bool enemyCanMove;
    bool isWaiting;
    Vector3 moveDirection;

    int allowedSpacesToMove;
    int hasMovedSpaces;

    private void Start()
    {
        movement = GetComponent<Movement>();
        ResetMoves();
    }

    void Update()
    {
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
                ResetMoves();
            }
        }

        Debug.DrawRay(transform.position, new Vector3(moveDirection.x * detectionDistance, moveDirection.y * detectionDistance, moveDirection.z * detectionDistance), Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDirection, out hit, detectionDistance, raycastLayerMask))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) <= 1f)
            {
                print("Attack Hero: " + hit.collider.name);
                ResetMoves();
                return;
            }

            if (hit.collider.tag == "Player")
            {
                print("Hero is in the way: " + hit.collider.name);
            }
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
                moveDirection = new Vector3(1f, 0f, 0f);
                break;
            case FaceDirection.Backward:
                moveDirection = new Vector3(-1f, 0f, 0f);
                break;
            case FaceDirection.Left:
                moveDirection = new Vector3(0f, 0f, -1f);
                break;
            case FaceDirection.Right:
                moveDirection = new Vector3(0f, 0f, 1f);
                break;
            default:
                break;
        }

        transform.LookAt(transform.position + moveDirection);
    }

    void ResetMoves()
    {
        allowedSpacesToMove = Random.Range(1, maxSpaceToMoveBeforeRotate + 1);
        hasMovedSpaces = 0;
        RotateEnemy();
    }
}
