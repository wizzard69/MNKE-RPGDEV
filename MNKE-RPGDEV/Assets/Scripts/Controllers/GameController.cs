
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum CharClass { KNIGHT, RANGER, WIZARD};
    static GameController _instance;

    [SerializeField]
    EnemyDatabase _enemyDatabase;
    [SerializeField]
    CharacterSelectionData _charSelectData;

    public static GameController Instance;

    public EnemyDatabase enemyDatabase { get; private set; }
    public CharacterSelectionData charSelectData { get; private set; }
    public int score { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        enemyDatabase = _enemyDatabase;
        charSelectData = _charSelectData;
        GetScore();
   }

    public void GetScore()
    {
        score = PlayerPrefs.GetInt("PlayerScore");
    }

    public void Updatescore(int iScore)
    {
        PlayerPrefs.SetInt("PlayerScore", iScore);
    }
}
