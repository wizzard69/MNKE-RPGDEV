using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 input;
    Movement movement;
    bool canMove;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            input.y = 0;
        }


        if (input != Vector2.zero)
        {
            if (input.x > 0)
            {
                canMove = movement.ObjectCanMove(new Vector3(1f, 0f, 0f));
            }

            if (input.x < 0)
            {
                canMove = movement.ObjectCanMove(new Vector3(-1f, 0f, 0f));
            }

            if (input.y > 0)
            {
                canMove = movement.ObjectCanMove(new Vector3(0f, 0f, 1f));
            }

            if (input.y < 0)
            {
                canMove = movement.ObjectCanMove(new Vector3(0f, 0f, -1f));
            }

            if (canMove)
            {
                movement.MoveObject(input);
            }
        }

    }
}
