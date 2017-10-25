using UnityEngine;
using RPGStateMachine;
using System.Collections;

[RequireComponent(typeof(Movement))]
public class EnemyScriptV2 : MonoBehaviour
{
    [SerializeField]
    EnemyStats _enemyStats;
    bool isWaiting = false;
    Color GizmoColors;
    bool isAttacking = false;

    public EnemyStats enemyStats { get; private set; }
    public Movement movement { get; private set; }
    public Vector3 moveDirection { get; set; }
    public StateMachineV2<EnemyScriptV2> stateMachine { get; private set; }


    private void Start()
    {
        movement = GetComponent<Movement>();
        enemyStats = _enemyStats;
        Color GizmoColors = enemyStats.PatrolColor;

        stateMachine = new StateMachineV2<EnemyScriptV2>(this);

        stateMachine.ChangeState(PatrolStateV2.Instance);
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(moveDirection.x * enemyStats.detectionDistance,
            moveDirection.y * enemyStats.detectionDistance, moveDirection.z * enemyStats.detectionDistance), GizmoColors);

        if (!isWaiting)
        {
            isWaiting = true;

            stateMachine.Update();

            StartCoroutine(EnemyMove());
        }

        ChangeStateColor();
        DetectPlayerHit();
    }

    void ChangeStateColor()
    {
        switch (stateMachine.currentState.ToString())
        {
            case "PatrolStateV2":
                GizmoColors = enemyStats.PatrolColor;
                break;
            case "MoveToStateV2":
                GizmoColors = enemyStats.MoveToColor;
                break;
            case "AttackStateV2":
                GizmoColors = enemyStats.AttackColor;
                break;
        }
    }

    void DetectPlayerHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, moveDirection, out hit, enemyStats.detectionDistance, enemyStats.raycastLayerMask))
        {
            if (Vector3.Distance(hit.transform.position, transform.position) <= 1.5f)
            {
                if (hit.collider.tag == "Player")
                {
                    if (!isAttacking)
                    {
                        isAttacking = true;
                        stateMachine.ChangeState(AttackStateV2.Instance);
                        StartCoroutine(AttackPause());
                    }                   
                }
            }
            else
            {
                if (hit.collider.tag == "Player")
                {
                    stateMachine.ChangeState(MoveToStateV2.Instance);
                }
            }
        }
    }
        private void OnDrawGizmos()
    {
        if (enemyStats != null)
        {
            Gizmos.color = GizmoColors;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }

    IEnumerator AttackPause()
    {
        yield return new WaitForSeconds(enemyStats.moveWaitTime);
        isAttacking = false;
    }

    IEnumerator EnemyMove()
    {
        yield return new WaitForSeconds(enemyStats.moveWaitTime);

        isWaiting = false;

        yield return 0;
    }

}
