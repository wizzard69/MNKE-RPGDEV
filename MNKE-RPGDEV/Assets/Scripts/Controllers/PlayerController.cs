using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    public GunController gun;
    public bool allowDiagonals = false;
    public float moveSpeed;

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
                movement.MoveObject(input,moveSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.isFiring = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            gun.isFiring = false;
        }
    }
}
