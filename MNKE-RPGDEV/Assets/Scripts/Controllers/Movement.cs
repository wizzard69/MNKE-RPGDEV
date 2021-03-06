﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float gridSize = 1f;
    Animator animator;
    bool isMoving = false;
    Vector3 startPos, endPos;
    float t, factor;
    Grid grid;

    private void Start()
    {
        grid = FindObjectOfType<Grid>() as Grid;
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveObject(Vector2 input, float moveSpeed)
    {
        if (!isMoving)
        {
            StartCoroutine(Move(transform, input, moveSpeed));
        }
    }

    IEnumerator Move(Transform _transform, Vector2 input, float moveSpeed)
    {
        isMoving = true;

        startPos = _transform.position;
        t = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x) * gridSize, startPos.y, startPos.z + System.Math.Sign(input.y) * gridSize);

        _transform.LookAt(endPos);

        factor = 1f;

        if (animator != null)
        {
            animator.SetBool("jump", true);
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            _transform.position = Vector3.Lerp(startPos, endPos, t);

            if (t >= 0.6f)
            {
                if (animator != null)
                {
                    animator.SetBool("jump", false);
                }
            }

            yield return null;
        }

        isMoving = false;
        yield return 0;
    }

    public bool ObjectCanMove(Vector3 target)
    {
        if (Grid.notWalkableNodes.Exists(x => x.worldPosition == (grid.nodeFromWorldPoint(transform.position).worldPosition + target)))
        {
            return false;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, target, out hit, 1f, LayerMask.GetMask("characters")))
        {
            return false;
        }

        return true;
    }

    public Vector3 GetRandomWalkableNode()
    {
        return Grid.WalkableNodes[Random.Range(0, Grid.WalkableNodes.Count)].worldPosition;
    }
}
