using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridElement : MonoBehaviour {

    public const string FLOOR_CODE = "f";
    public const string HOLE_CODE = "o";

    protected const float unityScale = 10.0f;

    protected int _gridPosX;
    protected int _gridPosY;

    public void setGridElement(int x, int y) 
    {
        _gridPosX = x;
        _gridPosY = y;
        this.gameObject.transform.position = new Vector3(_gridPosX, 0, _gridPosY);
      //  this.gameObject.transform.localScale = new Vector3(1 / unityScale, 1 / unityScale, 1 / unityScale); // use this for planes
    }
	
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
	
	}
    
    public static void createGridElement(string code, int x, int y)
    {
        if (FLOOR_CODE.CompareTo(code) == 0)
        {
            createPlaneFloorGridElement(x , y);
        }
        else if( HOLE_CODE.CompareTo(code)== 0)
        {
            createHoleGridElement(x, y);
        }
;
    }

    static void createPlaneFloorGridElement(int x, int y)
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Cube);
        plane.AddComponent<BoxCollider>();
        plane.AddComponent<GridElement>().setGridElement(x, y); 
    }    

    static void  createHoleGridElement(int x, int y)
    {

    }

}

