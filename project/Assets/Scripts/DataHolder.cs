using UnityEngine;
using System.Collections;

public class DataHolder : MonoBehaviour {




    public int playerCount = 4;
    public float time = 2.5f;
    public int score = 20;
    public int lives = 5;
    public int vipScore = 20;
    public GameManager.GameType gameType = GameManager.GameType.SCORE;

    bool hasBeenInitialized = false;

    private static DataHolder _instance = null;
    public static DataHolder instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject ob = new GameObject();
                ob.AddComponent<DataHolder>();
                _instance = ob.GetComponent<DataHolder>();
            }

            return _instance;
        }
    }

    public void init()
    {
        if(!hasBeenInitialized)
        { 
            DontDestroyOnLoad(gameObject);
            hasBeenInitialized = true;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
