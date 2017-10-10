using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour {

    public float moveSpeed;
    public float gridSize;
    public bool allowDiagonals = false;

    enum Orientation { Horizontal, Vertical };
    Orientation gridOrientation = Orientation.Horizontal;

    Animator animator;
    Vector2 input;
    bool isMoving = false;
    Vector3 startPos, endPos;
    float t, factor;
    bool canMove;
    Grid grid;

    private void Start()
    {
        grid = GameObject.Find("GameManager").GetComponent(typeof(Grid)) as Grid;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (!allowDiagonals)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
            }

            if (input != Vector2.zero)
            {
                if (input.x > 0)
                {
                    ObjectCanMove(new Vector3(1f, 0f, 0f));
                }

                if (input.x < 0)
                {
                    ObjectCanMove(new Vector3(-1f, 0f, 0f));
                }

                if (input.y > 0)
                {
                    ObjectCanMove(new Vector3(0f, 0f, 1f));
                }

                if (input.y < 0)
                {
                    ObjectCanMove(new Vector3(0f, 0f, -1f));
                }

                if (canMove)
                {
                    StartCoroutine(move(transform));
                }
            }
        }
    }

    IEnumerator move(Transform _transform)
    {
        isMoving = true;

        startPos = _transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPos = new Vector3(startPos.x + System.Math.Sign(input.x) * gridSize, startPos.y, startPos.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPos = new Vector3(startPos.x + System.Math.Sign(input.x) * gridSize, startPos.y = System.Math.Sign(input.y) * gridSize, startPos.z);
        }

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

    void ObjectCanMove(Vector3 target)
    {
        canMove = true;

        if (Grid.notWalkableNodes.Exists(x => x.worldPosition == (grid.nodeFromWorldPoint(transform.position).worldPosition + target)))
        {
            canMove = false;
        }
    }
}
