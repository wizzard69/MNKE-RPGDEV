using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 0.5F))
        {
            if (hit.transform.tag == "Player")
            {
                print("Exit");
            }
        }
    }
}
