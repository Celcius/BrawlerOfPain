﻿

using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {
 

    [SerializeField]
    public GameObject timerHud;

    [SerializeField]
    public GameObject scoreHud;

    [SerializeField]
    public GameObject livesHud;


    [SerializeField]
    private int MAP_WIDTH = 20;
    [SerializeField]
    private int MAP_HEIGHT = 20;
    [SerializeField]
    private int HOLE_MARGIN = 2;
    [SerializeField]
    private int DEATH_MARGIN = 2;

    [SerializeField]
    public int PLAYER_COUNT = 4;

    [SerializeField]
    private int PLAYER_START_OFFSET = 2;

    [SerializeField]
    private int BLOOD_SPRAY = 2;

    [SerializeField]
    private int SPAWNER_HEIGHT = 2;

    [SerializeField]
    private float _tileScale = 1.0f;

    [SerializeField]
    public float GAME_TIME = 2.5f;

    [SerializeField]
    public int MAX_SCORE = 20;

    [SerializeField]
    public int LIVES = 5;

    [SerializeField]
    public GameManager.GameType gameType;

    [SerializeField]
    public GameOverPanel gameOverPanel;
    
    string[,] map;
                   
	// Use this for initialization
	void Start () {
        loadData();
        map = new string[MAP_WIDTH, MAP_HEIGHT];
        GameManager.instance.setMap(new GridElement[MAP_WIDTH, MAP_HEIGHT], this);
        initializeGrid();
        setupGrid();
        setupDeathColider();
        setupSpawners();
        setupTraps();

        GameManager.instance.startGame(); // will start Counting
   	}

    void loadData()
    {
        gameType = DataHolder.instance.gameType;
        PLAYER_COUNT = DataHolder.instance.playerCount;
        GAME_TIME = DataHolder.instance.time/60;
        if(DataHolder.instance.gameType == GameManager.GameType.VIP) // Should really be 2 difernt variables, too late to change now
            MAX_SCORE = DataHolder.instance.vipScore;
        else
            MAX_SCORE = DataHolder.instance.score;
        LIVES = DataHolder.instance.lives;
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void setupTraps()
    {
        GameObject trap1 = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
        GameObject trap2 = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
        GameObject trap3 = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
        GameObject trap4 = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;

        
        float trapDiff = 0.5f;
        trap1.transform.position = new Vector3(trapDiff * _tileScale + 0.5f * _tileScale, 0.5f, trapDiff * _tileScale );
        trap2.transform.position = new Vector3((MAP_WIDTH - trapDiff) * _tileScale - 2* _tileScale, 0.5f, trapDiff * _tileScale);
        trap3.transform.position = new Vector3((MAP_WIDTH - trapDiff) * _tileScale - 2* _tileScale, 0.5f, (MAP_HEIGHT - trapDiff) * _tileScale -  1.5f* _tileScale); // topRight
        trap4.transform.position = new Vector3(trapDiff * _tileScale + 0.5f* _tileScale, 0.5f, (MAP_HEIGHT - trapDiff) * _tileScale -1.5f* _tileScale); // Top Left

        if(gameType != GameManager.GameType.VIP)
        { 
           GameObject trap5 = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject; 
            trap5.transform.position = new Vector3((MAP_WIDTH - trapDiff - 1) * _tileScale / 2, -0.5f, (MAP_HEIGHT - trapDiff - 1) * _tileScale / 2);
        }
    }

    void initializeGrid()
    {
        
        for(int x = 0; x < MAP_WIDTH; x++)
            for(int y = 0; y < MAP_HEIGHT; y++)
            {
                if(x < HOLE_MARGIN || x > MAP_WIDTH-HOLE_MARGIN ||
                    y < HOLE_MARGIN || y > MAP_HEIGHT-HOLE_MARGIN)
                {
                    map[x,y] = GridElement.HOLE_CODE;
                }
                else
                {
                    if (gameType != GameManager.GameType.VIP && (x >= MAP_WIDTH / 2 - 1 && x <= MAP_WIDTH / 2 + 1) &&
                        (y >= MAP_HEIGHT / 2 - 1 && y <= MAP_HEIGHT / 2 + 1))
                             map[x, y] = GridElement.HOLE_CODE;
                    else
                          map[x, y] = GridElement.FLOOR_CODE;
                }
            }

        if(MAP_WIDTH > 8 && MAP_HEIGHT > 5)
        { 
          map[MAP_WIDTH / 2 + 3, MAP_HEIGHT - HOLE_MARGIN + 1] = GridElement.BRAZIER_CODE;
          map[MAP_WIDTH / 2 - 3, MAP_HEIGHT - HOLE_MARGIN + 1] = GridElement.BRAZIER_CODE;
          map[MAP_WIDTH / 2 + 3, HOLE_MARGIN - 1] = GridElement.BRAZIER_CODE;
          map[MAP_WIDTH / 2 - 3, HOLE_MARGIN - 1] = GridElement.BRAZIER_CODE;
          map[HOLE_MARGIN - 1, MAP_HEIGHT / 2] = GridElement.BRAZIER_CODE;
          map[MAP_WIDTH - HOLE_MARGIN + 1, MAP_HEIGHT / 2] = GridElement.BRAZIER_CODE;
        }
    }

    void setupGrid()
    {
        for(int x = 0; x < MAP_WIDTH; x++)
            for(int y = 0; y < MAP_HEIGHT; y++)
            {
                string gridCode = map[x, y];
                GridElement element = GridElement.createGridElement(gridCode, x, y, _tileScale);
                if (element != null)
                    GameManager.instance.setMapElement(element, x, y);
            }
    }

    void setupDeathColider()
    {
		GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/DeathZone"));
        DeathZone deathZone = go.GetComponent<DeathZone>();
        deathZone.transform.localScale = new Vector3((MAP_WIDTH + DEATH_MARGIN) * _tileScale, 1, (MAP_HEIGHT + DEATH_MARGIN) * _tileScale);
        deathZone.transform.position = new Vector3((MAP_WIDTH) * _tileScale / 2, -4, (MAP_HEIGHT) * _tileScale / 2);

    }

    public float getMapScale()
    {
        return _tileScale;
    }

    public int getBloodSpray()
    {
        return BLOOD_SPRAY;
    }



    void setupSpawners()
    {
        for(int i = 0; i < PLAYER_COUNT; i ++)
        {
			GameObject ob = (GameObject)Instantiate(Resources.Load("Prefabs/Spawner"));
            Spawner spawner = ob.GetComponent<Spawner>();

            Vector3 position = new Vector3(0, SPAWNER_HEIGHT, 0);
            if( i == 2)
                position = new Vector3(HOLE_MARGIN + PLAYER_START_OFFSET, SPAWNER_HEIGHT, HOLE_MARGIN + PLAYER_START_OFFSET);
            else if(i ==3)
                position = new Vector3(MAP_WIDTH - HOLE_MARGIN - PLAYER_START_OFFSET, SPAWNER_HEIGHT, HOLE_MARGIN + PLAYER_START_OFFSET);
            else if( i == 0)
                position = new Vector3(HOLE_MARGIN + PLAYER_START_OFFSET, SPAWNER_HEIGHT, MAP_HEIGHT - HOLE_MARGIN - PLAYER_START_OFFSET);
            else if(i ==1)
                position = new Vector3(MAP_WIDTH - HOLE_MARGIN - PLAYER_START_OFFSET, SPAWNER_HEIGHT, MAP_HEIGHT - HOLE_MARGIN - PLAYER_START_OFFSET);
           
            spawner.transform.position = position*_tileScale;

            spawner.spawnPlayer(i);

            
        }

    }

    public PickableItem createVipToken()
    {
        GameObject ob =  Instantiate(Resources.Load("Prefabs/PickableCube")) as GameObject;
        PickableItem item = ob.GetComponent<PickableItem>();
        centerItem(item.transform);
        return item;
    }

    public void centerItem(Transform trans)
    {
        trans.position = new Vector3(MAP_WIDTH / 2 * _tileScale, 2, MAP_HEIGHT / 2 * _tileScale);
    }
}

