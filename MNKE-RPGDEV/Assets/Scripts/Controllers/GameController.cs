
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public enum CharClass { KNIGHT, RANGER, WIZARD };

    static GameController _instance;

    EnemyDatabase _enemyDatabase;

    [SerializeField]
    string _CClass;
    [SerializeField]
    Item _Outfit;
    [SerializeField]
    Item _Hat;
    [SerializeField]
    Equipment _Staff;
    [SerializeField]
    Equipment _Shield;
    [SerializeField]
    Equipment _Sword;
    [SerializeField]
    Equipment _Bow;
    [SerializeField]
    Equipment _Arrow;

    //[SerializeField]
    //CharacterSelectionData defCharData;

    //CharacterSelectionData _charSlectData;

    public static GameController Instance;

    public EnemyDatabase enemyDatabase { get; private set; }

    public int score { get; private set; }

    public string CClass { get; set; }

    public Item Outfit { get; set; }

    public Equipment Shield { get; set; }

    public Equipment Sword { get; set; }

    public Equipment Bow { get; set; }

    public Equipment Arrow { get; set; }

    public Equipment Staff { get; set; }

    public Item Hat { get; set; }

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
        CClass = _CClass;
        Outfit = _Outfit;
        Shield = _Shield;
        Sword = _Sword;
        Bow = _Bow;
        Arrow = _Arrow;
        Staff = _Staff;

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
