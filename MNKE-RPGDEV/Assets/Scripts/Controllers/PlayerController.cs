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

    private void Awake()
    {
        GetPlayer();
    }

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
                movement.MoveObject(input, moveSpeed);
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

    void GetPlayer()
    {
        switch (GameController.Instance.charSelectData.charClass)
        {
            case GameController.CharClass.KNIGHT:
                GameObject knightOutfit = GameController.Instance.charSelectData.CharacterOutfit.prefab;
                GameObject playerSword = GameController.Instance.charSelectData.Sword.prefab;
                GameObject playerShield = GameController.Instance.charSelectData.Shield.prefab;

                GameObject knightGo = (GameObject)Instantiate(knightOutfit, GameObject.Find("PlayerObject").transform, false);
                GameObject sword = Instantiate(playerSword, knightGo.transform.GetChild(0).gameObject.transform);
                GameObject shield = Instantiate(playerShield, knightGo.transform.GetChild(1).gameObject.transform);

                break;
            case GameController.CharClass.RANGER:
                GameObject RangerOutfit = GameController.Instance.charSelectData.CharacterOutfit.prefab;
                GameObject playerBow = GameController.Instance.charSelectData.Bow.prefab;
                GameObject playerArrow = GameController.Instance.charSelectData.Arrow.prefab;

                GameObject RangerGo = (GameObject)Instantiate(RangerOutfit, GameObject.Find("PlayerObject").transform, false);
                GameObject bow = Instantiate(playerBow, RangerGo.transform.GetChild(0).gameObject.transform);
                GameObject arrow = Instantiate(playerArrow, RangerGo.transform);

                break;
            case GameController.CharClass.WIZARD:
                GameObject WizardOutfit = GameController.Instance.charSelectData.CharacterOutfit.prefab;
                GameObject playerStaff = GameController.Instance.charSelectData.Staff.prefab;
                GameObject playerHat = GameController.Instance.charSelectData.WizardHat.prefab;

                GameObject wizardGo = (GameObject)Instantiate(WizardOutfit, GameObject.Find("PlayerObject").transform, false);
                GameObject staff = Instantiate(playerStaff, wizardGo.transform.GetChild(0).gameObject.transform);
                GameObject hat = Instantiate(playerHat, wizardGo.transform);
                break;
        }
    }
}
