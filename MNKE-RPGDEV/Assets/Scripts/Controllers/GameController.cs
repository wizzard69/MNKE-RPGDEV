
using UnityEngine;

public class GameController : MonoBehaviour {

    static GameController _instance;

    [SerializeField]
    EnemyDatabase _enemyDatabase;

    #region Singleton
    GameController()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                new GameController();
            }

            return _instance;
        }
    }
#endregion

    public EnemyDatabase enemyDatabase { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start ()
    {
        enemyDatabase = _enemyDatabase;
	}

}
