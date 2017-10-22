using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroSelection : MonoBehaviour {

    public void ContinueScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void StartSelection(string character)
    {
        switch (character)
        {
            case "knight":
                SceneManager.LoadScene("Main");
                break;
            case "wizard":
                SceneManager.LoadScene("Main");
                break;
            case "ranger":
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
