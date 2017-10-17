using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(StateController))]
public class EnemyController : Enemy
{
    StateController stateController;

    private void Start()
    {
        stateController = GetComponent<StateController>();
        stateController.detectionDistance = detectionDistance;
        stateController.maxSpaceToMoveBeforeRotate = maxSpaceToMoveBeforeRotate;
        stateController.moveWaitTime = moveWaitTime;

        base.start();  
    }
}
