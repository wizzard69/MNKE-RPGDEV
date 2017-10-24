using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{
    public Text scoreText;

    public void ExitScene()
    {
        SceneManager.LoadScene("HeroSelection");
    }

    private void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("PlayerScore").ToString();
    }
}
