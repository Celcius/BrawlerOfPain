

using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {
    
    [SerializeField]
    private const int MAP_WIDTH = 20;
    [SerializeField]
    private const int MAP_HEIGHT = 20;
    [SerializeField]
    private int HOLE_MARGIN = 2;

    string[,] map = new string[MAP_WIDTH, MAP_HEIGHT];
                   
	// Use this for initialization
	void Start () {
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
                GridElement.createGridElement(gridCode, x, y);
            }
    }

    void setupDeathColider()
    {

    }
}

