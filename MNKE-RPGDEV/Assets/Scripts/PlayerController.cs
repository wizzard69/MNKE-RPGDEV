using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed;
    public float gridSize;
    public bool allowDiagonals = false;

    enum Orientation { Horizontal, Vertical };
    Orientation gridOrientation = Orientation.Horizontal;
    bool correctDiagonalSpeed = true;
    Vector2 input;
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;
    float factor;

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
                StartCoroutine(move(transform));
            }
        }
    }

    IEnumerator move(Transform transform)
    {
        isMoving = true;

        startPos = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPos = new Vector3(startPos.x + System.Math.Sign(input.x) * gridSize, startPos.y, startPos.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPos = new Vector3(startPos.x + System.Math.Sign(input.x) * gridSize, startPos.y = System.Math.Sign(input.y) * gridSize, startPos.z);
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
            anim.SetBool("jump", true);
        }

        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPos, endPos, t);

            if (t >= 0.6f)
            {
                anim.SetBool("jump", false);
            }

            yield return null;
        }

        isMoving = false;
        yield return 0;
    }

}
