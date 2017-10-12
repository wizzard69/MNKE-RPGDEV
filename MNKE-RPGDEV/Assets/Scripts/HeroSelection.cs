using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroSelection : MonoBehaviour {

    public void ContinueScene()
    {
        SceneManager.LoadScene("Main");
    }
}
