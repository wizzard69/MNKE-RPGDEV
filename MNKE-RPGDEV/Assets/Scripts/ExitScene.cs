using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public string NextScene;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 0.5F))
        {
            if (hit.transform.tag == "Player")
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }
}
