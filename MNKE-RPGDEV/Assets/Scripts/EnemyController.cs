using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveWaitTime;
    public float rotationSpeed;

    Movement movement;
    bool enemyCanMove;
    bool isWaiting;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (!isWaiting)
        {
            enemyCanMove = movement.ObjectCanMove(new Vector3(0f, 0f, 1f));

            if (enemyCanMove)
            {
                isWaiting = true;

                movement.MoveObject(new Vector2(0f, 1f));

                StartCoroutine(EnemyMove());
            }
            else
            {
                //StartCoroutine(RotateEnemy());
                RotateEnemy();
            }
        }
    }

    IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(moveWaitTime);

        isWaiting = false;

        yield return 0;
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;

            yield return null;
        }
    }

    void RotateEnemy()
    {
        //yield return StartCoroutine(TurnToFace(transform.position + new Vector3(1f, 0f, 0f)));
       transform.LookAt(transform.position + new Vector3(1f, 0f, 0f));
    }
}
