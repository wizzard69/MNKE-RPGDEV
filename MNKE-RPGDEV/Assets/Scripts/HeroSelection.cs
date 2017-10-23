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
                SceneManager.LoadScene("KnightSelection");
                break;
            case "wizard":
                SceneManager.LoadScene("WizardSelection");
                break;
            case "ranger":
                SceneManager.LoadScene("RangerSelection");
                break;
        }
    }
}
