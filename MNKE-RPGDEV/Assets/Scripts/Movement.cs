using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

public Animator anim;
    public Transform moveableObject;
	public float moveSpeed;
	public float gridSize;
	public bool allowDiagonals = false;

	enum Orientation { Horizontal, Vertical };
	Orientation gridOrientation = Orientation.Horizontal;

    enum Direction { Left, Right, Up, Down };

	Vector2 input;
	bool isMoving = false;
    Vector3 startPos, endPos;
    float t, factor;

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
					print(Direction.Right);
				}

				if (input.x < 0)
				{
					print(Direction.Left);
				}

				if (input.y > 0)
				{
					print(Direction.Up);
				}

				if (input.y < 0)
				{
					print(Direction.Down);
				}

                NodeDataTest();

				StartCoroutine(move(moveableObject));
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
		anim.SetBool("jump", true);
		
		while (t < 1f)
		{
			t += Time.deltaTime * (moveSpeed / gridSize) * factor;
			_transform.position = Vector3.Lerp(startPos, endPos, t);

			if (t >= 0.6f)
			{
				anim.SetBool("jump", false);
			}

			yield return null;
		}

		isMoving = false;
		yield return 0;
	}

	bool CanMoveToNode(Node targetNode)
	{
		if (targetNode.walkable)
		{
			return true;
		}

		return false;
	}

    void NodeDataTest()
    {

    }
}
