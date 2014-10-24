

using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {
    
    [SerializeField]
    private int MAP_WIDTH = 20;
    [SerializeField]
    private int MAP_HEIGHT = 20;
    [SerializeField]
    private int HOLE_MARGIN = 2;

    [SerializeField]
    private float _tileScale = 1.0f;

    string[,] map; 
                   
	// Use this for initialization
	void Start () {
        map = new string[MAP_WIDTH, MAP_HEIGHT];
        initializeGrid();
        setupGrid();
        setupDeathColider();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void initializeGrid()
    {
        for(int x = 0; x < MAP_WIDTH; x++)
            for(int y = 0; y < MAP_WIDTH; y++)
            {
                if(x < HOLE_MARGIN || x > MAP_WIDTH-HOLE_MARGIN ||
                    y < HOLE_MARGIN || y > MAP_HEIGHT-HOLE_MARGIN)
                {
                    map[x,y] = GridElement.HOLE_CODE;
                }
                else
                    map[x, y] = GridElement.FLOOR_CODE;
            }
    }
    void setupGrid()
    {
        for(int x = 0; x < MAP_WIDTH; x++)
            for(int y = 0; y < MAP_HEIGHT; y++)
            {
                string gridCode = map[x, y];
                GridElement.createGridElement(gridCode, x, y, _tileScale);
            }
    }

    void setupDeathColider()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("DeathZone"));
        DeathZone deathZone = go.GetComponent<DeathZone>();
        deathZone.transform.localScale = new Vector3(MAP_WIDTH * _tileScale, 1, MAP_HEIGHT * _tileScale);
        deathZone.transform.position = new Vector3(MAP_WIDTH * _tileScale / 2, 0, MAP_HEIGHT * _tileScale / 2);

    }
}

