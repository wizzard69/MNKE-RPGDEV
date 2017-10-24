
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum CharClass { KNIGHT, RANGER, WIZARD };

    static GameController _instance;

    EnemyDatabase _enemyDatabase;

    [SerializeField]
    CharacterSelectionData defCharData;

    CharacterSelectionData _charSlectData;

    public static GameController Instance;

    public EnemyDatabase enemyDatabase { get; private set; }

    public CharacterSelectionData charSelectData {
        get
        {
            return this._charSlectData;
        }
        set
        {
            _charSlectData = value;
        }
    }

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
        _charSlectData = defCharData;

        enemyDatabase = _enemyDatabase;

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
