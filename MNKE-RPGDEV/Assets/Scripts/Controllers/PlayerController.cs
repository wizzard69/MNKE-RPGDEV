using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    GunController gun;
    public bool allowDiagonals = false;
    public float moveSpeed;

    Vector2 input;
    Movement movement;
    bool canMove;
    bool hasAProjectileWeapon;

    private void Awake()
    {
        GetPlayer();
    }

    private void Start()
    {
        gun = gameObject.GetComponentInChildren<GunController>();

        if (gun)
        {
            gun.isFiring = false;
        }        

        movement = GetComponent<Movement>();

        HasProjectile();
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

        if (hasAProjectileWeapon)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!gun.isFiring)
                {
                    gun.isFiring = true;
                }
            }
        }
    }

    void GetPlayer()
    {
        switch (GameController.Instance.CClass)
        {
            case "KNIGHT":
                GameObject knightOutfit = GameController.Instance.Outfit.prefab;
                GameObject playerSword = GameController.Instance.Sword.prefab;
                GameObject playerShield = GameController.Instance.Shield.prefab;

                GameObject knightGo = (GameObject)Instantiate(knightOutfit, GameObject.Find("PlayerObject").transform, false);
                GameObject sword = Instantiate(playerSword, knightGo.transform.GetChild(0).gameObject.transform);
                GameObject shield = Instantiate(playerShield, knightGo.transform.GetChild(1).gameObject.transform);

                break;
            case "RANGER":
                GameObject RangerOutfit = GameController.Instance.Outfit.prefab;
                GameObject playerBow = GameController.Instance.Bow.prefab;
                GameObject playerArrow = GameController.Instance.Arrow.prefab;

                GameObject RangerGo = (GameObject)Instantiate(RangerOutfit, GameObject.Find("PlayerObject").transform, false);
                GameObject bow = Instantiate(playerBow, RangerGo.transform.GetChild(0).gameObject.transform);
                GameObject arrow = Instantiate(playerArrow, RangerGo.transform);

                break;
            case "WIZARD":
                GameObject WizardOutfit = GameController.Instance.Outfit.prefab;
                GameObject playerStaff = GameController.Instance.Staff.prefab;
                GameObject playerHat = GameController.Instance.Hat.prefab;

                GameObject wizardGo = (GameObject)Instantiate(WizardOutfit, GameObject.Find("PlayerObject").transform, false);
                GameObject staff = Instantiate(playerStaff, wizardGo.transform.GetChild(0).gameObject.transform);
                GameObject hat = Instantiate(playerHat, wizardGo.transform);
                break;
        }
    }

    void HasProjectile()
    {
        if (gun != null)
        {
            hasAProjectileWeapon = true;
            return;
        }

        hasAProjectileWeapon = false;
    }
}

